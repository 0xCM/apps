//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class ProjectCollector : AppService<ProjectCollector>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        WsProjects Projects => Service(Wf.WsProjects);

        AsmCodeMaps AsmCodeMaps => Service(Wf.AsmCodeMaps);

        public ProjectCollector()
        {
        }

        public void Collect(IProjectWs project)
        {
            var receiver = new AsmStatsCollector();
            Collect(project, receiver);
            var stats = receiver.Stats();
            var dst = ProjectDb.ProjectTable<AsmStat>(project);
            TableEmit(stats.View, dst);
        }

        void Collect(IProjectWs project, WsEventReceiver receiver)
        {
            var context = Projects.Context(project, receiver);
            var catalog = Projects.EmitCatalog(context);
            receiver.Initialized(context);
            var objblocks = ObjDump.Collect(context);
            var objsyms = Nm.Collect(context);
            var symindex = Coff.Collect(context);
            Mc.Collect(context);

            XedDisasm.Collect(context);
            AsmCodeMaps.MapCode(context);
        }
    }
}