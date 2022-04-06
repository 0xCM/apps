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
        public readonly struct RuleExprKey : IComparable<RuleExprKey>, IEquatable<RuleExprKey>
        {
            readonly ushort TableInfo;

            public readonly ushort RowIndex;

            readonly byte _Logic;

            public readonly byte ExprSeq;

            [MethodImpl(Inline)]
            public RuleExprKey(RuleTableKind kind, uint table, ushort row, char logic, byte expr)
            {
                TableInfo = math.or((ushort)table, KindBit(kind));
                RowIndex = row;
                _Logic = (byte)logic;
                ExprSeq = expr;
            }

            const ushort TableMask = Pow2.T15 - 1;

            public uint TableId
            {
                [MethodImpl(Inline)]
                get => TableInfo & (uint)TableMask;
            }

            public RuleTableKind TableKind
            {
                [MethodImpl(Inline)]
                get => bit.test(TableInfo,15) ? RuleTableKind.Enc : RuleTableKind.Dec;
            }

            public char Logic
            {
                [MethodImpl(Inline)]
                get => (char)_Logic;
            }

            byte LogicBit
            {
                [MethodImpl(Inline)]
                get => Logic == 'P' ? z8 : Pow2.T07;
            }

            [MethodImpl(Inline)]
            static ushort KindBit(RuleTableKind kind)
                => kind == RuleTableKind.Enc ? Pow2.T15 : z16;

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Bitfields.join((ushort)TableInfo, Bitfields.join((byte)RowIndex, math.or((byte)ExprSeq, LogicBit)));
            }

            [MethodImpl(Inline)]
            public bool Equals(RuleExprKey src)
                => (ulong)this == (ulong)src;

            public override bool Equals(object src)
                => src is RuleExprKey k && Equals(k);

            public override int GetHashCode()
                => Hash;

            public string Format()
                => ((ulong)this).FormatHex(uppercase:true);

            public override string ToString()
                => Format();

            public int CompareTo(RuleExprKey src)
            {
                var result = TableInfo.CompareTo(src.TableInfo);
                if(result == 0)
                {
                    result = RowIndex.CompareTo(src.RowIndex);
                    if(result == 0)
                    {
                        result = LogicBit.CompareTo(src.LogicBit);
                        if(result == 0)
                            result = ExprSeq.CompareTo(src.ExprSeq);
                    }
                }
                return result;
            }

            [MethodImpl(Inline)]
            public static explicit operator ulong(RuleExprKey src)
                => u64(src);

            [MethodImpl(Inline)]
            public static explicit operator RuleExprKey(ulong src)
                => generic<RuleExprKey>(src);

            public static bool operator==(RuleExprKey a, RuleExprKey b)
                => a.Equals(b);

            public static bool operator!=(RuleExprKey a, RuleExprKey b)
                => !a.Equals(b);
        }
    }
}