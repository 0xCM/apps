//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ClrQuery
    {
        // public static string Name(this Assembly src)
        // {
        //     var id = PartIdAttribute.id(src);
        //     return id != 0 ? id.Format() : src.GetName().Name;
        // }

        [Op]
        public static string Format(this PartId id)
            => PartNames.format(id);

        [MethodImpl(Inline), Op]
        public static PartName PartName(this PartId id)
            => id;

        [MethodImpl(Inline), Op]
        public static PartName PartName(this Assembly src)
            => PartIdAttribute.id(src);
    }
}