//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct PartName : IComparable<PartName>, IEquatable<PartName>, IExpr
    {
        public readonly PartId PartId;

        public readonly string PartExpr;

        [MethodImpl(Inline)]
        public PartName()
        {
            PartId = 0;
            PartExpr = EmptyString;
        }

        public PartName(PartId id)
        {
            PartId = id;
            PartExpr = id.Format();
        }

        [MethodImpl(Inline)]
        public PartName(PartId id, string name)
        {
            PartId = id;
            PartExpr = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => PartId == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => PartId != 0;
        }

        public override int GetHashCode()
            => (int)PartId;

        public bool Equals(PartName src)
            => PartId == src.PartId && PartExpr == src.PartExpr;

        public int CompareTo(PartName src)
            => PartExpr.CompareTo(src.PartExpr);

        [MethodImpl(Inline)]
        public string Format()
            => PartExpr ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PartName(PartId id)
            => new PartName(id);

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartName name)
            => name.PartId;

        public static PartName Empty => new PartName();
    }
}