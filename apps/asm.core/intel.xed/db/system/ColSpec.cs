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