//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;
    using static TaggedLiterals;

    public sealed partial class Assets : AppService<Assets>
    {
        const NumericKind Closure = UnsignedInts;

        AppDb AppDb => Wf.AppDb();

        AppSvcOps AppSvc => Wf.AppSvc();

        DbTargets AssetTargets => AppDb.ApiTargets("assets");

        [MethodImpl(Inline), Op]
        public static string utf8(in Asset src)
            => Encoding.UTF8.GetString(view(src));

        /// <summary>
        /// Reveals the data represented by a <see cref='Asset'/>
        /// </summary>
        /// <param name="src">The source descriptor</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset src)
            => core.view(src.Address, src.Size);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<T> view<T>(in Asset<T> id)
            where T : unmanaged
                => core.view<T>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset<byte> id)
            => core.view<byte>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> view(in Asset<char> id)
            => core.view<char>(id.Address, id.CellCount);

        [MethodImpl(Inline), Op]
        public unsafe static ReadOnlySpan<char> view(in Asset<char> res, uint i0, uint i1)
            => core.section((char*)res.Address, i0, i1);

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<byte> view(in Asset<byte> res, uint i0, uint i1)
            => core.view<byte>(res.Address, (i1 - i0 + 1));

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<char> view(in StringResRow src)
            => core.view<char>(src.Address, src.Length);

        [Op]
        public static Index<StringRes> strings(Type src)
        {
            var values = ClrLiterals.values<string>(src);
            var count = values.Count;
            var buffer = alloc<StringRes>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref values[i];
                seek(dst,i) = new(fv.Left, fv.Right);
            }
            return buffer;
        }

        [Op, Closures(Closure)]
        public static Index<StringRes<T>> strings<T>(Type src)
            where T : unmanaged
        {
            var values = ClrLiterals.values<string>(src);
            var count = values.Count;
            var buffer = alloc<StringRes<T>>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref values[i];
                seek(dst,i) = Assets.@string(@as<uint,T>(i), fv.Right, (uint)fv.Right.Length*2);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static StringRes<E> @string<E>(E id, StringAddress address, ByteSize size)
            where E : unmanaged
                => new StringRes<E>(id, address, size);

        [MethodImpl(Inline), Op]
        public static BinaryAsset binary(Assembly owner, string id, ReadOnlySpan<byte> src)
            => new BinaryAsset(owner, id, src.Length, core.address(src));

        [MethodImpl(Inline), Op]
        public static BinaryAsset binary(Assembly owner, string id, ByteSize size, MemoryAddress address)
            => new BinaryAsset(owner, id, size, address);

        [MethodImpl(Inline), Op]
        public unsafe static StringResRow row(in StringRes src)
        {
            var dst = new StringResRow();
            dst.Id = src.Source.MetadataToken;
            dst.Address = src.Value;
            dst.Length = (uint)src.Value.Length;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<StringResRow> rows(ReadOnlySpan<StringRes> src)
            => src.Select(r => row(r));

        [MethodImpl(Inline), Op]
        public static AssetCatalogEntry entry(in Asset src)
        {
            AssetCatalogEntry dst = new();
            dst.BaseAddress = src.Address;
            dst.Name = src.Name;
            dst.Size = src.Size;
            return dst;
        }

        /// <summary>
        /// Defines a <see cref='Asset'/>
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <param name="address">The memory location at which the resource content begins</param>
        /// <param name="size">The size of the resource, in bytes</param>
        [MethodImpl(Inline), Op]
        public static Asset descriptor(string name, MemoryAddress address, ByteSize size)
            => new Asset(name, address, size);

        [Op]
        public static string[] names(Assembly src, string match)
            => core.nonempty(match) ? src.ManifestResourceNames().Where(n => n.Contains(match)) : src.ManifestResourceNames();

        [MethodImpl(Inline), Op]
        public static Index<string> names(Assembly src)
            => src.GetManifestResourceNames();

        [Op]
        public static unsafe Index<Asset> collect(Assembly src, string match = null)
        {
            require(src != null, () => "Argument NULL");
            var resnames = @readonly(names(src, match));
            var count = resnames.Length;
            if(count == 0)
                return sys.empty<Asset>();

            var buffer = alloc<Asset>(count);
            var target = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref skip(resnames, i);
                var stream = (UnmanagedMemoryStream)src.GetManifestResourceStream(name);
                seek(target,i) = descriptor(name, stream.PositionPointer, (uint)stream.Length);
            }
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static Index<ComponentAssets> descriptors(ReadOnlySpan<Assembly> src)
        {
            var dst = list<ComponentAssets>();
            iter(src, component => dst.Add(descriptors(component)));
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ComponentAssets descriptors(Assembly src, string match)
            => new ComponentAssets(src, collect(src, match));

        [MethodImpl(Inline), Op]
        public static ComponentAssets descriptors(Assembly src)
            => new ComponentAssets(src, collect(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static unsafe ReadOnlySpan<T> extract<T>(in ResMember member, uint i0, uint i1)
            where T : unmanaged
                => section(member.Address.Pointer<T>(), i0, i1);

        [Op]
        static unsafe Index<Asset> collect(Assembly src)
        {
            var resnames = @readonly(src.GetManifestResourceNames());
            var count = resnames.Length;
            if(count == 0)
                return array<Asset>();

            var buffer = alloc<Asset>(count);
            var target = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var name = ref skip(resnames, i);
                var stream = (UnmanagedMemoryStream)src.GetManifestResourceStream(name);
                seek(target,i) = Assets.descriptor(name, stream.PositionPointer, (uint)stream.Length);
            }
            return buffer;
        }

        public static Outcome<Count> structured(Asset src, string delimiter, ReadOnlySpan<byte> widths, FS.FilePath dst)
        {
            var data = text.utf8(src.Bytes());
            var result = TextGrids.parse(data, out var doc);
            if(result.Fail)
                return result;

            return TextGrids.normalize(data, delimiter, widths, dst);
        }

        public static bool resource(in Asset src, TextDocFormat format, out TextGrid dst)
        {
            var content = utf8(src);
            using var stream = content.Stream();
            using var reader = new StreamReader(stream);
            var result = TextGrids.parse(reader, format);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = TextGrid.Empty;
                return false;
            }
        }

        public static bool structured(in Asset src, out TextGrid dst)
        {
            var content = utf8(src);
            using var stream = content.Stream();
            using var reader = new StreamReader(stream);
            var result = TextGrids.parse(reader, TextDocFormat.Structured());
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = TextGrid.Empty;
                return false;
            }
        }

        static Index<DocLibEntry> entries(Assembly src)
        {
            var names = @readonly(src.GetManifestResourceNames());
            var count = names.Length;
            var buffer = alloc<DocLibEntry>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst,i) =new DocLibEntry(skip(names,i), Path.GetExtension(skip(names,i)));
            return buffer;
        }

        public ResEmission EmitData(in Asset src, FS.FolderPath dir)
        {
            var dst = dir + src.FileName;
            AppSvc.FileEmit(utf8(src), dst, TextEncodingKind.Utf8);
            return flows.arrow(src,dst);
        }


    }
}