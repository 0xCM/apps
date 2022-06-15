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
            var context = WsCmdFlows.context(project);
            AsmObjects.CollectObjects(context);
            AsmObjects.Emit(context, AsmObjects.CalcObjSyms(context));
            //AsmObjects.CollectObjSyms(context);
            AsmObjects.CollectCoffData(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
            XedDisasm.Collect(context);
        }
    }
}