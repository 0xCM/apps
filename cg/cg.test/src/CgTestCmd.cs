//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using llvm;
    using Asm;
    using static core;

    public sealed partial class CgTestCmd : AppCmdService<CgTestCmd>
    {
        StringTableChecks LlvmStringTableChecks => Service(() => StringTableChecks.create(Wf));

        AsmWriterChecks AsmChecks => Service(() => AsmWriterChecks.create(Wf));

        [CmdOp("build/check")]
        void CheckMsBuild()
        {
            var src = FS.path(@"D:\Drives\Z\dev\z0\cg\cg.test\z0.cg.test.csproj");
            var project = MsBuild.project(src);
            Write(project.Format());
        }

        [CmdOp("cg/asm/check")]
        Outcome CheckAsm(CmdArgs args)
        {
            AsmChecks.Run();
            return true;
        }

        [CmdOp("cg/asm/bytes")]
        Outcome CheckAsmBytes(CmdArgs args)
        {
            var dst = text.emitter();
            AsmChecks.CheckAsmBytes(dst);
            Write(dst.Emit());
            return true;
        }

        [CmdOp("cg/asm/check/strings")]
        Outcome CheckStringTables(CmdArgs args)
        {
            LlvmStringTableChecks.Run();
            var strings = AsmSigST.Strings;
            var count = AsmSigST.EntryCount;
            for(var i=0; i<count; i++)
            {
                var kind = (AsmFormKind)i;
                Write(string.Format("{0,-32} | {1}", kind, text.format(strings.Cells(kind))));
            }

            return true;
        }
    }
}
