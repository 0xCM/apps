//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Runtime.CompilerServices;

    using Z0.Asm;

    using static Root;
    using static core;

    public class CultProcessor : AppService<CultProcessor>
    {
        public uint BatchSize => Pow2.T16;

        DataList<CultSummaryRecord> Summaries;

        DataList<AsmSourceLine> AsmLines;

        Index<char> HexCharBuffer;

        FS.FolderPath DetailRoot;

        FS.FolderPath TargetRoot;

        ToolId Tool;

        FS.FilePath InputFile;

        public CultProcessor()
        {
            Summaries = new();
            AsmLines = new();
            HexCharBuffer = sys.alloc<char>(HexBufferLength);
            Tool = Toolspace.cult;
            InputFile = FS.FilePath.Empty;
        }

        protected override void OnInit()
        {
            TargetRoot = Ws.Imports().Subdir(Tool);
            DetailRoot = TargetRoot + FS.folder("details");
            InputFile = Ws.Sources().Path(Tool.Format(), FS.Asm);
            SummaryPath = TargetRoot + FS.file(Tool.Format() + ".summary", FS.Csv);
        }

        FS.FilePath SummaryPath;

        public Outcome<uint> Process()
        {
            return Process(InputFile);
        }

        public Outcome<uint> Process(FS.FilePath src)
        {
            if(!src.Exists)
            {
                Wf.Error(FS.Msg.DoesNotExist.Format(src));
                return 0;
            }

            // DetailRoot.Clear();
             Summaries.Clear();
             AsmLines.Clear();

            var output = span<CultRecord>(BatchSize);
            var input = span<TextLine>(BatchSize);
            using var reader = src.Utf8Reader();
            var counter = 0u;
            var current = 0;
            var max = BatchSize - 1;
            var batch = 0u;
            while(!reader.EndOfStream)
            {
                var line = reader.ReadLine(++counter);
                if(current < max)
                {
                    seek(input, current++) = line;
                }
                else
                {
                    Process(batch,counter,input,output);

                    output.Clear();
                    input.Clear();
                    current = 0;
                    batch++;
                }
            }

            if(current != 0)
                Process(batch,counter,input,output);


            EmitSummary();

            return counter;
        }

        uint Parse(ReadOnlySpan<TextLine> src, Span<CultRecord> dst)
        {
            var count = src.Length;
            var j=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                if(Parse(input, out var record))
                    seek(dst, j++) = record;
            }
            return j;
        }

        void EmitSummary()
        {
            var dst = SummaryPath;
            var flow = Wf.EmittingTable<CultSummaryRecord>(dst);
            var formatter = Tables.formatter<CultSummaryRecord>(CultSummaryRecord.RenderWidths);
            using var summary = dst.Writer();
            summary.WriteLine(formatter.FormatHeader());
            var summaries = Summaries.Emit();
            foreach(var s in summaries)
                summary.WriteLine(formatter.Format(s));
            Wf.EmittedTable(flow, summaries.Count);
        }

        void Process(uint batch, uint counter, ReadOnlySpan<TextLine> input, Span<CultRecord> output)
        {
            var processing = Wf.Running(ProcessingBatch.Format(batch, counter));
            var parsed = slice(output, 0, Parse(input, output));
            Process(parsed);
            Wf.Ran(processing, ProcessedBatch.Format(batch, counter, parsed.Length, BatchSize));
        }

        void Process(ReadOnlySpan<CultRecord> src)
        {
            var count = src.Length;

            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                if(record.RecordKind == CultRecordKind.Statement)
                    AsmLines.Add(new AsmSourceLine(record.LineNumber, EmptyString, AsmExpr.parse(record.Statement), asm.comment(record.Comment)));
                else if(record.RecordKind == CultRecordKind.Label)
                    AsmLines.Add(new AsmSourceLine(record.LineNumber, record.Label.Format(), EmptyString, asm.comment(record.Comment)));
                else if(record.RecordKind == CultRecordKind.Summary)
                {
                    var summary = Summarize(record);
                    Summaries.Add(summary);
                    EmitDetails(summary);
                }
            }
        }

        Outcome Parse(TextLine src, out CultRecord dst)
        {
            var content = src.Content ?? EmptyString;
            var parts = @readonly(content.Split(Chars.Semicolon));
            if(text.nonempty(content))
            {
                if(parts.Length == 2)
                    return ParseStatement(src, parts, out dst);
                else if(content.Contains(Chars.Colon))
                {
                    if(content.Contains(SummaryMarker))
                        return ParseSummary(src, out dst);
                    else
                    {
                        if(!content.ContainsAny(NonLabels))
                        {
                            var identifier = text.trim(content.LeftOfFirst(Chars.Colon));
                            if(text.nonempty(identifier))
                                return ParseLabel(src, identifier, out dst);
                        }
                    }
                }
            }

            dst = CultRecord.Empty;
            return false;
        }

        CultSummaryRecord Summarize(in CultRecord record)
        {
            var summary = new CultSummaryRecord();
            metrics(record, out summary.Lat, out summary.Rcp);
            summary.Instruction = record.Comment.Format().LeftOfFirst(Chars.Colon).Trim();
            summary.Mnemonic = monic(summary.Instruction);
            summary.LineNumber = record.LineNumber;
            summary.Id = identify(summary);
            return summary;
        }

        Outcome ParseLabel(TextLine src, string name, out CultRecord dst)
        {
            dst.LineNumber = src.LineNumber;
            dst.Label = name;
            dst.Statement = TextBlock.Empty;
            dst.Comment = TextBlock.Empty;
            dst.RecordKind = CultRecordKind.Label;
            return true;
        }

        Outcome ParseStatement(TextLine src, ReadOnlySpan<string> parts, out CultRecord dst)
        {
            var statement = skip(parts,0).Remove(RexRemove);
            var comment = skip(parts,1);
            var bitstring = "<error>";
            var formatted = FormatBytes(comment, out var count);
            if(Hex.hexdata(formatted, out var parsed))
                bitstring = AsmRender.format8x4(AsmHexCode.load(parsed));

            if(count != 0)
                comment = string.Format(StatementCommentPattern, comment, count, formatted, bitstring);

            dst.LineNumber = src.LineNumber;
            dst.Statement = statement;
            dst.Comment = comment;
            dst.Label = TextBlock.Empty;
            dst.RecordKind = CultRecordKind.Statement;
            return true;
        }

        Outcome ParseSummary(TextLine src, out CultRecord dst)
        {
            dst.LineNumber = src.LineNumber;
            dst.Statement = TextBlock.Empty;
            dst.Comment = src.Content;
            dst.Label = TextBlock.Empty;
            dst.RecordKind = CultRecordKind.Summary;
            return true;
        }

        string FormatBytes(ReadOnlySpan<char> src, out uint size)
            => NormalizeBytes(src, out size).ToString();

        ReadOnlySpan<char> NormalizeBytes(ReadOnlySpan<char> src, out uint size)
        {
            var chars = HexCharBuffer.Edit;
            chars.Clear();
            var count = src.Length;
            var j=0;
            var k=0;
            var m=0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(Hex.scalar(c))
                {
                    seek(chars,j++) = c;
                    if(++k == 2)
                    {
                        seek(chars,j++) = Chars.Space;
                        k = 0;
                        m++;
                    }
                }
                else if(Hex.upper(c))
                {
                    seek(chars, j++) = Char.ToLowerInvariant(c);
                    if(++k == 2)
                    {
                        seek(chars,j++) = Chars.Space;
                        k = 0;
                        m++;
                    }
                }
            }
            size = m;

            if(size == 0)
              return default;
            else
            {
                var len = skip(chars,j-1) == Chars.Space ? j - 1 : j;
                return slice(chars,0,len);
            }
        }

        FS.FilePath DetailPath(AsmMnemonic src)
            => DetailRoot + DetailFile(src);

        void EmitDetails(in CultSummaryRecord summary)
        {
            var mnemonic = summary.Mnemonic.Format(MnemonicCase.Lowercase);
            var path = DetailPath(summary.Mnemonic);
            using var writer = path.Writer(true);
            writer.WriteLine();
            writer.WriteLine(asm.comment(summary.Id));
            writer.WriteLine(asm.comment(PageBreak));

            if(AsmLines.IsNonEmpty)
            {
                foreach(var line in AsmLines)
                {
                    var lf =  AsmText.format(line);
                    if(lf.StartsWith(summary.Mnemonic.Format(MnemonicCase.Lowercase) + Chars.Space))
                        writer.WriteLine(lf);
                }
                AsmLines.Clear();
            }
        }

        static string[] operands(string instruction)
            => instruction.RightOfFirst(Chars.Space).Split(Chars.Comma).Select(x => x.Trim());

        static FS.FileName DetailFile(AsmMnemonic src)
            => FS.file(string.Format("cult.{0}", src.Format(MnemonicCase.Lowercase)), FS.Asm);

        static Identifier identify(in CultSummaryRecord src)
        {
            var individuals = operands(src.Instruction);
            var joined = individuals.Length != 0 ? individuals.Join(Chars.Underscore) : EmptyString;
            if(text.nonempty(joined))
                return string.Format("{0}_{1}", src.Mnemonic, joined);
            else
                return src.Mnemonic.Format(MnemonicCase.Lowercase);
        }

        //   adc r32, i32                            : Lat:   0.66 Rcp:   0.66

        static AsmMnemonic monic(string instruction)
            => instruction.LeftOfFirst(Chars.Space);

        static void metrics(in CultRecord src, out string lat, out string rcp)
        {
            var content = src.Comment.Format().RightOfFirst(Chars.Colon).Remove(LatencyMarker).Replace(RcpMarker,"|").SplitClean("|");
            if(content.Length == 2)
            {
                lat = content[0].Trim();
                rcp = content[1].Trim();
            }
            else
            {
                lat = EmptyString;
                rcp = EmptyString;
            }
        }

        string[] NonLabels = sys.array("In", " ", "VendorName", "ModelId", "FamilyId", "SteppingId", "Codename", "CpuDetect");

        const byte HexBufferLength = 128;

        const string SummaryMarker = ": Lat";

        const string LatencyMarker = "Lat:";

        const string RcpMarker = "Rcp:";

        const string RexRemove = "rex ";

        const string PageBreak = RP.PageBreak160;

        const string StatementCommentPattern = "{0,-20} | {1,-6} | [{2} <-> {3}]";

        static MsgPattern<Count,Count> ProcessingBatch => "Processing batch {0:D2}:{1,-6}";

        static MsgPattern<Count,Count,Count,Count> ProcessedBatch => "Processed batch {0:D2}:{1,-6} ({2}/{3})";
    }
}