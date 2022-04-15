//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static XedDisasm;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var context = Projects.Context(Project());
            DisasmFlow.run(context, this);
            // var files = context.Files(FileKind.XedRawDisasm);
            // iter(files, file => {
            //     var target = DisasmTarget.create(this);
            //     var flow = DisasmFlow.init(context, target);
            //     flow.Run(file);
            // },true);

            return true;
        }
    }
}