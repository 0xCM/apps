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
        public struct RulePattern
        {
            public const string TableId = "xed.rules.patterns";

            public const byte FieldCount = 3;

            public uint Seq;

            public Hash32 Hash;

            public TextBlock Content;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,1};
        }
    }
}