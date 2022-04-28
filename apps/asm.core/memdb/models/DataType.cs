//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public partial class MemDb
    {
        [MethodImpl(Inline), Op]
        public static DataType type(uint seq, asci32 name, asci32 primitive, DataSize size, asci32 refinement = default)
            => new DataType(seq, name, primitive, size, !refinement.IsNull, refinement);

        [StructLayout(LayoutKind.Sequential,Pack=1)]
        public readonly record struct DataType : IType<DataType>
        {
            /// <summary>
            /// Specifies a surrogate key
            /// </summary>
            public readonly uint Key;

            /// <summary>
            /// Specifies the name of the domain type
            /// </summary>
            public readonly asci32 Name;

            /// <summary>
            /// Specifies the name of a system-defined primitive with which the defined type is isomorphic
            /// </summary>
            public readonly asci32 Primitive;

            /// <summary>
            /// Specifies the physical/logical type size
            /// </summary>
            public readonly DataSize Size;

            /// <summary>
            /// Specifies whether the type refines a system or user-defined type
            /// </summary>
            public readonly bit Refines;

            /// <summary>
            /// Specifies the name, if any, the type refines
            /// </summary>
            public readonly asci32 Refinement;

            [MethodImpl(Inline)]
            public DataType(uint seq, asci32 name, asci32 prim, DataSize size, bit refines, asci32 refinement)
            {
                Key = seq;
                Primitive = prim;
                Name = name;
                Size = size;
                Refines = refines;
                Refinement = refinement;
            }

            asci32 IType.Name
                => Name;

            DataSize IType.Size
                => Size;

            uint IEntity.Key
                => Key;

            [MethodImpl(Inline)]
            public int CompareTo(DataType src)
                => Key.CompareTo(src.Key);
        }
    }
}