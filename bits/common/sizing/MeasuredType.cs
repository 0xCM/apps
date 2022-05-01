//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MeasuredType : IComparable<MeasuredType>
    {
        public static AlignedWidth aligned(Type src)
            => AlignedWidth.from(PrimalBits.width(Enums.@base(src)));

        public static DataSize size(Type src)
        {
            var aligned = MeasuredType.aligned(src);
            var packed = CalcPacked(src);
            return new DataSize(aligned, packed == 0 ? aligned.Value : packed);
        }

        public static Index<MeasuredType> symbolic(Assembly src, string group)
        {
            var x =  src.Enums().TypeTags<SymSourceAttribute>().Storage.Where(x => x.Right.SymGroup == group).ToIndex();
            return x.Select(x => new MeasuredType(x.Left, size(x.Left))).Sort();
        }

        static ulong CalcPacked(Type src)
            => src.Tag<DataWidthAttribute>().MapValueOrElse(x => x.ContentWidth, () => 0);

        public readonly Type Definition;

        public readonly DataSize Size;

        [MethodImpl(Inline)]
        public MeasuredType(Type type, DataSize size)
        {
            Definition = type;
            Size = size;
        }

        public int CompareTo(MeasuredType src)
            => Definition.Name.CompareTo(src.Definition.Name);
    }
}