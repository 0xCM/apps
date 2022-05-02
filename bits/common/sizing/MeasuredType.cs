//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct MeasuredType : IComparable<MeasuredType>
    {
        public static uint bitwidth(NativeTypeWidth src)
        {
            var dst = (uint)src;
            if(dst == 1)
                dst = 8;
            return dst;
        }

        public static uint aligned(Type src)
            => bitwidth(PrimalBits.width(Enums.@base(src)));

        public static DataSize size(Type src)
            => new DataSize(CalcPacked(src), MeasuredType.aligned(src));

        public static Index<MeasuredType> symbolic(Assembly src, string group)
        {
            var x =  src.Enums().TypeTags<SymSourceAttribute>().Storage.Where(x => x.Right.SymGroup == group).ToIndex();
            return x.Select(x => new MeasuredType(x.Left, size(x.Left))).Sort();
        }

        static uint CalcPacked(Type src)
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