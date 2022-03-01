//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId)]
        public struct OperandWidth
        {
            public const string TableId = "xed.rules.widths";

            public OperandWidthType Code;

            public text15 Name;

            public XedDataType BaseType;

            public uint Width16;

            public uint Width32;

            public uint Width64;

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Code == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Code != 0;
            }

            public string Format()
            {
                var indicator = Symbols.expr(Code);
                var width = EmptyString;
                if(Width16 != Width64)
                    width = string.Format("({0}/{1}/{2})", Width16, Width32, Width64);
                else
                    width = Width64.ToString();
                return string.Format("{0}:{1}w", indicator, width);
            }

            public override string ToString()
                => Format();

            public static OperandWidth Empty => default;
        }
    }
}