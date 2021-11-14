//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public sealed class AsmCsvService : AppService<AsmCsvService>
    {
        AsmDecoder Decoder;

        protected override void OnInit()
        {
            Decoder = Wf.AsmDecoder();
        }

        public ReadOnlySpan<HostAsmRecord> EmitStatements(ReadOnlySpan<ApiHostBlocks> src, FS.FolderPath root)
        {
            root.Delete();

            var count = src.Length;
            var flow = Wf.Running(string.Format("Emitting statements for {0} host block sets", count));
            var records = list<HostAsmRecord>();
            var buffer = list<HostAsmRecord>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                buffer.Clear();

                ref readonly var blocks = ref skip(src,i);
                if(blocks.Length == 0)
                    continue;

                counter += BuildHostStatements(blocks, buffer);

                var host = blocks.Host;
                EmitHostAsmDoc(host, buffer.ViewDeposited());
                EmitHostAsmRecords(host, buffer.ViewDeposited());
                records.AddRange(buffer);
            }

            Wf.Ran(flow, string.Format("Emitted {0} total statements", counter));
            return records.ViewDeposited();
        }

        public ReadOnlySpan<HostAsmRecord> EmitStatements(ReadOnlySpan<ApiCodeBlock> src, FS.FolderPath dst)
        {
            var count = src.Length;
            var buffer = list<HostAsmRecord>();
            for(var i=0; i<count; i++)
                ApiInstructions.statements(Decode(skip(src,i)), buffer);
            buffer.Sort();

            var statements = buffer.ViewDeposited();
            EmitStatements(statements, dst);
            return statements;
        }

        public void EmitStatements(ReadOnlySpan<AsmRoutine> src, ApiPackArchive dst)
        {
            var total = ApiInstructions.count(src);
            var running = Wf.Running(Msg.CreatingStatements.Format(total));
            var buffer = span<HostAsmRecord>(total);
            var count = src.Length;
            var offset = 0u;
            for(var i=0; i<count; i++)
                offset += ApiInstructions.statements(skip(src,i), slice(buffer, offset));
            Wf.Ran(running, Msg.CreatedStatements.Format(total));
            EmitStatements(buffer, dst.RootDir());
        }

        public void EmitStatements(ReadOnlySpan<HostAsmRecord> src, FS.FolderPath root)
        {
            ClearTarget();

            var thumbprints = hashset<AsmThumbprint>();
            var formatter = Tables.formatter<HostAsmRecord>(HostAsmRecord.RenderWidths);
            var statements = src;
            var count = statements.Length;
            var host = ApiHostUri.Empty;
            var counter = 0u;
            var tableWriter = default(StreamWriter);
            var tablePath = FS.FilePath.Empty;
            var tableFlow = default(WfTableFlow<HostAsmRecord>);
            var asmWriter = default(StreamWriter);
            var asmPath = FS.FilePath.Empty;
            var asmFlow = default(WfFileFlow);
            var buffer = text.buffer();

            for(var i=0; i<count; i++)
            {
                ref readonly var statement = ref skip(statements,i);
                if(statement.IsValid())
                    thumbprints.Add(asm.thumbprint(statement));

                var uri = statement.OpUri;
                if(i == 0)
                {
                    host = uri.Host;
                    tablePath = AsmTablePath(host, root);
                    tableWriter = tablePath.Writer();
                    tableWriter.WriteLine(formatter.FormatHeader());

                    tableFlow = Wf.EmittingTable<HostAsmRecord>(tablePath);
                    asmPath = AsmSrcPath(host, root);
                    asmWriter = asmPath.Writer();
                    asmFlow = Wf.EmittingFile(asmPath);
                }

                if(uri.Host != host)
                {
                    tableWriter.Dispose();
                    Wf.EmittedTable<HostAsmRecord>(tableFlow, counter);

                    asmWriter.Dispose();
                    Wf.EmittedFile(asmFlow, counter);

                    host = statement.OpUri.Host;
                    tablePath = Db.AsmStatementPath(root, host,FS.Csv);

                    tableWriter = tablePath.Writer();
                    tableWriter.WriteLine(formatter.FormatHeader());
                    tableFlow = Wf.EmittingTable<HostAsmRecord>(tablePath);

                    asmPath = Db.AsmStatementPath(root, host, FS.Asm);
                    asmWriter = asmPath.Writer();
                    asmFlow = Wf.EmittingFile(asmPath);

                    counter = 0;
                }

                if(statement.BlockOffset == 0)
                    EmitAsmBlockHeader(statement,asmWriter);

                tableWriter.WriteLine(formatter.Format(statement));
                asmWriter.WriteLine(AsmRender.format(statement));

                counter++;
            }

            asm.emit(thumbprints.ToArray().ToSortedSpan(), ThumbprintPath(root));
            tableWriter.Dispose();
            Wf.EmittedTable(tableFlow, counter);

            asmWriter.Dispose();
            Wf.EmittedFile(asmFlow, counter);
        }

        void ClearTarget()
        {
            var dir = Db.TableDir<HostAsmRecord>();
            var flow = Wf.Running(Msg.ObliteratingDirectory.Format(dir));
            dir.Delete();
            Wf.Ran(flow, Msg.ObliteratedDirectory.Format(dir));
        }

        void EmitHostAsmDoc(ApiHostUri host, ReadOnlySpan<HostAsmRecord> src)
        {
            var dst = Db.AsmStatementPath(host, FS.Asm);
            var flow = Wf.EmittingFile(dst);
            var count = src.Length;
            using var asmwriter = dst.Writer();

            for(var j=0; j<count;j++)
            {
                ref readonly var statement = ref skip(src,j);
                if(statement.BlockOffset == 0)
                    EmitAsmBlockHeader(statement,asmwriter);

                asmwriter.WriteLine(AsmRender.format(statement));
            }

            Wf.EmittedFile(flow, count);
        }

        void EmitHostAsmRecords(ApiHostUri host, ReadOnlySpan<HostAsmRecord> src)
        {
            var dst = Db.AsmStatementPath(host, FS.Csv);
            var flow = Wf.EmittingTable<HostAsmRecord>(dst);
            Wf.EmittedTable(flow, Tables.emit(src, HostAsmRecord.RenderWidths, dst));
        }

        AsmInstructionBlock Decode(in ApiCodeBlock src)
        {
            var outcome = Decoder.Decode(src, out var decoded);
            if(outcome)
                return decoded;
            else
            {
                Wf.Error(outcome.Message);
                return AsmInstructionBlock.Empty;
            }
        }

        FS.FilePath ThumbprintPath(FS.FolderPath root)
            => root + FS.file("thumbprints", FS.Asm);

        FS.FilePath AsmSrcPath(ApiHostUri host, FS.FolderPath root)
            => Db.AsmStatementPath(root, host, FS.Asm);

        FS.FilePath AsmTablePath(ApiHostUri host, FS.FolderPath root)
            => Db.AsmStatementPath(root, host,FS.Csv);

        uint BuildHostStatements(in ApiHostBlocks src, List<HostAsmRecord> dst)
        {
            var blocks = src.Blocks.View;
            var count = blocks.Length;
            var counter = 0u;
            for(var i=0; i<count; i++)
                counter += ApiInstructions.statements(Decode(skip(blocks,i)), dst);
            return counter;
        }

        const string AsmBlockSeparator = "; ------------------------------------------------------------------------------------------------------------------------";

        static void EmitAsmBlockHeader(in HostAsmRecord first, StreamWriter dst)
        {
            dst.WriteLine(AsmBlockSeparator);
            dst.WriteLine(string.Format("; {0}, uri={1}", first.BlockAddress, first.OpUri));
            dst.WriteLine(AsmBlockSeparator);
        }
    }
}