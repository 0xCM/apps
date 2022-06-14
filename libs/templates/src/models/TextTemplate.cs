//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class TextTemplate : ITextTemplate
    {
        public TextBlock Pattern {get;}

        public virtual Index<object> Parameters {get;}

        public virtual uint ParameterCount {get;}

        public TextTemplate(string src)
        {
            Pattern = src ?? EmptyString;
            Parameters = sys.empty<object>();
            ParameterCount = 0;
        }

        public TextTemplate(string src, object[] parameters)
        {
            Pattern = src ?? EmptyString;
            Parameters = parameters;
            ParameterCount = (uint)parameters.Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Pattern.IsNonEmpty;
        }

        public string Format()
            => Parameters.IsNonEmpty ? string.Format(Pattern, Parameters) : Pattern;

        public override string ToString()
            => Format();
    }
}