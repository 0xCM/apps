//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmd
    {
        [CmdOp("project/mcasm")]
        Outcome McAsmDocs(CmdArgs args)
        {
            var project = Project();
            var catalog = WsCatalog.load(project);
            var files = catalog.Entries(FileKind.McAsm);
            var docs = ProjectSvc.CalcMcAsmDocs(project);
            var count = docs.Count;
            for(var i=0; i<count; i++)
                MergeDirectives(docs[i]);
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