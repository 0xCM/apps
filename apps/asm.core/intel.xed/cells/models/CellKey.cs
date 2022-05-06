//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack = 1)]
        public readonly struct CellKey : IComparable<CellKey>, IEquatable<CellKey>
        {
            public readonly ushort Index;

            public readonly RuleTableKind Kind;

            public readonly ushort Table;

            public readonly byte Row;

            public readonly byte Col;

            public readonly LogicClass Logic;

            public readonly FieldKind Field;

            public readonly RuleCellType CellType;

            public readonly RuleSig Rule;

            public readonly KeywordKind Keyword;

            readonly byte Pad2;

            readonly byte Pad1;

            [MethodImpl(Inline)]
            public CellKey(ushort index, ushort table, ushort row, byte col, LogicClass logic, RuleCellType type, RuleTableKind kind, Nonterminal rule, FieldKind field, KeywordKind keyword)
            {
                Index = index;
                Table = table;
                Rule = new (kind,rule.Name);
                Row = (byte)row;
                Col = col;
                Logic = logic;
                CellType = type;
                Field = field;
                Keyword = keyword;
                Kind = kind;
                Pad2 = 0;
                Pad1 = 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Rule.IsEmpty;
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => Rule.IsNonEmpty;
            }

            public Hash32 Hash
            {
                [MethodImpl(Inline)]
                get => Bitfields.join(Table, Bitfields.join((byte)Row, math.or(Col, (byte)Logic)));
            }

            [MethodImpl(Inline)]
            public bool Equals(CellKey src)
            {
                bit result = Table == src.Table;
                result &= Index == src.Index;
                result &= Row == src.Row;
                result &= Col == src.Col;
                result &= Logic == src.Logic;
                result &= Rule == src.Rule;
                return result;
            }

            public ref readonly Coordinate Location
                =>  ref core.@as<Coordinate>(core.seek(core.bytes(this),2));


            public override bool Equals(object src)
                => src is CellKey k && Equals(k);

            public override int GetHashCode()
                => Hash;

            public string FormatSemantic()
                => string.Format("{0}[{1:D2}:{2:D2}].{3}", Rule, Row, Col, Logic) + (Keyword != 0 ? ( "." + XedRender.format(Keyword) ) : EmptyString);

            public string Format()
                => core.bytes(this).FormatHex();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public int CompareTo(CellKey src)
                => cmp(this,src);

            public static bool operator==(CellKey a, CellKey b)
                => a.Equals(b);

            public static bool operator!=(CellKey a, CellKey b)
                => !a.Equals(b);
        }
    }
}