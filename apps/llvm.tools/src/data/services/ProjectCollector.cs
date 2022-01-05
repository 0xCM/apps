//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static llvm.LlvmNames;
    using static core;

    public class ProjectCollector : AppService<ProjectCollector>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffObjects Coff => Service(Wf.CoffObjects);

        public void Collect()
        {
            iter(Projects.ProjectNames, name => Collect(Ws.Project(name)));
        }

        public void Collect(IProjectWs project)
        {
            var result = ObjDump.Consolidate(project);
            if(result)
            {

            }

            Nm.Collect(project);
            Coff.CollectObjHex(project);
            Mc.Collect(project);
            XedDisasm.Collect(project);
        }
    }
}