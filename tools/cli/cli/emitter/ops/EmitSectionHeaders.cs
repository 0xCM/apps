//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static PeRecords;

    partial class CliEmitter
    {
        static ReadOnlySpan<byte> SectionHeaderWidths
            => new byte[9]{60,16,16,12,12,60,16,16,16};

        public void EmitSectionHeaders()
        {
            EmitSectionHeaders(controller().RuntimeArchive(), Db.IndexRoot());
        }

        public void EmitSectionHeaders(FS.FolderPath dir)
        {
            EmitSectionHeaders(controller().RuntimeArchive(), dir);
        }

        public void EmitSectionHeaders(IRuntimeArchive src, FS.FolderPath dir)
        {
            var db = Wf.Db();
            EmitSectionHeaders(src.DllFiles.View, Tables.path<SectionHeaderInfo>(dir,"dll"));
            EmitSectionHeaders(src.ExeFiles.View, Tables.path<SectionHeaderInfo>(dir, "exe"));
        }

        public Outcome<Count> EmitSectionHeaders(ReadOnlySpan<FS.FilePath> src, FS.FilePath dst)
        {
            var total = Count.Zero;
            var formatter = Tables.formatter<SectionHeaderInfo>(SectionHeaderWidths);
            var flow = Wf.EmittingTable<SectionHeaderInfo>(dst);
            using var writer = dst.Writer();
            writer.WriteLine(formatter.FormatHeader());
            foreach(var file in src)
            {
                using var reader = PeReader.create(file);
                var headers = reader.ReadHeaderInfo();
                var count = headers.Length;
                for(var i=0u; i<count; i++)
                    writer.WriteLine(formatter.Format(skip(headers,i)));

                total += count;
            }
            Wf.EmittedTable(flow, total);

            return total;
        }
    }
}