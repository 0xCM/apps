//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectSvc
    {
        public void Etl(IWsProject project, bool pll)
        {
            var context = WsContext.load(project);
            AsmObjects.CollectObjects(context, pll);
            AsmObjects.Emit(context, AsmObjects.CalcObjSyms(context));
            AsmObjects.CollectCoffData(context);
            CollectAsmSyntax(context);
            CollectMcInstructions(context);
            //XedDisasm.Collect(context);
        }
    }
}