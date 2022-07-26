//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectSvc
    {
        public void Etl(IWsProject project)
        {
            var context = Flows.context(project);
            AsmObjects.RunEtl(context);
            XedDisasm.Collect(context);
        }
    }
}