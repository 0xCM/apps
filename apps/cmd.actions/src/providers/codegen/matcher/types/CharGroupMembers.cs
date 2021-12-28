//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static StringMatcher;

    /// <summary>
    /// Defines an equivalence class member predicated on the target string length and a position within a string
    /// </summary>
    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct CharGroupMembers
    {
        public const string TableId = "strings.match.groups";

        public const byte FieldCount = 3;

        public CharGroup Group;

        public uint MinSeq;

        public uint MaxSeq;

        [MethodImpl(Inline)]
        public CharGroupMembers(CharGroup group, uint min, uint max)
        {
            Group = group;
            MinSeq = min;
            MaxSeq = max;
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => MaxSeq - MinSeq;
        }

        public string Format()
            => string.Format("{0}:[{1}, {2}]", Group, MinSeq, MaxSeq);

        public override string ToString()
            => Format();

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,12};
    }
}