//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectDataServices
    {
        public Index<AsmSyntaxRow> CollectAsmSyntax(WsContext context)
        {
            var project = context.Project;
            var logs = project.OutFiles(FileTypes.ext(FileKind.SynAsmLog)).View;
            var dst = Projects.AsmSyntaxTable(project);
            var count = logs.Length;
            var buffer = list<AsmSyntaxRow>();
            var tmp = list<AsmSyntaxRow>();
            var docs = dict<FS.FilePath,McAsmSyntaxDoc>();
            var seq = 0u;
            for(var i=0; i<count; i++)
            {
                tmp.Clear();
                ref readonly var path = ref skip(logs,i);
                CalcAsmSyntaxRows(context, context.FileRef(path), ref seq, tmp);
                docs[path] = new McAsmSyntaxDoc(path, tmp.ToArray());
                buffer.AddRange(tmp);
            }
            var rows = buffer.ToArray();
            TableEmit(@readonly(rows), AsmSyntaxRow.RenderWidths, dst);
            context.Receiver.Collected(rows);
            return rows;
        }
    }
}