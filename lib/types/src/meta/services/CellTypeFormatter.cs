//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using static Root;

    [Formatter(typeof(CellType))]
    readonly struct CellTypeFormatter : ITextFormatter<CellType>
    {
        public static CellTypeFormatter Service => default;

        public string Format(CellType src)
        {
            var dst = EmptyString;
            if(src.ContentWidth == src.StorageWidth)
                dst = string.Format("{0}{1}", src.ContentWidth, types.format(src.Kind));
            else
                dst = string.Format("({0}:{1}){2}", src.ContentWidth, src.StorageWidth, types.format(src.Kind));
            return dst;
        }
    }
}