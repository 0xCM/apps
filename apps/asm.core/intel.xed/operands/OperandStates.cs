//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public class OperandStates : IIndex<OperandStates.Entry>
        {
            [StructLayout(LayoutKind.Sequential,Pack=1)]
            public record struct Entry : IComparable<Entry>
            {
                public OperandState State;

                public Index<OpSpec> Ops;

                public AsmInfo Asm;

                public Index<FieldValue> Fields;

                [MethodImpl(Inline)]
                public bool Field(FieldKind kind, out FieldValue dst)
                {
                    dst = FieldValue.Empty;
                    for(var i=0; i<Fields.Count; i++)
                    {
                        ref readonly var f = ref Fields[i];
                        if(f.Field == kind)
                        {
                            dst = f;
                            break;
                        }
                    }
                    return dst.IsNonEmpty;
                }

                [MethodImpl(Inline)]
                public int CompareTo(Entry src)
                    => Asm.IP.CompareTo(src.Asm.IP);

                public static Entry Empty => default;
            }

            readonly Index<Entry> Data;

            [MethodImpl(Inline)]
            public ref readonly Index<Entry> Entries()
                => ref Data;

            [MethodImpl(Inline)]
            public bool Field(uint i, FieldKind kind, out FieldValue dst)
                => Data[i].Field(kind, out dst);

            public OperandStates(Entry[] src)
            {
                Data = src;
            }

            public ref Entry this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public ref Entry this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Data[i];
            }

            public uint Count
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            Entry[] IIndex<Entry>.Storage
                => Data;
        }
    }
}