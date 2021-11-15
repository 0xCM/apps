//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    partial class LlvmCmd
    {
        [CmdOp(".test")]
        Outcome Test(CmdArgs args)
        {
            var result = Outcome.Success;

            var input = "a -> b -> c -> d";
            var output = LlvmTypes.dag(input);
            Write(output.Format());
            return result;
        }

        [CmdOp(".test-logs")]
        Outcome ReadJson(CmdArgs args)
        {
            var result = Outcome.Success;
            var entries = LlvmTests.TestLog(FS.path(@"J:\llvm\toolset\logs\llvm-tests-detail.json"));
            Write(string.Format("Parsed {0} entries", entries.Length));
            return result;
        }

        [CmdOp(".test-union")]
        Outcome TestUnion(CmdArgs args)
        {
            var result = Outcome.Success;

            var x = Lang.c.union.instance<uint,ulong>();
            x.store(32ul);
            Write(x.ToString());

            x.store(321u);
            Write(x.ToString());

            return result;
        }
    }
}