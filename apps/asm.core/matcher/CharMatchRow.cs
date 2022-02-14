//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static StringMatcher;

    [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct CharMatchRow : IComparable<CharMatchRow>
    {
        public const string TableId = "strings.match";

        public const byte FieldCount = 7;

        public uint Seq;

        public CharGroup Group;

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

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,10,6,6,14,14,1};
    }
}