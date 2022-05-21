//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        // [Formatter]
        // public static string format(ScalarClass src)
        // {
        //     var dst = EmptyString;
        //     if(src.PackedWidth == src.NativeWidth)
        //         dst = string.Format("{0}{1}", src.PackedWidth, NativeTypes.indicator(src.Kind));
        //     else
        //         dst = string.Format("({0}:{1}){2}", src.PackedWidth, src.NativeWidth, NativeTypes.indicator(src.Kind));
        //     return dst;
        // }

        public static string format(NativeScalar src)
            => src.IsVoid ? "void"
                : string.Format("{0}{1}", indicator(src.Class), (ushort)src.Width);

        public static string format(NativeSegType src)
            => src.CellCount <= 1 ? format(src.CellType)
                : string.Format("{0}x{1}", src.Width, format(src.CellType));

        public static string format(NativeType src)
            =>  src.IsSegmeted ? format(src.AsSegType())
              : format(src.AsCellType());
    }
}