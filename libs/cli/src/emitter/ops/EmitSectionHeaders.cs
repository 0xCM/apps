//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CliEmitter
    {
        public void EmitSectionHeaders(IApiPack dst)
            => EmitSectionHeaders(controller().RuntimeArchive(), dst);

        public void EmitSectionHeaders(IRuntimeArchive src, IApiPack dst)
            => EmitSectionHeaders(src.Files(FileKind.Dll, FileKind.Exe, FileKind.Obj).Yield(), dst.Table<PeSectionHeader>());

        public void EmitSectionHeaders(ReadOnlySpan<FS.FilePath> src, FS.FilePath dst)
        {
            try
            {
                var total = Count.Zero;
                var formatter = Tables.formatter<PeSectionHeader>();
                var flow = EmittingTable<PeSectionHeader>(dst);
                using var writer = dst.AsciWriter();
                writer.WriteLine(formatter.FormatHeader());
                foreach(var file in src)
                {
                    using var reader = PeTables.open(file);
                    var headers = reader.Headers();
                    var count = headers.Length;
                    for(var i=0u; i<count; i++)
                        writer.WriteLine(formatter.Format(headers[i]));

                    total += count;
                }
                EmittedTable(flow, total);
            }
            catch(Exception e)
            {
                Error(e);
            }
        }
    }
}