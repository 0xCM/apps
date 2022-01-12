//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            Mc.Collect(project);
            XedDisasm.Collect(project);
        }
    }
}