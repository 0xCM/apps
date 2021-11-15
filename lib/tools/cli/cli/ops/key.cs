//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;
    using static core;

    partial struct Cli
    {
        [MethodImpl(Inline), Op]
        public static CliRowKey key(Handle src)
        {
            var data = CliHandleData.from(src);
            return new CliRowKey(data.Table, data.RowId);
        }

        [MethodImpl(Inline), Op]
        public static CliRowKey key(EntityHandle src)
        {
            var dat = CliHandleData.from(src);
            return new CliRowKey(dat.Table, dat.RowId);
        }

        [MethodImpl(Inline)]
        public static CliRowKey<K> key<K,T>(T handle, K k = default)
            where K : unmanaged, ICliTableKind<K>
            where T : unmanaged
                => uint32(handle);
    }
}