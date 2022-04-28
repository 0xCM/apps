//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MemDb
    {
        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public record class ColSpec : IElement<ColSpec>
        {
            public readonly ushort Id;

            public readonly DataType Type;

            public readonly asci32 Name;

            [MethodImpl(Inline)]
            public ColSpec(ushort id, DataType type, asci32 name)
            {
                Id = id;
                Type = type;
                Name = name;
            }

            [MethodImpl(Inline)]
            public int CompareTo(ColSpec src)
                => Id.CompareTo(src.Id);
        }
    }
}