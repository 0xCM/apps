//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using Asm;

    using static core;

    using SQ = SymbolicQuery;

    partial class LlvmCmd
    {
        const string XedDisasm = "xed/disasm";

        XedDisasmSvc Xed => Service(Wf.XedDisasm);


        [CmdOp(XedDisasm)]
        Outcome ExecXedDisasm(CmdArgs args)
        {
            var project = Project();
            var paths = ProjectCollector.XedDisasmFiles(project);
            var src = Xed.ParseEncodings(paths);
            var count = paths.Length;
            var dst = ProjectDb.ProjectData() + FS.file(string.Format("xed.disasm.{0}", project.Project), FS.Csv);
            TableEmit(src.View, AsmStatementEncoding.RenderWidths, dst);
            return true;
        }
    }
}