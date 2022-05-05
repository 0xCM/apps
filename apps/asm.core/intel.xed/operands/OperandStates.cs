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

                [MethodImpl(Inline)]
                public int CompareTo(Entry src)
                    => Asm.IP.CompareTo(src.Asm.IP);

                public static Entry Empty => default;
            }

            readonly Index<Entry> Data;

            public ref readonly Index<Entry> Entries
            {
                [MethodImpl(Inline)]
                get => ref Data;
            }

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
                => Entries;
        }
    }
}