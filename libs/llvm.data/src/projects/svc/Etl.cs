//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectSvc
    {
        public void Etl(IProjectWs project)
        {
            var context = CmdFlows.context(project);
            AsmObjects.CollectObjects(context);
            AsmObjects.CollectObjSyms(context);
            AsmObjects.CollectCoffData(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
            XedDisasm.Collect(context);
        }
    }
}