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

        WsEventReceiver EventReceiver;

        public ProjectCollector()
        {
            Clear();
        }

        void Clear()
        {
            EventReceiver = new();
        }

        public ProjectCollection Collect(IProjectWs project)
        {
            var receiver = new AsmStatsCollector();
            var collection = Collect(project, receiver);
            var stats = receiver.Stats();
            var dst = ProjectDb.ProjectTable<AsmStat>(project);
            TableEmit(stats.View, dst);
            return collection;

        }

        public ProjectCollection Collect(IProjectWs project, WsEventReceiver receiver)
        {
            Clear();
            if(receiver != null)
                EventReceiver = receiver;

            var context = Projects.Context(project, EventReceiver);
            var catalog = Projects.EmitCatalog(context);
            EventReceiver.Initialized(context);
            var objblocks = ObjDump.Collect(context);
            var objsyms = Nm.Collect(context);
            var symindex = Coff.Collect(context);
            var asmindex = Mc.Collect(context);

            XedDisasm.Collect(context);

            return new ProjectCollection{
                Files = catalog,
                ObjBlockData = objblocks,
                ObjSyms = objsyms,
                SymIndex = symindex,
                AsmIndex = asmindex
            };
        }
    }
}