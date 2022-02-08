//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/jmp32")]
        Outcome CheckJmp32(CmdArgs args)
        {
            var result = Outcome.Success;
            var cases = AsmCases.jmp32();
            var count = cases.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var expect = ref cases[i];
                var disp = AsmRel32.disp(expect.Encoding.Bytes);
                Require.equal(disp, expect.Disp);
                var source = expect.Source;
                Rip rip = (source, JmpRel32.InstSize);
                MemoryAddress target = (MemoryAddress)((long)rip + (int)disp);
                Require.equal(AsmRel32.disp(rip, target), disp);
                Require.equal(AsmRel32.target(rip, expect.Encoding.Bytes), target);
                var encoding = asm.jmp32(rip, target);
                Require.equal(encoding, expect.Encoding);
                var relTarget = (int)disp + (int)JmpRel32.InstSize;
                @string statement = string.Format("jmp near ptr {0:x}h", relTarget);
                Require.equal(statement, expect.Statment);
                Write(statement);
            }

            return true;
        }
    }
}