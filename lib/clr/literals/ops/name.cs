//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static StringAddress name(FieldInfo src)
            => new StringAddress(core.address(src.Name));

        [MethodImpl(Inline), Op]
        public static StringAddress name(Type src)
            => new StringAddress(core.address(src.Name));

        [MethodImpl(Inline), Op]
        public static StringAddress name(PropertyInfo src)
            => new StringAddress(core.address(src.Name));

        [MethodImpl(Inline), Op]
        public static StringAddress name(MethodBase src)
            => new StringAddress(core.address(src.Name));
    }
}