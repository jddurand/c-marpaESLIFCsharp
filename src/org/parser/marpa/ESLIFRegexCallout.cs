using System.Linq;

namespace org.parser.marpa
{
    public class ESLIFRegexCallout
    {
        public int? callout_number { get; set; }
        public string callout_string{ get; set; }
        public byte[] subject { get; set; }
        public byte[] pattern { get; set; }
        public int capture_top { get; set; }
        public int capture_last { get; set;}
        public int[] offset_vector { get; set; }
        public int? mark { get; set; }
        public int start_match { get; set; }
        public int current_position {  get; set; }
        public byte[] next_item { get; set; }
        public int grammar_level { get; set; }
        public int symbol_id { get; set; }

        public override string ToString()
        {
            return "ESLIFRegexCallout ["
                + $"callout_number={callout_number}, "
                + $"callout_string={callout_string}, "
                + $"subject={subject}, "
                + $"pattern={pattern}, "
                + $"capture_top={capture_top}, "
                + $"capture_last={capture_last}, "
                + $"offset_vector={string.Join(", ", offset_vector?.Select(o => o.ToString()))}, "
                + $"mark={mark}, "
                + $"start_match={start_match}, "
                + $"current_position={current_position}, "
                + $"next_item={next_item}, "
                + $"grammar_level={grammar_level}, "
                + $"symbol_id={symbol_id}, "
                + "]";
            return base.ToString();
        }
    }
}
