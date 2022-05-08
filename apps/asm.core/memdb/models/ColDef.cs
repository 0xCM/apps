//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct ColDef : IEntity<ColDef>
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

            [MethodImpl(Inline)]
            public int CompareTo(ColDef src)
                => Pos.CompareTo(src.Pos);

            [MethodImpl(Inline)]
            public ColDef Reposition(ushort pos)
                => new ColDef(pos, ColName, RenderWidth);

            uint IEntity.Key
                => Pos;
        }
    }
}