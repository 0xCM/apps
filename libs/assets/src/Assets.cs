//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost("asset.services")]
    public sealed class Assets : AppService<Assets>
    {
        const NumericKind Closure = UnsignedInts;

        AppDb AppDb => Wf.AppDb();

        AppSvcOps AppSvc => Wf.AppSvc();

        IDbTargets AssetTargets => AppDb.ApiTargets("assets");

        [Op]
        public static ApiCodeRes code(string id, ReadOnlySpan<CodeBlock> src)
        {
            var count = src.Length;
            var buffer = alloc<BinaryResSpec>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = new BinaryResSpec(string.Format("{0}_{1}", id, i), skip(src,i));
            return new ApiCodeRes(buffer);
        }

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

        [MethodImpl(Inline), Op, Closures(Closure)]
        public unsafe static ResMember member<T>(MemberInfo member, ReadOnlySpan<T> src)
            => new ResMember(member, MemorySegs.define(recover<T,byte>(src)));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(FieldInfo field, uint size)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, size));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W8 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 1));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W16 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 2));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W32 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 4));

        [MethodImpl(Inline), Op]
        public unsafe static ResMember member(W64 w, FieldInfo field)
            => new ResMember(field, MemorySegs.define(field.FieldHandle.Value, 8));

        /// <summary>
        /// Defines a <see cref='Asset'/>
        /// </summary>
        /// <param name="name">The resource name</param>
        /// <param name="address">The memory location at which the resource content begins</param>
        /// <param name="size">The size of the resource, in bytes</param>
        [MethodImpl(Inline), Op]
        public static Asset asset(string name, MemoryAddress address, ByteSize size)
            => new Asset(name, address, size);

        [MethodImpl(Inline), Op]
        public static Index<ComponentAssets> assets(ReadOnlySpan<Assembly> src)
        {
            var dst = list<ComponentAssets>();
            iter(src, component => dst.Add(assets(component)));
            return dst.ToArray();
        }

        [MethodImpl(Inline), Op]
        public static ComponentAssets assets(Assembly src, string match)
            => new ComponentAssets(src, collect(src, match));

        [MethodImpl(Inline), Op]
        public static ComponentAssets assets(Assembly src)
            => new ComponentAssets(src, collect(src));

        [Op]
        public static Index<ResDocInfo> docs(Assembly src)
        {
            var names = src.GetManifestResourceNames().Index();
            var count = names.Length;
            var dst = alloc<ResDocInfo>(count);
            for(var i=0; i<count; i++)
                seek(dst,i) = new ResDocInfo(names[i]);
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static string utf8(in Asset src)
            => Encoding.UTF8.GetString(view(src));

        [MethodImpl(Inline), Op]
        public static BinaryAsset binary(Assembly owner, string id, ReadOnlySpan<byte> src)
            => new BinaryAsset(owner, id, src.Length, core.address(src));

        [MethodImpl(Inline), Op]
        public static BinaryAsset binary(Assembly owner, string id, ByteSize size, MemoryAddress address)
            => new BinaryAsset(owner, id, size, address);

        [MethodImpl(Inline), Op]
        public static AssetCatalogEntry entry(in Asset src)
        {
            AssetCatalogEntry dst = new();
            dst.BaseAddress = src.Address;
            dst.Name = src.Name;
            dst.Size = src.Size;
            return dst;
        }

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
                seek(target,i) = asset(name, stream.PositionPointer, (uint)stream.Length);
            }
            return buffer;
        }

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
                seek(target,i) = Assets.asset(name, stream.PositionPointer, (uint)stream.Length);
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


        public void EmitAssetIndex<T>(Assets<T> src, FS.FolderPath dir)
            where T : Assets<T>, new()
        {
            var descriptors = src.Data;
            var count = descriptors.Length;
            var dst = AppDb.ApiTargets("assets").Table<AssetCatalogEntry>(src.DataSource.GetSimpleName());
            var flow = EmittingTable<AssetCatalogEntry>(dst);
            using var writer = dst.Writer(TextEncodingKind.Utf8);
            var formatter = Tables.formatter<AssetCatalogEntry>();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(descriptors,i).CatalogEntry));
            EmittedTable(flow,count);
        }

        public ResEmission EmitData(in Asset src, FS.FolderPath dir)
        {
            var dst = dir + src.FileName;
            AppSvc.FileEmit(utf8(src), dst, TextEncodingKind.Utf8);
            return Graphs.connect(src,dst);
        }

        public Index<ResEmission> Run(EmitResDataCmd cmd)
            => EmitEmbedded(cmd.Source, cmd.Target, cmd.Match, cmd.ClearTarget);

        public Index<ResEmission> EmitEmbedded(Assembly src, FS.FolderPath root, utf8 match, bool clear)
        {
            var flow = Running(string.Format("Emitting resources embedded in {0}", src.GetSimpleName()));
            var descriptors = match.IsEmpty ? Assets.assets(src) : Assets.assets(src, match);
            var count = descriptors.Count;

            if(count == 0)
                return sys.empty<ResEmission>();

            var buffer = sys.alloc<ResEmission>(count);
            ref var emission = ref first(buffer);

            if(clear)
                root.Clear();

            var sources = descriptors.View;
            for(var i=0; i<count; i++)
                seek(emission,i) = EmitData(skip(sources,i), root);

            Ran(flow);
            return buffer;
        }

        public Index<ResEmission> EmitPartAssets()
        {
            var flow = Running("Emitting part assets");
            var src = Assets.assets(ApiRuntimeCatalog.Components).SelectMany(x => x);
            var dst = alloc<ResEmission>(src.Count);
            var counter = 0u;
            for(var i=0; i<src.Count; i++, counter++)
                @try(() => seek(dst,i) = EmitData(src[i], AssetTargets.Root), e => Error(e));
            Ran(flow, string.Format("Emitted <{0}> assets", counter));
            return dst;
        }
    }
}