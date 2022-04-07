//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("project/collect")]
        Outcome Collect(CmdArgs args)
        {
            var project = Project();
            var data = ProjectData.Collect(project);
            return true;
        }

        void MergeDirectives(in McAsmDoc src)
        {
            var lines = src.DocLines;
            var directives = src.Directives;
            var numbers = src.DocLines.Keys.ToArray().Sort();
            var count = numbers.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var number = ref skip(numbers,i);
                var line = lines[number];
                if(directives.Find(number, out var directive))
                {
                    Write(string.Format("{0,-8} {1}", number, directive.Format()));
                }
                else
                {

                }
            }
        }
    }
}