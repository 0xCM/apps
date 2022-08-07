//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct ColDef : IEntity<ColDef,ushort>, IComparable<ColDef>
        {
            public readonly ushort Pos;

            public readonly asci32 ColName;

            public readonly byte RenderWidth;

            [MethodImpl(Inline)]
            public ColDef(ushort pos, asci32 name, byte rw)
            {
                Pos = pos;
                ColName = name;
                RenderWidth = rw;
            }

            ushort IKeyed<ushort>.Key
                => Pos;

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => hash(ColName.GetHashCode(),Pos);
            }

            public override int GetHashCode()
                => Hash;

            [MethodImpl(Inline)]
            public bool Equals(ColDef src)
                => Pos == src.Pos && ColName == src.ColName && RenderWidth == src.RenderWidth;

            [MethodImpl(Inline)]
            public int CompareTo(ColDef src)
                => Pos.CompareTo(src.Pos);

            [MethodImpl(Inline)]
            public ColDef Reposition(ushort pos)
                => new ColDef(pos, ColName, RenderWidth);

        }
    }
}