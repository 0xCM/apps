//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct CoffObjects
    {
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<CoffSymbol> symbols(ReadOnlySpan<byte> src, uint offset, uint count)
            => slice(recover<CoffSymbol>(slice(src,offset)), 0, count);

        [MethodImpl(Inline), Op]
        public static CoffObject Load(FS.FilePath path)
            => new CoffObject(path.Ext == FS.Obj ? path.SrcId(FileKind.Obj) : path.SrcId(FileKind.O), path, path.ReadBytes());

        [MethodImpl(Inline), Op]
        public static DateTime timestamp(Hex32 src)
            => Time.epoch(TimeSpan.FromSeconds(src));

        [MethodImpl(Inline), Op]
        public static ref readonly CoffHeader header(ReadOnlySpan<byte> src, uint offset)
            => ref skip(recover<CoffHeader>(src), offset);
    }
}