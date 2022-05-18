//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Cli
    {
        [MethodImpl(Inline), Op]
        public static CliTableKind table(Handle handle)
            => CliHandleData.from(handle).Table;

        [MethodImpl(Inline), Op]
        public static CliTableKind table(Type src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(MethodInfo src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(EventInfo src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(FieldInfo src)
            => (CliTableKind)(u32(src.MetadataToken) >> 24);

        [MethodImpl(Inline), Op]
        public static CliTableKind table(PropertyInfo src)
             => (CliTableKind)(u32(src.MetadataToken) >> 24);
    }
}