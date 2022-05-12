//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedDumpImporter;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("xed/import")]
        Outcome RunImport(CmdArgs args)
        {
            ImportXedDump();
            return true;
        }

        void ImportXedDump()
        {
            var src = AppDb.Sources("intel").Path("xed-dump",FileKind.Txt);
            XedDumpImporter.blocks(src, new DumpBlockReceiver(AppSvc));

            void EmitLineMap()
            {
                var dst = XedPaths.Imports().Path("xed.dump.linemap", FileKind.Csv);
                var emitting = EmittingFile(dst);
                var map = XedDumpImporter.map(src, dst);
                EmittedFile(emitting,map.IntervalCount);
            }

            void EmitStats()
            {
                using var importer = new XedDumpImporter(src);
                var stats = importer.Run();
                Status(string.Format("Processed {0} bytes/{1} lines from {2}", (ByteSize)stats.InputSize, stats.LineCount, src.ToUri()));
            }
        }
    }
}