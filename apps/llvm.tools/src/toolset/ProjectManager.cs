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

        Index<AsmDocCorrelation> Correlations;

        List<ObjDumpRow> ObjDumpRows;

        ProjectEventReceiver EventReceiver;

        FileIndex Files;

        ProjectCollection Collection;

        public ProjectManager()
        {
            Clear();
        }

        void Clear()
        {
            Correlations = sys.empty<AsmDocCorrelation>();
            ObjDumpRows = new();
            Files = new();
            EventReceiver = new();
        }

        public void Collect(IProjectWs project, ProjectEventReceiver receiver = null)
        {
            Clear();
            if(receiver != null)
                EventReceiver = receiver;

            Files = IndexFiles(project);
            Collection = new ProjectCollection(project,Files, EventReceiver);
            var result = Outcome.Success;
            result = Consolidate(Collection);
            if(result.Fail)
                Error(result.Message);

            result = Recode(Collection);
            if(result.Fail)
                Error(result.Message);

            result = Nm.Collect(Collection);
            Coff.CollectObjHex(Collection);
            Coff.CollectSymbols(Collection);
            Mc.Collect(Collection);
            XedDisasm.Collect(Collection);

            IndexEncoding(Collection);
        }

        public FileIndex IndexFiles(IProjectWs project)
        {
            var src = project.Files().Exclude(FS.Cmd);
            var matches = FileTypes.match(src);
            var count = src.Count;
            var buffer = alloc<FileRef>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var file = ref src[i];
                var hash = alg.hash.marvin(file.Format());
                ref readonly var kind = ref matches[i].Right;
                ref var dst = ref seek(buffer,i);
                dst = new FileRef(i, kind, hash, file);
                EventReceiver.FileIndexed(dst);
            }

            TableEmit(@readonly(buffer), FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
            EventReceiver.FilesIndexed(buffer);
            return buffer;
        }

        Outcome IndexEncoding(ProjectCollection collection)
        {
            var project = collection.Project;
            var src = ProjectDb.ProjectTable<ObjDumpRow>(project);
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
                dst.Offset = code.Offset;
                EventReceiver.CodeIndexed(dst);
            }

            TableEmit(@readonly(buffer), AsmCodeIndexRow.RenderWidths, ProjectDb.ProjectTable<AsmCodeIndexRow>(project));

            return true;
        }

        Outcome Consolidate(ProjectCollection collection)
        {
            var project = collection.Project;
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
                    //record.DocSeq = docseq++;
                    //record.DocId = fref.Seq;
                    ObjDumpRows.Add(record);
                    EventReceiver.Consolidated(fref,record);
                    writer.WriteLine(formatter.Format(record));
                    emitted.Add(record);
                }
                total += docseq;
            }
            EmittedTable(flow, total);
            return true;
        }

        Outcome Correlate(IProjectWs project)
        {
            var result = Outcome.Success;
            var encRows = Mc.LoadEncodings(project);
            var synRows = Mc.LoadSyntax(project);
            var instRows = Mc.LoadInstructions(project);
            var count = encRows.Count;
            if(synRows.Count != count)
                return (false, string.Format("Row count mismatch"));

            if(instRows.Count != count)
                return (false, string.Format("Row count mismatch"));

            Correlations = alloc<AsmDocCorrelation>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var enc = ref encRows[i];
                ref readonly var syn = ref synRows[i];
                ref readonly var inst = ref instRows[i];
                ref readonly var seq = ref enc.Seq;
                ref readonly var hex = ref enc.HexCode;

                if(syn.Seq != seq)
                {
                    result = (false, string.Format("Seq mismatch on row {0}", i));
                    break;
                }

                if(inst.Seq != seq)
                {
                    result = (false, string.Format("Seq mismatch on row {0}", i));
                    break;
                }

                ref var dst = ref Correlations[i];
                dst.Seq = seq;
                dst.DocId = enc.DocId;
                dst.DocSeq = enc.DocSeq;
                dst.SrcId = enc.SrcId;
                dst.IP = enc.IP;
                dst.AsmId = inst.AsmId;
                dst.Asm = enc.Asm;
                dst.Size = hex.Size;
                dst.HexCode = hex;
                dst.Syntax = syn.Syntax;
                dst.Source = enc.Source;

                if(result.Fail)
                    break;

                EventReceiver.Correlated(enc, syn, inst, dst);
            }

            if(result)
                TableEmit(Correlations.View, AsmDocCorrelation.RenderWidths, CorrelationTable(project));
            return result;
        }

        Outcome Recode(ProjectCollection collection)
        {
            var dstProject = Ws.Project(ProjectNames.McRecoded);
            var srcTable = ProjectDb.ProjectTable<ObjDumpRow>(collection.Project);
            var rows = ObjDump.LoadRows(srcTable);
            var count = rows.Length;
            var srcid = EmptyString;
            var block = EmptyString;
            var dstdir = dstProject.SrcDir(collection.Project.Project.Format());
            var dstpath = FS.FilePath.Empty;
            var emitting = default(WfFileWritten);
            var lines = list<string>();
            var label = AsmLabel.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                FS.FilePath path = (FS.FilePath)row.Source;
                var _srcid = path.SrcId(FileKind.ObjAsm);

                if(empty(srcid))
                {
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, FileKind.Asm.Ext());
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
                    dstpath = dstdir + FS.file(srcid, FileKind.Asm.Ext());
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
            return true;
        }

       FS.FilePath CorrelationTable(IProjectWs project)
            => ProjectDb.ProjectTable<AsmDocCorrelation>(project);
    }
}