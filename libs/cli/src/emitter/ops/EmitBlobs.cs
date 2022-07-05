//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        IDbTargets BlobTargets()
            => AppDb.ApiTargets("api.blobs");

        public void EmitBlobs()
        {
            BlobTargets().Clear();
            iter(ApiMd.Components, c => EmitBlobs(c),true);
        }

        public ExecToken EmitBlobs(FS.FilePath src, FS.FilePath dst)
        {
            var flow = EmittingTable<CliBlob>(dst);
            using var reader = PeReader.create(src);
            var rows = reader.ReadBlobInfo();
            var count = (uint)rows.Length;
            var formatter = Tables.formatter<CliBlob>(16);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));

            return EmittedTable<CliBlob>(flow, rows.Length);
        }

        public ExecToken EmitBlobs(Assembly src)
            => EmitBlobs(FS.path(src.Location), BlobTargets().Table<CliBlob>(src.GetSimpleName()));
    }
}