//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    using System.Collections.Generic;
    using Asm;

    public class ProjectManager : AppService<ProjectManager>
    {
        llvm.LlvmNmSvc Nm => Service(Wf.LlvmNm);

        llvm.LlvmObjDumpSvc ObjDump => Service(Wf.LlvmObjDump);

        llvm.LlvmMcSvc Mc => Service(Wf.LlvmMc);

        XedDisasmSvc XedDisasm => Service(Wf.XedDisasm);

        CoffServices Coff => Service(Wf.CoffServices);

        ProjectFlows ProjectFlows => Service(Wf.ProjectFlows);

        List<ObjDumpRow> ObjDumpRows;

        ProjectEventReceiver EventReceiver;

        FileCatalog Files;

        ProjectCollection Collection;

        public ProjectManager()
        {
            Clear();
        }

        void Clear()
        {
            ObjDumpRows = new();
            Files = FileCatalog.create();
            EventReceiver = new();
        }

        public void Collect(IProjectWs project, ProjectEventReceiver receiver = null)
        {
            Clear();
            if(receiver != null)
                EventReceiver = receiver;

            Files = CatalogFiles(project);
            Collection = new ProjectCollection(project,Files, EventReceiver);
            var result = Outcome.Success;
            result = Consolidate(Collection);
            if(result.Fail)
                Error(result.Message);

            result = Recode(Collection);
            if(result.Fail)
                Error(result.Message);

            result = Nm.Collect(Collection);
            result = Coff.CollectObjHex(Collection);
            result = Coff.CollectSymbols(Collection);

            result = Coff.CollectObjHeaders(Collection);
            Mc.Collect(Collection);
            XedDisasm.Collect(Collection);

            IndexEncoding(Collection);
        }

        public FileCatalog CatalogFiles(IProjectWs project, bool emit = true)
        {
            var catalog = FileCatalog.create();
            catalog.Include(project);
            var entries = catalog.Entries();
            if(emit)
                TableEmit(entries.View, FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
            EventReceiver.FilesIndexed(catalog);
            return catalog;
        }

        // public FileIndex IndexFiles(IProjectWs project)
        // {
        //     var src = project.Files().Exclude(FS.Cmd);
        //     var matches = ProjectFlows.Match(src);
        //     var count = src.Count;
        //     var buffer = alloc<FileRef>(count);
        //     for(var i=0u; i<count; i++)
        //     {
        //         ref readonly var file = ref src[i];
        //         var hash = alg.hash.marvin(file.Format());
        //         ref readonly var kind = ref matches[i].Right;
        //         ref var dst = ref seek(buffer,i);
        //         dst = new FileRef(i, kind, hash, file);
        //         EventReceiver.Indexed(dst);
        //     }

        //     TableEmit(@readonly(buffer), FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
        //     EventReceiver.FilesIndexed(buffer);
        //     return buffer;
        // }

        Outcome IndexEncoding(ProjectCollection collect)
        {
            var src = ProjectDb.ProjectTable<ObjDumpRow>(collect.Project);
            var rows = ObjDump.LoadRows(src);
            using var allocation = AsmCodeAllocation.allocate(rows.View);
            var allocated = allocation.Allocated;
            var count = allocated.Length;
            var buffer = alloc<AsmCodeIndexRow>(count);
            for(var i=0; i<count; i++)
            {
                ref var dst = ref seek(buffer,i);
                ref readonly var code = ref skip(allocated,i);
                ref readonly var row = ref rows[i];
                if(code.HexCode != row.HexCode)
                {
                    Error("Hex mismatch");
                }

                dst.Seq = row.Seq;
                dst.DocId = row.DocId;
                dst.DocSeq = row.DocSeq;
                dst.CT = code.CT;
                dst.Asm = code.AsmText.Format();
                dst.Encoding = code.HexCode;
                dst.IP = (Address32)code.Offset;
                EventReceiver.Indexed(dst);
            }

            buffer.Sort();

            var path = ProjectDb.ProjectTable<AsmCodeIndexRow>(collect.Project);
            TableEmit(@readonly(buffer), AsmCodeIndexRow.RenderWidths, path);
            collect.EventReceiver.Emitted(buffer,path);
            return true;
        }

        Outcome Consolidate(ProjectCollection collect)
        {
            var project = collect.Project;
            var src = project.OutFiles(FileKind.ObjAsm).View;
            var dst = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var flow = EmittingTable<ObjDumpRow>(dst);
            var emitted = list<ObjDumpRow>();
            var total=0u;
            var seq = 0u;
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var fref = Files[path];
                result = ObjDump.ParseDumpSource(fref, out var records);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                var docseq = 0u;
                for(var j=0; j<records.Length; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    record.Seq = seq++;
                    ObjDumpRows.Add(record);
                    writer.WriteLine(formatter.Format(record));
                    emitted.Add(record);
                    collect.EventReceiver.Collected(fref, record);
                }
                total += docseq;
            }
            EmittedTable(flow, total);
            return true;
        }

        Outcome Recode(ProjectCollection collection)
        {
            const string intel_syntax = ".intel_syntax noprefix";
            var project = Ws.Project(ProjectNames.McRecoded);
            var rows = ObjDump.LoadRows(ProjectDb.ProjectTable<ObjDumpRow>(collection.Project));
            var count = rows.Length;
            var srcid = EmptyString;
            var block = EmptyString;
            var dstdir = project.SrcDir(collection.Project.Project.Format());
            var dstpath = FS.FilePath.Empty;
            var emitting = default(WfFileWritten);
            var lines = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                var path = (FS.FilePath)row.Source;
                var _srcid = path.SrcId(FileKind.ObjAsm);

                if(empty(srcid))
                {
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, FileKind.Asm.Ext());
                    lines.Add(intel_syntax);
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
                    lines.Add(intel_syntax);
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, FileKind.Asm.Ext());
                    EmittingFile(dstpath);
                }

                if(empty(block) || block != row.BlockName)
                {
                    if(nonempty(block))
                        lines.Add(EmptyString);

                    block = row.BlockName;
                    lines.Add(asm.label(block).Format());
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
            return true;
        }
    }
}