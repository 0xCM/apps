//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        // {
        //     var result = Outcome.Success;
        //     var settings = Tooling.LoadSettings();
        //     var env = ToolEnv.load(settings);
        //     var dst = ProjectDb.Log("env", FS.Log);
        //     var emitting = EmittingFile(dst);

        //     using var writer = dst.AsciWriter();
        //     var headers = env.HeaderIncludes();
        //     writer.WriteLine("Header Includes");
        //     writer.WriteLine(RP.PageBreak120);
        //     iter(headers, h => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Header", h.Exists ? "Found" : "Mising", h)));
        //     writer.WriteLine();

        //     var libs = env.LibIncludes();
        //     writer.WriteLine("Lib Includes");
        //     writer.WriteLine(RP.PageBreak120);
        //     iter(libs, lib => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Lib", lib.Exists ? "Found" : "Mising", lib)));

        //     EmittedFile(emitting, 2);
        //     return result;
        // }
    }
}