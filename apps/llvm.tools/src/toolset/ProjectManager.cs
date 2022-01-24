//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    using System.Collections.Generic;
    using Asm;

    public class ProjectManager : AppService<ProjectManager>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        ProjectEventReceiver EventReceiver;

        public ProjectManager()
        {
            Clear();
        }

        void Clear()
        {
            EventReceiver = new();
        }

        public void Collect(IProjectWs project, ProjectEventReceiver receiver = null)
        {
            Clear();
            if(receiver != null)
                EventReceiver = receiver;

            var collect = new ProjectCollection(project, CatalogFiles(project), EventReceiver);
            EventReceiver.Initialized(collect);
            ObjDump.Collect(collect);
            Nm.Collect(collect);
            Coff.Collect(collect);
            Mc.Collect(collect);
            XedDisasm.Collect(collect);
        }

        public FileCatalog CatalogFiles(IProjectWs project, bool emit = true)
        {
            var catalog = FileCatalog.load(project);
            var entries = catalog.Entries();
            if(emit)
                TableEmit(entries.View, FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
            return catalog;
        }
    }
}