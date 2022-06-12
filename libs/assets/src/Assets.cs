//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO;
    using System.Text;

    using static core;

    [ApiHost("asset.services")]
    public sealed partial class Assets : AppService<Assets>
    {
        const NumericKind Closure = UnsignedInts;

        AppDb AppDb => Wf.AppDb();

        AppSvcOps AppSvc => Wf.AppSvc();

        IDbTargets AssetTargets => AppDb.ApiTargets("assets");

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
    }
}