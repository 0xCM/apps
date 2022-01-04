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
        public struct RulePattern : IEquatable<RulePattern>, IComparable<RulePattern>
        {
            public const string TableId = "xed.rules.patterns";

            public const byte FieldCount = 5;

            public uint Seq;

            public Hash32 Hash;

            public IClass Class;

            public OpCodeMapIdentity OpCodeMap;

            public TextBlock Content;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,24,16,1};

            public override int GetHashCode()
                => (int)Hash;

            public bool Equals(RulePattern src)
                => Content.Equals(src.Content);

            public int CompareTo(RulePattern src)
            {
                var i = ((ushort)Class).CompareTo(((ushort)src.Class));
                if(i == 0)
                    i = Content.CompareTo(src.Content);
                return i;
            }
        }
    }
}