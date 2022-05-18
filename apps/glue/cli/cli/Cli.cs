//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;

    using static core;

    [ApiHost]
    public readonly partial struct Cli
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static CliArchive archive(FS.FolderPath root)
            => new CliArchive(root);

        public static Index<byte,CliTableKind> TableKinds()
        {
            const byte MaxTableId = (byte)CliTableKind.CustomDebugInformation;
            var values = Enums.literals<CliTableKind,byte>().Where(x => x < MaxTableId).Sort().View;
            var src = recover<CliTableKind>(values);
            var buffer = alloc<CliTableKind>(MaxTableId + 1);
            ref var dst = ref first(buffer);
            for(byte i=0; i<values.Length; i++)
                seek(dst,skip(values,i)) = (CliTableKind)i;
            return buffer;
        }

        public static CliRowKeys keys<K,T>(ReadOnlySpan<T> handles, K k = default)
            where T : unmanaged
            where K : unmanaged, ICliTableKind<K>
        {
            var count = handles.Length;
            var buffer = alloc<CliRowKey>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) = key<K,T>(skip(handles,i));
            return buffer;
        }

        public static void visualize(FS.FilePath src, FS.FilePath dst)
            => Mdv.run(src.Name,dst.Name);

    }

    [ApiHost]
    public static partial class XCmd
    {

    }
}