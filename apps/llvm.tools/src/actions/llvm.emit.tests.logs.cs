//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/tests/logs")]
        void EmitTestLogs()
        {
            const string LlvmId = "llvm";
            const string ClangId = "clang";
            var src = new string[]
            {
                "clang",
                "llvm",
                "lldb",
                "lld",
                "mlir",
                "polly"
            };
            core.iter(src,EmitTestLogs,true);
        }

        void EmitTestLogs(string id)
        {
            var logs = LlvmTests.logs(FS.dir(@"J:\llvm\toolset\logs") + FS.file(id + "-tests-detail", FS.Json));
            AppSvc.TableEmit(logs, Paths.Table<LlvmTestLogEntry>("llvm.tests.logs." + id + ".detail"));
        }
    }
}