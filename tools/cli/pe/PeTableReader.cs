//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;
    using System.Reflection.Metadata.Ecma335;
    using System.IO;
    using System.Reflection.PortableExecutable;

    using static Root;
    using static core;
    using static PeRecords;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;
    using I = System.Reflection.Metadata.Ecma335.TableIndex;

    [Free, ApiHost]
    public class PeTableReader : IDisposable
    {
        [MethodImpl(Inline)]
        internal static ReadOnlySpan<R> empty<R>()
            => ReadOnlySpan<R>.Empty;

        readonly PeStream Stream;

        [MethodImpl(Inline)]
        internal PeTableReader(PeStream src)
            => Stream = src;

        public void Dispose()
            => Stream.Dispose();

        public static string UserString(MetadataReader reader, UserStringHandle handle)
            => reader.GetUserString(handle);

        internal static TableIndex? index(Handle handle)
        {
            if(MetadataTokens.TryGetTableIndex(handle.Kind, out var table))
                return table;
            else
                return null;
        }

        [MethodImpl(Inline), Op]
        internal static PeTableReader cover(PeStream src)
            => new PeTableReader(src);

        /// <summary>
        /// Allocates a <see cref='PeTableReader'/> for a specified file
        /// </summary>
        /// <param name="src">The source path</param>
        [Op]
        public static PeTableReader open(FS.FilePath src)
        {
            var stream = File.OpenRead(src.Name);
            var reader = new PEReader(stream);
            return cover(new PeStream(stream, reader));
        }

        [MethodImpl(Inline), Op]
        public static Address32 offset(MetadataReader reader, UserStringHandle handle)
            => (Address32)reader.GetHeapOffset(handle);

        public const string OffsetPatternText = "{0,-60} | {1,-16}";

        [MethodImpl(Inline)]
        static string[] labels(FieldOffset src)
            => typeof(FieldOffset).DeclaredInstanceFields().Select(x => x.Name);

        [MethodImpl(Inline)]
        static string format(FieldOffset src)
            => text.format(OffsetPatternText, src.Name, src.Value);

        [Op]
        public static void save(ReadOnlySpan<FieldOffset> src, FS.FilePath dst)
        {
            using var writer = dst.Writer();
            var l = labels(default(FieldOffset));
            writer.WriteLine(text.format(OffsetPatternText, l[0], l[1]));
            for(var i=0u; i<src.Length; i++)
                writer.WriteLine(format(skip(src,i)));
        }

        public ReadOnlySpan<ConstantFieldInfo> Constants(ref uint counter)
        {
            var reader = Stream.Reader;
            var count = ConstantCount(Stream);
            var dst = span<ConstantFieldInfo>(count);
            for(var i=1u; i<=count; i++)
            {
                var k = MetadataTokens.ConstantHandle((int)i);
                var entry = reader.GetConstant(k);
                var parent = PeReader.index(Stream, entry.Parent);
                var blob = reader.GetBlobBytes(entry.Value);
                ref var target = ref seek(dst, i - 1u);
                target.Sequence = counter++;
                target.ParentId = parent.Token;
                target.Source = parent.Table.ToString();
                target.DataType = entry.TypeCode;
                target.Content = blob;
            }
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static int ConstantCount(in PeStream state)
            => state.Reader.GetTableRowCount(I.Constant);

        public Index<CliSystemString> ReadSystemStringInfo()
        {
            var reader = Stream.Reader;
            int size = reader.GetHeapSize(HeapIndex.String);
            if (size == 0)
                return array<CliSystemString>();

            var values = list<CliSystemString>();
            var handle = MetadataTokens.StringHandle(0);
            var i=0;
            do
            {
                values.Add(new CliSystemString(seq: i++, size, (Address32)reader.GetHeapOffset(handle), reader.GetString(handle)));
                handle = reader.GetNextHandle(handle);
            }
            while (!handle.IsNil);

            return values.ToArray();
        }
    }
}