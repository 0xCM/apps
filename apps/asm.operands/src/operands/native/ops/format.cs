//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        public static string format(NativeCellType src)
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