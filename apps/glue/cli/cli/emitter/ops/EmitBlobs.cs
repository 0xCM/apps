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
            var flow = Running(nameof(EmitBlobs));
            ClearBlobs();
            foreach(var part in ApiRuntimeCatalog.Parts)
                EmitBlobs(part.Owner);
            Ran(flow);
        }

        public void ClearBlobs()
        {
            ProjectDb.Subdir(BlobScope).Clear();
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
            => EmitBlobs(FS.path(src.Location), ProjectDb.TablePath<CliBlob>(BlobScope, src.GetSimpleName()));
    }
}