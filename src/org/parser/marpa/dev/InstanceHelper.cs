using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace org.parser.marpa.dev
{
    public interface IInstanceHelper
    {
        bool IsCloneable();

        Func<IntPtr> Allocator();

        bool IsComparable();
    }

    // A generic instance helper that is capable to create and manage multitons if needed
    public static class InstanceHelper<T>
        where T : IDisposable, IInstanceHelper
    {
        private class MultitonKey
        {
            public bool IsCloneable;
            public IntPtr Engine;
            public Func<IntPtr> Allocator;
            public bool IsShallow;
            public object Instance;
        }

        private static readonly ConcurrentDictionary<MultitonKey, object> Multitons = new ConcurrentDictionary<MultitonKey, object>();

        public static object GetInstance(Func<object, bool> equalsFunc)
        {
            if (equalsFunc != null)
            {
                object instance = Multitons.GetOrAdd()
                // Multiton pattern
                KeyValuePair<MultitonKey, object> x = Multitons.FirstOrDefault(p => equalsFunc.Invoke(p.Key.Instance));
                if (x != null)
                {
                    return instance;
                }
                return;
            }
        }
    }
}
