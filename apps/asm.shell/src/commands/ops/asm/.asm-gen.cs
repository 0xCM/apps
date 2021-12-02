//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using Operands;

    using static core;
    using static ProjectScriptNames;

    partial class AsmCmdService
    {
        // [CmdOp(".asm-gen")]
        // Outcome AsmGen(CmdArgs args)
        // {
        //     var result = Outcome.Success;
        //     var project = Ws.Project("mc.models");
        //     var path = project.SrcFile("asm", "bsf", FileKind.Asm);
        //     using var writer = path.AsciWriter();
        //     r16 a = AsmRegOps.ax;
        //     r16 b = AsmRegOps.ax;
        //     writer.WriteLine("bsf_r16_r16:");
        //     for(var i=0; i<16; i++, a++)
        //     {
        //         for(var j=0; j<16; j++, b++)
        //         {
        //             if(i != j)
        //                 writer.WriteLine(AsmStatementPoc.bsf(a,b));
        //         }
        //     }

        //     RunProjectScript(project, path, McBuild);

        //     return result;
        // }

    }
}