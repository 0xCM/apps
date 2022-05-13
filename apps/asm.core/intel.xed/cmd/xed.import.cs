//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        XedImport XedImport => Service(Wf.XedImport);

        [CmdOp("xed/import")]
        Outcome RunImport(CmdArgs args)
        {
            XedImport.Run();
            return true;
        }

        // void ImportXedDump()
        // {
        //     var src = AppDb.Sources("sources").Scoped("intel").Path("xed-dump",FileKind.Txt);
        //     InstBlockImporter.blocks(src, new InstBlockReceiver(AppSvc));

        //     void EmitLineMap()
        //     {
        //         var dst = XedPaths.Imports().Path("xed.dump.linemap", FileKind.Csv);
        //         var emitting = EmittingFile(dst);
        //         var map = InstBlockImporter.map(src, dst);
        //         EmittedFile(emitting,map.IntervalCount);
        //     }

        //     void EmitStats()
        //     {
        //         using var importer = new InstBlockImporter(src);
        //         var stats = importer.Run();
        //         Status(string.Format("Processed {0} bytes/{1} lines from {2}", (ByteSize)stats.InputSize, stats.LineCount, src.ToUri()));
        //     }
        // }
    }
}