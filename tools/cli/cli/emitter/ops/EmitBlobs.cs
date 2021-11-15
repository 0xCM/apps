//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Reflection;

    using static core;

    partial class CliEmitter
    {
        public void EmitBlobs()
        {
            var flow = Wf.Running();
            ClearBlobs();
            foreach(var part in Wf.ApiCatalog.Parts)
                EmitBlobs(part.Owner);
            Wf.Ran(flow);
        }

        public void ClearBlobs()
        {
            Wf.Db().TableDir<CliBlob>().Clear();
        }

        public ExecToken EmitBlobs(FS.FilePath src, FS.FilePath dst)
        {
            var flow = Wf.EmittingTable<CliBlob>(dst);
            using var reader = PeReader.create(src);

            var rows = reader.ReadBlobInfo();
            var count = (uint)rows.Length;
            var formatter = Tables.formatter<CliBlob>(16);

            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
                writer.WriteLine(formatter.Format(skip(rows,i)));

            return Wf.EmittedTable<CliBlob>(flow, rows.Length);
        }

        public ExecToken EmitBlobs(Assembly src)
            => EmitBlobs(FS.path(src.Location), Db.Table<CliBlob>(src.GetSimpleName()));
    }
}