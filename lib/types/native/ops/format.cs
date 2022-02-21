//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class NativeTypes
    {
        public static string format(NativeCellType src)
            => string.Format("{0}{1}", src.Width, indicator(src.Class));

        public static string format(NativeSegType src)
            => src.CellCount == 1 ? format(src.CellType) : string.Format("{0}x{1}", src.Width, format(src.CellType));

        public static string format(NativeVectorType src)
            => string.Format("v{0}x{1}", src.Width, format(src.CellType));

        public static string format(NativeType src)
            => src.IsVectorType ? src.AsVectorType().Format() : src.AsCellType().Format();
    }
}