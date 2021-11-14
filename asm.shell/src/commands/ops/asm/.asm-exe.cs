//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Diagnostics;

    partial class AsmCmdService
    {
        [CmdOp(".asm-exe")]
        Outcome AsmExe(CmdArgs args)
        {
            var result = Outcome.Success;
            var id = arg(args,0).Value;
            result = BuildAsmExe(id);
            if(result.Fail)
                return result;
            var exe = AsmWs.ExePath(id);

            var clock = Time.counter(true);
            var process = Process.Start(exe.Format());
            process.WaitForExit();
            var duration = clock.Elapsed();
            Write(string.Format("runtime:{0}", duration));
            return result;
        }
    }
}