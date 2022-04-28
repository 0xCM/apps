//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct ColDef : ISequential<ColDef>
        {
            public readonly ushort Pos;

            public readonly ColKind Type;

            public readonly asci32 Name;

            public readonly byte Width;

            [MethodImpl(Inline)]
            public ColDef(ushort pos, ColKind type, asci32 name, byte width)
            {
                Pos = pos;
                Type = type;
                Name = name;
                Width = width;
            }

            [MethodImpl(Inline)]
            public int CompareTo(ColDef src)
                => Pos.CompareTo(src.Pos);

            [MethodImpl(Inline)]
            public ColDef Reposition(ushort pos)
                => new ColDef(pos, Type, Name, Width);

            uint ISequential.Seq
                => Pos;
        }
    }
}