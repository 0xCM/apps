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
        public readonly record struct DataType : IType<DataType>
        {
            /// <summary>
            /// Specifies a surrogate key
            /// </summary>
            public readonly uint Seq;

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
                Seq = seq;
                Primitive = prim;
                Name = name;
                Size = size;
                Refines = refines;
                Refinement = refinement;
            }

            asci32 IType.Name
                => Name;

            uint ISequential.Seq
                => Seq;

            DataSize IType.Size
                => Size;

            [MethodImpl(Inline)]
            public int CompareTo(DataType src)
                => Seq.CompareTo(src.Seq);
        }
    }
}