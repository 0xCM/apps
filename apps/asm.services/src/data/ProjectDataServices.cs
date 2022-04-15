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

        public void Collect(IProjectProvider provider, IProjectWs project)
        {
            var context = Projects.Context(provider, project);
            CollectObjDump(context);
            CollectObjSyms(context);
            Coff.Collect(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
            XedDisasm.Collect(context);
        }
   }
}