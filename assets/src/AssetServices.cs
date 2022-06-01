//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public sealed class AssetServices : AppService<AssetServices>
    {

        public static string bytespan(BinaryResSpec src, int level = 2)
            => text.concat("public static ReadOnlySpan<byte> ",
            src.Identifier,
            Space,
            " => ",
            Space,
            $"new byte[{src.Encoded.Length}]",
            Chars.LBrace,
            src.Encoded.Format(HexFormatSpecs.HexArray),
            Chars.RBrace,
            Chars.Semicolon
            );

        public AssetServices()
        {
        }

        public void EmitTable<T>(string name, ReadOnlySpan<ListItem<T>> src, FS.FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(ListItem.HeaderText);
            for(var j=0; j<count; j++)
                writer.WriteLine(skip(src,j).Format());
            EmittedFile(emitting, count);
        }

        public void EmitAsset(Asset src, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            Utf8.decode(src.ResBytes, out var content);
            using var writer = dst.AsciWriter();
            writer.Write(content);
            EmittedFile(flow, content.Length);
        }

        public void EmitIndex<T>(Assets<T> assets, FS.FolderPath dir)
            where T : Assets<T>, new()
        {
            var host = assets.DataSource;
            var descriptors = assets.Descriptors;
            var count = descriptors.Length;
            var dst = Db.TableDir<AssetCatalogEntry>(dir) + Db.TableFile<AssetCatalogEntry>(host.GetSimpleName());
            var flow = Wf.EmittingTable<AssetCatalogEntry>(dst);
            using var writer = dst.Writer();
            var formatter = Tables.formatter<AssetCatalogEntry>(AssetCatalogEntry.RenderWidths);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var descriptor = ref skip(descriptors,i);
                var entry = descriptor.CatalogEntry;
                writer.WriteLine(formatter.Format(entry));
            }
            Wf.EmittedTable(flow,count);
        }
    }
}