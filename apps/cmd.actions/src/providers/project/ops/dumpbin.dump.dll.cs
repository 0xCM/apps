//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using llvm;
    using Asm;

    partial class ProjectCmdProvider
    {
        [CmdOp("dumpbin/dump/dll")]
        Outcome DumpDll(CmdArgs args)
            => DumpBin.DumpModules(Project(), FileModuleKind.Dll);

        [CmdOp("llvm/objdump/consolidated")]
        Outcome ShowObjDump(CmdArgs args)
        {
            var result = Outcome.Success;
            var project = Project();
            var tool = Wf.LlvmObjDump();
            var src = ProjectDb.TablePath<ObjDumpRow>("projects", project.Name);
            var rows = tool.LoadConsolidated(src).View;
            var count = rows.Length;
            var buffer = alloc<IAsmStatementEncoding>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = skip(rows,i);

            var dst = src.ChangeExtension(FS.Asm);
            using var writer = dst.AsciWriter();
            using var allocation = AsmCodeAllocation.create(buffer);
            var allocated = allocation.Allocated;
            for(var i=0; i<allocated.Length; i++)
                writer.WriteLine(allocation[i].ToAsmString());
            return result;
        }
    }
}