//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public record class ProjectCollection
    {
        public FileCatalog Files;

        public ObjDumpBlocks ObjBlockData;

        public Index<ObjSymRow> ObjSyms;

        public CoffSectionSyms SectionSyms;

        public Index<AsmCodeIndexRow> AsmIndex;

    }


    public class ProjectCollector : AppService<ProjectCollector>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        WsProjects Projects => Service(Wf.WsProjects);

        CollectionEventReceiver EventReceiver;

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

        public ProjectCollection Collect(IProjectWs project, CollectionEventReceiver receiver)
        {
            Clear();
            if(receiver != null)
                EventReceiver = receiver;

            var context = CollectionContext.create(project, EventReceiver);
            var catalog = Projects.EmitCatalog(context);
            EventReceiver.Initialized(context);
            var objblocks = ObjDump.Collect(context);
            var objsyms = Nm.Collect(context);
            var secsyms = Coff.Collect(context);
            var asmindex = Mc.Collect(context);

            XedDisasm.Collect(context);

            return new ProjectCollection{
                Files = catalog,
                ObjBlockData = objblocks,
                ObjSyms = objsyms,
                SectionSyms = secsyms,
                AsmIndex = asmindex
            };
        }
    }
}