//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedOperands;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/disasm/check")]
        Outcome DisasmCheck(CmdArgs args)
        {
            var context = Context();
            var files = XedDisasm.datafiles(context);
            iter(files, file => Write($"Loaded {file.Source}"));
            iter(files, file => Check(file),true);

            return true;
        }

        void Check(in DataFile src)
        {
            var context = Context();
            var project = context.Project;
            var states = XedDisasm.states(src,true);
            Write($"Parsed {states.Count} instructions from {src.Source}");
            var path = XedPaths.DisasmTarget(project, src.Origin.Path.FileName.WithoutExtension.Format(), FS.ext("states.csv"));

            TableEmit(states.Entries.Select(x => x.State).View, path);
        }

    }
}