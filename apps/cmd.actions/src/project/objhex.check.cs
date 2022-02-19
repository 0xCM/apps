//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    partial class ProjectCmdProvider
    {
        [CmdOp("check/objhex")]
        Outcome CheckObjHex(CmdArgs args)
        {

            var project = Project();

            var context = CollectionContext.create(project);
            var result = CoffServices.CheckObjHex(context);

            return result;

        }
    }
}