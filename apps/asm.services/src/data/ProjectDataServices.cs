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

        public AsmDataCollection Collect(IProjectWs project)
        {
            var receiver = new AsmEventReceiver();
            var context = Projects.Context(project, receiver);
            Projects.EmitCatalog(context);
            receiver.Initialized(context);
            CollectObjDump(context);
            CollectObjSyms(context);
            Coff.Collect(context);
            CollectMc(context);
            CollectXedDisasm(context);
            //MapAsmCode(context);
            receiver.Emit();
            return receiver.Emit();
        }
   }
}