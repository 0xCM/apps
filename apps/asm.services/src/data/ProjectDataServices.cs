//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public partial class ProjectDataServices : AppService<ProjectDataServices>
    {
        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        WsProjects Projects => Service(Wf.WsProjects);

        AsmObjects AsmObjects => Service(Wf.AsmObjects);

        Symbols<ObjSymCode> SymCodes;

        Symbols<ObjSymKind> SymKinds;

        public ProjectDataServices()
        {
            SymCodes = Symbols.index<ObjSymCode>();
            SymKinds = Symbols.index<ObjSymKind>();
        }

        public void Collect(IProjectWs project)
        {
            var receiver = new AsmStatsCollector();
            var context = Projects.Context(project, receiver);
            var catalog = Projects.EmitCatalog(context);
            receiver.Initialized(context);
            var objblocks = CollectObjDump(context);
            var objsyms = CollectObjSyms(context);
            var coffsyms = Coff.Collect(context);
            CollectMc(context);
            var xeddisasm = CollectXedDisasm(context);
            MapAsmCode(context);
            var stats = receiver.Stats();
            var dst = ProjectDb.ProjectTable<AsmStat>(project);
            TableEmit(stats.View, dst);
        }
   }
}