//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedDisasm;
    using static XedRules;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/disasm")]
        Outcome CheckDisasm(CmdArgs args)
        {
            var context = Context();
            // var files = context.Files(FileKind.XedRawDisasm).Sort();
            // var target = DisasmTarget.create(this, context);
            // for(var i=0; i<files.Count; i++)
            // {
            //     XedDisasm.check(context, files[i], target);
            // }
            DisasmFlow.run(this, context);
            return true;
        }

    }
}