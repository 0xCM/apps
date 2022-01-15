//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ProjectCollector : AppService<ProjectCollector>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        public void Collect(IProjectWs project)
        {
            ObjDump.Consolidate(project);
            ObjDump.Recode(project);
            Nm.Collect(project);
            Coff.CollectObjHex(project);
            Coff.EmitSymbols(project);
            Mc.Collect(project);
            XedDisasm.Collect(project);
            var result = Correlate(project);
            if(result.Fail)
            {
                Error(result.Message);
            }
        }

        Outcome Correlate(IProjectWs project)
        {
            var encRows = Mc.LoadEncodings(project);
            var synRows = Mc.LoadSyntax(project);
            var instRows =Mc.LoadInstructions(project);
            var count = encRows.Count;
            if(synRows.Count != count)
                return (false, string.Format("Row count mismatch"));

            if(instRows.Count != count)
                return (false, string.Format("Row count mismatch"));

            var buffer = alloc<AsmDocCorrelation>(count);

            for(var i=0; i<count; i++)
            {
                ref readonly var enc = ref encRows[i];
                ref readonly var syn = ref synRows[i];
                ref readonly var inst = ref instRows[i];

                ref readonly var seq = ref enc.Seq;

                if(syn.Seq != seq)
                    return (false, string.Format("Seq mismatch on row {0}", i));
                if(inst.Seq != seq)
                    return (false, string.Format("Seq mismatch on row {0}", i));

                ref var dst = ref seek(buffer,i);
                dst.Seq = seq;
                dst.DocSeq = enc.DocSeq;
                dst.SrcId = enc.SrcId;
                dst.IP = enc.IP;
                dst.AsmId = inst.AsmId;
                dst.Asm = enc.Asm;
                dst.Syntax = syn.Syntax;
                dst.Size = enc.Size;
                dst.HexCode = enc.HexCode;
                dst.Source = enc.Source;
            }

            TableEmit(@readonly(buffer), AsmDocCorrelation.RenderWidths, CorrelationTable(project));
            return true;
        }

       FS.FilePath CorrelationTable(IProjectWs project)
            => ProjectDb.ProjectTable<AsmDocCorrelation>(project);
    }
}