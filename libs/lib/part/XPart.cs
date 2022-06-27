//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public static class XPart
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static PartId Id(this Assembly src)
            => PartResolution.id(src);

        public static string Name(this Assembly src)
        {
            var id = PartResolution.id(src);
            return id != 0 ? id.Format() : src.GetSimpleName();
        }

        [MethodImpl(Inline), Op]
        public static PartName PartName(this PartId id)
            => id;

        [MethodImpl(Inline), Op]
        public static PartName PartName(this Assembly src)
            => PartResolution.id(src);

        [Op]
        public static string SimpleName(this AssemblyName src)
            => src.FullName.LeftOfFirst(Chars.Comma);

        [Op]
        public static bool IsPart(this AssemblyName src)
            => src.SimpleName().StartsWith("z0.");

        [Op]
        public static string Format(this PartId id)
            => PartNames.format(id);
    }
}