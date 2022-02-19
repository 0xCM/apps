//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    public class ProjectManager : AppService<ProjectManager>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        WsProjects Projects => Service(Wf.WsProjects);

        CollectionEventReceiver EventReceiver;

        public ProjectManager()
        {
            Clear();
        }

        void Clear()
        {
            EventReceiver = new();
        }

        public void Collect(IProjectWs project, CollectionEventReceiver receiver = null)
        {
            Clear();
            if(receiver != null)
                EventReceiver = receiver;

            var context = CollectionContext.create(project, EventReceiver);
            Projects.EmitCatalog(context);
            EventReceiver.Initialized(context);
            ObjDump.Collect(context);
            Nm.Collect(context);
            Coff.Collect(context);
            Mc.Collect(context);
            XedDisasm.Collect(context);
        }


        void EmitCatalog(IProjectWs project, FileCatalog catalog)
        {
            var entries = catalog.Entries();
            TableEmit(entries.View, FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
        }
    }
}