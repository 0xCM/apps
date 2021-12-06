//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [Formatter(typeof(PrimalCellType))]
    readonly struct CellTypeFormatter : IFormatter<PrimalCellType>
    {
        public static CellTypeFormatter Service => default;

        public string Format(PrimalCellType src)
        {
            var dst = EmptyString;
            if(src.ContentWidth == src.StorageWidth)
                dst = string.Format("{0}{1}", src.ContentWidth, TS.format(src.Kind));
            else
                dst = string.Format("({0}:{1}){2}", src.ContentWidth, src.StorageWidth, TS.format(src.Kind));
            return dst;
        }
    }
}