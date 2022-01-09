//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using System.IO;
    using static Root;

    using llvm;
    using Asm;

    partial class ProjectCmdProvider
    {
        [CmdOp("objdump/recode")]
        Outcome ShowObjDump(CmdArgs args)
        {
            var result = Outcome.Success;
            var project = Project();
            var src = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var rows = LlvmObjDump.LoadConsolidated(src);
            var count = rows.Length;
            var srcid = EmptyString;
            var block = EmptyString;
            var dstdir = ProjectDb.ProjectData(project,"objdump.recoded");
            var dstpath = FS.FilePath.Empty;
            var emitting = default(WfFileFlow);
            var lines = list<string>();
            var label = AsmLabel.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                var _srcid = FS.path(row.Source.WithoutLine.Format()).SrcId(WfFileKind.ObjAsm);

                if(empty(srcid))
                {
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, WfFileKind.Asm.Ext());
                    lines.Add(".intel_syntax noprefix");
                    emitting = EmittingFile(dstpath);
                }
                else if(srcid != _srcid)
                {
                    if(lines.Count != 0)
                    {
                        using var writer = dstpath.AsciWriter();
                        iter(lines, line => writer.WriteLine(line));
                        EmittedFile(emitting, lines.Count);
                    }
                    lines.Clear();
                    lines.Add(".intel_syntax noprefix");
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, WfFileKind.Asm.Ext());
                    EmittingFile(dstpath);
                }

                var _block = row.BlockName;
                if(empty(block) || block !=_block)
                {
                    if(nonempty(block))
                        lines.Add(EmptyString);
                    block = _block;
                    label = asm.label(block);
                    lines.Add(label.Format());
                    continue;
                }

                if(row.Asm.IsNonEmpty)
                    lines.Add(string.Format("    {0}", row.Asm));
            }

            if(lines.Count != 0)
            {
                using var writer = dstpath.AsciWriter();
                iter(lines, line => writer.WriteLine(line));
                EmittedFile(emitting, lines.Count);
            }

            return result;
        }
    }
}