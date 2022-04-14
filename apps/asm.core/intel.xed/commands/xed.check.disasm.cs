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
        [CmdOp("xed/check/disam")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var context = Projects.Context(Project());
            var files = context.Files(FileKind.XedRawDisasm);
            iter(files, file => {
                var target = XedDisasmTarget.create(this);
                var flow = XedDisasmFlow.init(context, target);
                flow.Run(file);
            });

            return true;
        }
    }
}