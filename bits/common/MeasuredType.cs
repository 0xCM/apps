//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct MeasuredType : IComparable<MeasuredType>
    {
        public static Index<MeasuredType> symbolic(Assembly src, string group)
        {
            var x =  src.Enums().TypeTags<SymSourceAttribute>().Storage.Where(x => x.Right.SymGroup == group).ToIndex();
            return x.Select(x => new MeasuredType(x.Left, CalcSize(x.Left))).Sort();
        }

        static Aligned CalcAligned(Type src)
            => Aligned.from(PrimalBits.width(Enums.@base(src)));

        static ulong CalcPacked(Type src)
            => src.Tag<DataWidthAttribute>().MapValueOrElse(x => x.ContentWidth, () => 0);

        static DataSize CalcSize(Type src)
        {
            var aligned = CalcAligned(src);
            var packed = CalcPacked(src);
            return new DataSize(aligned, packed == 0 ? aligned.Width : packed);
        }

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