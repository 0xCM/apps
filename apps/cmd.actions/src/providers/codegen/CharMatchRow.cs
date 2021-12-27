//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct CharMatchRow : IComparable<CharMatchRow>
    {
        public const string TableId = "charmatch";

        public const byte FieldCount = 6;

        public uint Seq;

        public Constant<char> Char;

        public ushort Pos;

        public ushort TargetLength;

        public uint TargetId;

        public Constant<string> Target;

        public int CompareTo(CharMatchRow src)
        {
            var i = TargetLength.CompareTo(src.TargetLength);
            if(i == 0)
                i = Pos.CompareTo(src.Pos);
            if(i == 0)
                i = Char.Value.CompareTo(src.Char.Value);
            return i;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,6,6,14,14,1};
    }
}