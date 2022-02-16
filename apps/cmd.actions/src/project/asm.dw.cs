//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmdProvider
    {
        Outcome AsmDw(CmdArgs args)
        {
            //var src = ObjDump.LoadRows()
            var project = Project();
            var path = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var src = ObjDump.LoadRows(path);
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];

            }


            return true;
        }
    }
}