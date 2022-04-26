//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial class XedDb
    {
        public readonly record struct DataType : IElement<DataType>
        {
            public readonly ushort TypeId;

            public readonly asci8 Primitive;

            public readonly asci16 TypeName;

            public readonly byte PrimalWidth;

            public readonly byte PackedWidth;

            [MethodImpl(Inline)]
            public DataType(ushort id, asci8 prim, asci16 name, byte width, byte packed)
            {
                TypeId = id;
                Primitive = prim;
                TypeName = name;
                PrimalWidth = width;
                PackedWidth = packed;
            }

            [MethodImpl(Inline)]
            public int CompareTo(DataType src)
                => TypeId.CompareTo(src.TypeId);
        }
    }
}