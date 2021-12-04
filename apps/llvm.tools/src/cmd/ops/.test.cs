//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Types;

    partial class LlvmCmd
    {
        [CmdOp(".test")]
        Outcome Test(CmdArgs args)
        {
            var result = Outcome.Success;

            @string a = "a";
            @string b = "b";
            @string c = "c";
            @string d = "d";

            var dag0 = LlvmTypes.dag(a,b);
            var dag1 = LlvmTypes.dag(dag0,c);
            var dag2 = LlvmTypes.dag(dag1,d);
            var expr1 = dag2.Format();
            LlvmTypes.parse(expr1, out var dag3);
            var expr2 = dag3.Format();
            if(expr1 != expr2)
                result= (false,string.Format("{0} != {1}", expr1, expr2));
            else
                Write(expr2);
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