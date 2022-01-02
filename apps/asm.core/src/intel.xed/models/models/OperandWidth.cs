//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        [Record(TableId)]
        public struct OperandWidth
        {
            public const string TableId = "xed.rules.widths";

            public OperandWidthType Code;

            public text15 Name;

            public DataType BaseType;

            public uint Width16;

            public uint Width32;

            public uint Width64;

            public bool IsEmpty
            {
                get => Code == 0;
            }

            public bool IsNonEmpty
            {
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