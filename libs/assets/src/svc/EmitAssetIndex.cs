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

    partial class Assets
    {
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
    }
}