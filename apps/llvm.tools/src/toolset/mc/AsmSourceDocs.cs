//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    using C = AsmLineClass;

    class AsmSourceDocParser
    {
        List<AsmDirective> Directives;

        List<AsmBlockLabel> BlockLabels;

        List<LineNumber> BlockOffsets;

        List<AsmSourceLine> SourceLines;

        List<AsmInstRef> Instructions;

        const string InstructionMarker = "<MCInst #";

        uint DocSeq;

        Index<DecimalDigitValue> _DigitBuffer;

        Span<DecimalDigitValue> DigitBuffer()
            => _DigitBuffer.Clear();

        EnumParser<AsmId> AsmIdParser {get;} = new EnumParser<AsmId>();

        public AsmDocument ParseAsmDoc(FS.FilePath src)
        {
            var result = Outcome.Success;
            var data = FS.readlines(src).View;
            var count = (uint)data.Length;
            DocSeq = 0;
            LabelSeq = 0;
            Label = AsmBlockLabel.Empty;
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

        AsmBlockLabel Label;

        uint LabelSeq;

        LineNumber LabelLine;

        public static AsmLineClass lineclass(string src)
        {
            var content = text.trim(src);

            [MethodImpl(Inline)]
            static bool IsLabel(string src)
                => text.xedni(src, Chars.Colon) == src.Length - 1;

            [MethodImpl(Inline)]
            static bool IsDirective(string src)
                => text.index(src, Chars.Dot) == 0;

            if(text.empty(content))
                return C.Empty;

            if(IsLabel(content))
                return C.Label;

            if(IsDirective(content))
                return C.Directive;

            return C.AsmSource;
        }

        void Parse(in TextLine src)
        {
            var @class = lineclass(src.Content);
            var content = src.Content.Replace(Chars.Tab, Chars.Space).Trim();
            switch(@class)
            {
                case C.Label:
                    if(AsmParser.label(content, out Label))
                    {
                        LabelSeq++;
                        LabelLine = src.LineNumber;
                        BlockLabels.Add(Label);
                        BlockOffsets.Add(LabelLine);
                        SourceLines.Add(new AsmSourceLine(LabelLine, @class, Label, EmptyString));
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
                            {
                                AsmIdParser.Parse(text.right(inst,j), out var asmid);
                                Instructions.Add(new AsmInstRef(DocSeq, src.LineNumber, asmid));
                            }
                            else
                            {
                                AsmIdParser.Parse(inst, out var asmid);
                                Instructions.Add(new AsmInstRef(DocSeq, src.LineNumber, asmid));
                            }
                            DocSeq++;
                        }

                        if(comment.Contains("encoding: "))
                        {
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, Label, statement));
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, Label, "#" + RP.Spaced2 + comment));
                        }
                        else if(comment.Contains(InstructionMarker) && statement.Length != 0)
                        {
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, Label, statement));
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, Label, "#" + RP.Spaced2 + comment));
                        }
                        else
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, Label, statement, comment));
                    }
                    else
                        SourceLines.Add(new AsmSourceLine(src.LineNumber, @class, Label, RP.Spaced4 + content));
                break;
            }
        }
    }

    public class AsmSourceDocs : AppService<AsmSourceDocs>
    {
        public AsmDocument ParseAsmDoc(FS.FilePath src)
        {
            return new AsmSourceDocParser().ParseAsmDoc(src);
        }
    }
}