//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitBlobs(IApiPack dst)
            => iter(ApiMd.Components, c => EmitBlobs(c, dst.Metadata(CliSections.Blobs).PrefixedTable<CliBlob>(c.GetSimpleName())), true);

        public void EmitBlobs(Assembly src, FS.FilePath dst)
        {
            var flow = EmittingTable<CliBlob>(dst);
            var reader = CliReader.create(src);
            var blobs = reader.ReadBlobs();
            using var writer = dst.Writer();
            var formatter = Tables.formatter<CliBlob>(16);
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<blobs.Length; i++)
                writer.WriteLine(formatter.Format(skip(blobs,i)));
            EmittedTable(flow, blobs.Length);
        }
    }
}