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

        AsmEventReceiver EventReceiver;

        public ProjectManager()
        {
            ObjDumpRows = new();
            EventReceiver = new();
        }

        public void Collect(IProjectWs project, AsmEventReceiver receiver = null)
        {
            Correlations = sys.empty<AsmDocCorrelation>();
            ObjDumpRows.Clear();

            var handler = receiver ?? EventReceiver;

            var result = Outcome.Success;
            result = Consolidate(project, handler);
            if(result.Fail)
                Error(result.Message);

            result = Recode(project);
            if(result.Fail)
                Error(result.Message);

            result = Nm.Collect(project);
            Coff.CollectObjHex(project);
            Coff.EmitSymbols(project);
            Mc.Collect(project);
            XedDisasm.Collect(project);

            // result = Correlate(project, handler);
            // if(result.Fail)
            //     Error(result.Message);
        }

        public Outcome Consolidate(IProjectWs project, AsmEventReceiver receiver = null)
        {
            var handler = receiver ?? EventReceiver;
            var src = project.OutFiles(FileKind.ObjAsm).View;
            var dst = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var flow = EmittingTable<ObjDumpRow>(dst);
            var emitted = list<ObjDumpRow>();
            var total =0u;
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                result = ObjDump.ParseDumpSource(path, out var records);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                var counter = 0u;
                for(var j=0; j<records.Length; j++)
                {
                    ref var record = ref records[j];
                    if(record.IsBlockStart)
                        continue;

                    record.Seq = counter++;
                    ObjDumpRows.Add(record);
                    writer.WriteLine(formatter.Format(record));
                    emitted.Add(record);
                }
                total += counter;
            }
            EmittedTable(flow, total);
            return true;
        }

        public Outcome Correlate(IProjectWs project, AsmEventReceiver receiver = null)
        {
            var result = Outcome.Success;
            var handler = receiver ?? EventReceiver;
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

                handler.Correlated(enc,syn,inst,dst);
            }

            if(result)
                TableEmit(Correlations.View, AsmDocCorrelation.RenderWidths, CorrelationTable(project));
            return result;
        }

        public Outcome Recode(IProjectWs srcProject, AsmEventReceiver receiver = null)
        {
            var handler = receiver ?? EventReceiver;
            var dstProject = Ws.Project(ProjectNames.McRecoded);
            var srcTable = ProjectDb.ProjectTable<ObjDumpRow>(srcProject);
            var rows = ObjDump.LoadRows(srcTable);
            var count = rows.Length;
            var srcid = EmptyString;
            var block = EmptyString;
            var dstdir = dstProject.SrcDir(srcProject.Project.Format());
            var dstpath = FS.FilePath.Empty;
            var emitting = default(WfFileWritten);
            var lines = list<string>();
            var label = AsmLabel.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                var _srcid = FS.path(row.Source.WithoutLine.Format()).SrcId(FileKind.ObjAsm);

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