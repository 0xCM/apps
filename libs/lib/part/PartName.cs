//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PartName : ILexical<PartName>, IComparable<PartName>
    {
        [MethodImpl(Inline)]
        public static PartName from(Type src)
            => new PartName(src.Assembly.Id());

        public readonly PartId Part {get;}

        public readonly string Name {get;}

        [MethodImpl(Inline)]
        public PartName(PartId id)
        {
            Part = id;
            Name = id.Format();
        }

        [MethodImpl(Inline)]
        public PartName(PartId id, string name)
        {
            Part = id;
            Name = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Part == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Part != 0;
        }

        public int CompareTo(PartName src)
            => Name.CompareTo(src.Name);

        [MethodImpl(Inline)]
        public string Format()
            => Name ?? EmptyString;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator PartName(PartId id)
            => new PartName(id);

        [MethodImpl(Inline)]
        public static implicit operator PartId(PartName name)
            => name.Part;
    }
}