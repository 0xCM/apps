//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly struct RuleTableDeps
        {
            public readonly FieldSet Fields;

            public readonly FunctionSet Functions;

            [MethodImpl(Inline)]
            public RuleTableDeps(in FieldSet fields, in FunctionSet fx)
            {
                Fields = fields;
                Functions = fx;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Fields.IsEmpty && Functions.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Fields.IsNonEmpty || Functions.IsNonEmpty;
            }

            public string Format()
            {
                var fieldFmt = Fields.IsNonEmpty ? Fields.Format() : EmptyString;
                var funcFmt =  Functions.IsNonEmpty ? Functions.Format() : EmptyString;
                var sep = (text.nonempty(fieldFmt) && text.nonempty(funcFmt)) ? "," : EmptyString;
                return text.embrace(string.Format("{0}{1}{2}", fieldFmt, sep, funcFmt));
            }

            public override string ToString()
                => Format();

        }
    }
}