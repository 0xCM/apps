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

    class LlvmAsmParser
    {
        List<AsmDirective> Directives;

        List<AsmBlockLabel> BlockLabels;

        List<LineNumber> BlockOffsets;

        List<AsmSourceLine> SourceLines;

        List<AsmInstRef> Instructions;

        const string InstructionMarker = "<MCInst #";

        const string EncodingMarker = "encoding: ";

        uint DocSeq;

        FileRef DocSource;

        Index<DecimalDigitValue> _DigitBuffer;

        Span<DecimalDigitValue> DigitBuffer()
            => _DigitBuffer.Clear();

        EnumParser<AsmId> AsmIdParser {get;} = new EnumParser<AsmId>();

        public McAsmDoc ParseAsmDoc(in FileRef fref)
        {
            DocSource = fref;
            var result = Outcome.Success;
            var data = FS.readlines(DocSource.Path).View;
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

            return new McAsmDoc(DocSource, Directives.ToArray(), BlockLabels.ToArray(), BlockOffsets.ToArray(), SourceLines.ToArray(), Instructions.ToArray());
        }

        AsmBlockLabel Label;

        uint LabelSeq;

        LineNumber LabelLine;

        AsmLineClass LineClass;

        LineNumber LineNumber;

        string LineContent;

        [MethodImpl(Inline)]
        static bool IsLabel(string src)
            => text.xedni(src, Chars.Colon) == src.Length - 1;

        [MethodImpl(Inline)]
        static bool IsDirective(string src)
            => text.index(src, Chars.Dot) == 0;

        public static AsmLineClass lineclass(string src)
        {
            var content = text.trim(src);

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
            LineClass = lineclass(src.Content);
            LineContent = src.Content.Replace(Chars.Tab, Chars.Space).Trim();
            LineNumber = src.LineNumber;
            switch(LineClass)
            {
                case C.Label:
                    if(AsmBlockLabel.parse(LineContent, out Label))
                    {
                        LabelSeq++;
                        LabelLine = LineNumber;
                        BlockLabels.Add(Label);
                        BlockOffsets.Add(LabelLine);
                        SourceLines.Add(new AsmSourceLine(LabelLine, LineClass, Label, EmptyString));
                    }
                break;

                case C.Directive:
                    if(AsmDirective.parse(LineContent, out var directive))
                    {
                        Directives.Add(directive);
                    }
                break;

                case C.AsmSource:
                    if(AsmParser.comment(LineContent, out var asmcomment))
                    {
                        var statement = text.left(LineContent, (char)asmcomment.Marker);
                        if(statement.Length != 0)
                            statement = RP.Spaced4 + statement;

                        var comment = asmcomment.Content;
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
                                Instructions.Add(new AsmInstRef(DocSource.DocId, DocSeq, LineNumber, asmid));
                            }
                            else
                            {
                                AsmIdParser.Parse(inst, out var asmid);
                                Instructions.Add(new AsmInstRef(DocSource.DocId, DocSeq, LineNumber, asmid));
                            }
                            DocSeq++;
                        }

                        if(comment.Contains(EncodingMarker))
                        {
                            SourceLines.Add(new AsmSourceLine(LineNumber, LineClass, Label, statement));
                            SourceLines.Add(new AsmSourceLine(LineNumber, LineClass, Label, "#" + RP.Spaced2 + comment));
                        }
                        else if(comment.Contains(InstructionMarker) && statement.Length != 0)
                        {
                            SourceLines.Add(new AsmSourceLine(LineNumber, LineClass, Label, statement));
                            SourceLines.Add(new AsmSourceLine(LineNumber, LineClass, Label, "#" + RP.Spaced2 + comment));
                        }
                        else
                            SourceLines.Add(new AsmSourceLine(LineNumber, LineClass, Label, statement, comment));
                    }
                    else
                        SourceLines.Add(new AsmSourceLine(LineNumber, LineClass, Label, RP.Spaced4 + LineContent));
                break;
            }
        }
    }
}