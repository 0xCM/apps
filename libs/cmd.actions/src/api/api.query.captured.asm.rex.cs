//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class ApiCmd
    {
        [CmdOp("api/query/captured/asm/rex")]
        Outcome AsmQueryRex(CmdArgs args)
        {
            var result = Outcome.Success;
            const string qid = "process-asm.rex";
            var counter = 0u;
            var src = ProcessAsm().View;
            var buffer = ProcessAsmBuffer().Edit;
            buffer.Clear();
            var i = 0u;
            var count = AsmPrefixTests.rex(src, ref i, buffer);
            var filtered = slice(buffer,0,count);
            var dst = ProjectDb.Subdir("api/queries") + FS.file("asm.rex", FS.Csv);
            AppSvc.TableEmit(@readonly(filtered), dst);
            return result;
        }
    }
}