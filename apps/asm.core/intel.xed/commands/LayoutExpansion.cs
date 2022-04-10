//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedPatterns;
    using static XedFields;
    using static core;

    using C = XedRules.InstFieldKind;

    partial class XedRules
    {
        public static Index<CellExpansion> expansions(InstFields fields)
        {
            var dst = alloc<CellExpansion>(fields.Count);
            for(var i=0; i<fields.Count; i++)
            {
                ref readonly var field = ref fields[i];
                switch(field.DataKind)
                {
                    case C.Seg:
                    case C.HexLiteral:
                    case C.Nonterm:
                    default:
                    break;
                }
            }

            return dst;
        }

        public struct LayoutExpansion
        {
            public readonly InstClass Class;

            public readonly XedOpCode OpCode;

            public readonly Index<CellExpansion> Cells;

            public LayoutExpansion(InstClass @class, XedOpCode oc, CellExpansion[] fields)
            {
                Class = @class;
                OpCode = oc;
                Cells = fields;
            }

            public uint CellCount
            {
                [MethodImpl(Inline)]
                get => Cells.Count;
            }

            public ref CellExpansion this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public ref CellExpansion this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Cells[i];
            }

            public LayoutExpansion Replicate()
            {
                var dst = new LayoutExpansion(Class, OpCode, core.alloc<CellExpansion>(CellCount));
                for(var i=0; i<CellCount; i++)
                    dst[i] = this[i];
                return dst;
            }

            public string Format()
            {
                var dst = text.buffer();
                for(var i=0; i<Cells.Count; i++)
                {
                    if(i!=0)
                        dst.Append(Chars.Space);

                    dst.Append(Cells[i].Format());
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();


            public static LayoutExpansion Empty => default;
        }
    }
}