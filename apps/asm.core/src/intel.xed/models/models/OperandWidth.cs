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
        }
    }
}