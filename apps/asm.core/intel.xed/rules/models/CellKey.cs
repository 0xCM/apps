//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack = 1,Size=8)]
        public readonly struct CellKey : IComparable<CellKey>, IEquatable<CellKey>
        {
            public readonly ushort TableId;

            public readonly RuleSig TableSig;

            public readonly ushort RowIndex;

            public readonly byte CellIndex;

            public readonly LogicClass Logic;

            [MethodImpl(Inline)]
            public CellKey(RuleSig key, uint table, ushort row, LogicClass logic, byte cix)
            {
                TableSig = key;
                TableId = (ushort)table;
                RowIndex = row;
                Logic = logic;
                CellIndex = cix;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => (ulong)this == 0;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => (ulong)this != 0;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Bitfields.join(TableId, Bitfields.join((byte)RowIndex, math.or(CellIndex, (byte)Logic)));
            }

            [MethodImpl(Inline)]
            public bool Equals(CellKey src)
                => (ulong)this == (ulong)src;

            public override bool Equals(object src)
                => src is CellKey k && Equals(k);

            public override int GetHashCode()
                => Hash;

            public string FormatSemantic()
                => string.Format("{0}[{1:D2}:{2:D2}].{3}", TableSig, RowIndex, CellIndex, Logic);
            public string Format()
                => ((ulong)this).FormatHex(uppercase:true);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(CellKey src)
                => cmp(this,src);

            [MethodImpl(Inline)]
            public static explicit operator ulong(CellKey src)
                => u64(src);

            [MethodImpl(Inline)]
            public static explicit operator CellKey(ulong src)
                => generic<CellKey>(src);

            public static bool operator==(CellKey a, CellKey b)
                => a.Equals(b);

            public static bool operator!=(CellKey a, CellKey b)
                => !a.Equals(b);
        }
    }
}