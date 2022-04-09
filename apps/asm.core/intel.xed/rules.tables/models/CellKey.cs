//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack = 1)]
        public readonly struct CellKey : IComparable<CellKey>, IEquatable<CellKey>
        {
            public readonly ushort TableId;

            public readonly ushort RowIndex;

            public readonly byte CellIndex;

            public readonly RuleTableKind TableKind;

            public readonly LogicClass Logic;

            readonly byte Pad;

            [MethodImpl(Inline)]
            public CellKey(RuleTableKind kind, uint table, ushort row, LogicClass logic, byte cell)
            {
                TableKind = kind;
                TableId = (ushort)table;
                RowIndex = row;
                Logic = logic;
                CellIndex = cell;
                Pad = 0;
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

            public string Format()
                => ((ulong)this).FormatHex(uppercase:true);

            public override string ToString()
                => Format();

            public int CompareTo(CellKey src)
            {
                var result = TableId.CompareTo(src.TableId);
                if(result == 0)
                {
                    result = RowIndex.CompareTo(src.RowIndex);
                    if(result == 0)
                    {
                        result = Logic.CompareTo(src.Logic);
                        if(result == 0)
                            result = CellIndex.CompareTo(src.CellIndex);

                    }
                }
                return result;
            }

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