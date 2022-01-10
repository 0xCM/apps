//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using Asm;

    using static Root;
    using static core;

    using C = Asm.AsmLineClass;

    partial class LlvmMcSvc
    {
        public class LlvmMcParser : Service<LlvmMcParser>
        {
            public static AsmDocument asmdoc(FS.FilePath src)
            {
                var parser = new LlvmMcParser();
                return parser.ParseAsmDoc(src);
            }

            public static Outcome encoding(FS.FilePath src, out AsmEncodingDoc dst)
            {
                var parser = new LlvmMcParser();
                return parser.ParseEncoding(src, out dst);
            }

            List<AsmDirective> Directives;

            List<AsmBlockLabel> BlockLabels;

            List<LineNumber> BlockOffsets;

            List<AsmSourceLine> SourceLines;

            List<DocInstRef> Instructions;

            const string InstructionMarker = "<MCInst #";

            const string EncodingMarker = "# encoding:";

            uint DocSeq;

            Index<DecimalDigitValue> _DigitBuffer;

            Span<DecimalDigitValue> DigitBuffer()
                => _DigitBuffer.Clear();

            public Outcome ParseEncoding(FS.FilePath src, out AsmEncodingDoc dst)
            {
                var result = Outcome.Success;
                dst = AsmEncodingDoc.Empty;
                var lines = FS.readlines(src).View;
                var count = (uint)lines.Length;
                var buffer = list<AsmStatementEncoding>();
                var offset = Address32.Zero;

                DocSeq = 0;
                var record = default(AsmStatementEncoding);
                for(var i=0u; i<count; i++)
                {
                    ref readonly var line = ref skip(lines,i);
                    if(line.Contains(EncodingMarker))
                    {
                        var content = line.Content.Replace(Chars.Tab, Chars.Space);
                        var j = text.index(content, Chars.Hash);
                        result = AsmParser.asmxpr(text.left(content,j), out record.Asm);
                        if(result.Fail)
                            return result;

                        var enc = text.right(content, j + EncodingMarker.Length);
                        result = AsmHexCode.parse(enc, out record.Encoding);
                        if(result.Fail)
                            return result;

                        record.DocSeq = DocSeq++;
                        record.Line = line.LineNumber;
                        record.Offset = offset;

                        buffer.Add(record);
                        offset += record.Encoding.Size;
                        record = default(AsmStatementEncoding);
                    }
                }
                dst = new AsmEncodingDoc(src, buffer.ToArray());
                return result;
            }

            public AsmDocument ParseAsmDoc(FS.FilePath src)
            {
                var result = Outcome.Success;
                var data = FS.readlines(src).View;
                var count = (uint)data.Length;
                DocSeq = 0;
                BlockLabels = new();
                BlockOffsets = new();
                SourceLines = new();
                Directives = new();
                Instructions = new();
                _DigitBuffer = alloc<DecimalDigitValue>(12);

                for(var i=0u; i<count; i++)
                    Parse(skip(data,i));

                return new AsmDocument(src,Directives.ToArray(), BlockLabels.ToArray(), BlockOffsets.ToArray(), SourceLines.ToArray(), Instructions.ToArray());
            }

            void Parse(in TextLine src)
            {
                var @class = AsmLine.classify(src.Content);
                var content = src.Content.Replace(Chars.Tab, Chars.Space).Trim();
                switch(@class)
                {
                    case C.Label:
                        if(AsmParser.label(content, out AsmBlockLabel label))
                        {
                            BlockLabels.Add(label);
                            BlockOffsets.Add(src.LineNumber);
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, label, EmptyString));
                        }
                    break;

                    case C.Directive:
                        if(AsmParser.directive(content, out var directive))
                        {
                            Directives.Add(directive);
                        }
                    break;

                    case C.AsmSource:
                        if(AsmParser.comment(src.Content, out var ilc))
                        {
                            var statement = text.left(content, (char)ilc.Marker);
                            if(statement.Length != 0)
                                statement = RP.Spaced4 + statement;

                            var comment = ilc.Content;
                            if(comment.Contains(InstructionMarker))
                            {
                                var number = DigitBuffer();
                                var i = text.index(comment, InstructionMarker) + InstructionMarker.Length;
                                var dcount = DigitParser.digits(base10, text.slice(comment,i), 0u, number);
                                var inst = text.remove(text.slice(comment,i), Chars.Gt);
                                var j = text.whitespace(inst);
                                if(j != NotFound)
                                    Instructions.Add(new DocInstRef(DocSeq, src.LineNumber, text.right(inst,j)));
                                else
                                    Instructions.Add(new DocInstRef(DocSeq, src.LineNumber, inst));
                                DocSeq++;
                            }

                            if(comment.Contains("encoding: "))
                            {
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, EmptyString, statement));
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, @class,EmptyString, "#" + RP.Spaced2 + comment));
                            }
                            else if(comment.Contains(InstructionMarker) && statement.Length != 0)
                            {
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, EmptyString, statement));
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, EmptyString, "#" + RP.Spaced2 + comment));
                            }
                            else
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, EmptyString, statement, comment));
                        }
                        else
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, EmptyString, RP.Spaced4 + content));
                    break;
                }
            }
        }
    }
}