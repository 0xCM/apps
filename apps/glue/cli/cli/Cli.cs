//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Bytes;

    [ApiHost]
    public readonly partial struct Cli
    {
        const NumericKind Closure = UnsignedInts;

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(Assembly src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(MetadataReader src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(MemorySeg src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a parametric table source over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        /// <typeparam name="T">The record type</typeparam>
        [Op]
        public static CliTableSource<T> source<T>(PEMemoryBlock src)
            where T : struct, IRecord<T>
                => new CliTableSource<T>(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='Assembly'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(Assembly src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='MetadataReader'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(MetadataReader src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='MemorySeg'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(MemorySeg src)
            => new CliDataSource(src);

        /// <summary>
        /// Defines a <see cref='CliDataSource'/> over a specified <see cref='PEMemoryBlock'/>
        /// </summary>
        /// <param name="src">The origin</param>
        [Op]
        public static CliDataSource source(PEMemoryBlock src)
            => new CliDataSource(src);

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

        [MethodImpl(Inline), Op]
        public static uint row(Type src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(MethodInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(EventInfo src)
            => u32(src.MetadataToken) & 0xFFFFFF;

        [MethodImpl(Inline), Op]
        public static uint row(EntityHandle src)
            => uint32(src) & 0xFFFFFF;

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
            => Mdv.run(src.Name, dst.Name);

        /// <summary>
        /// Unpacks a compressed integer in blob storage and returns the number of bytes consumed
        /// </summary>
        /// <param name="src">The data source</param>
        /// <param name="dst">The data target</param>
        /// <remarks>Algorithm taken from https://github.com/microsoft/winmd/src/impl/winmd_reader/signature.h</remarks>
        [MethodImpl(Inline), Op]
        public static byte unpack(in byte src, out uint dst)
        {
            dst = default;
            var length = z8;
            if((src & 0x80) == 0)
            {
                length = 1;
                dst = src;
            }
            else if((src & 0xC0) == 0x80)
            {
                length = 2;
                dst = sll(and(skip(src,0), 0x3f), 8);
                dst |= skip(src, 1);
            }
            else if((src & 0xE0) == 0xC0)
            {
                length = 4;
                dst = sll(and(skip(src,0), 0x1f), 24);
                dst |= sll(skip(src, 1), 16);
                dst |= sll(skip(src, 2), 8);
                dst |= skip(src, 3);
            }

            return length;
        }

    }

    [ApiHost]
    public static partial class XCmd
    {

    }
}