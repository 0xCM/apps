//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using Asm;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    class LlvmObjDumpParser
    {
        const string SectionMarker = "Disassembly of section ";

        FS.FileUri Source;

        ObjDumpRow Row;

        TextBlock Section;

        bool ParsingSection;

        DataList<ObjDumpRow> Buffer;

        MemoryAddress BlockAddress;

        TextBlock BlockName;

        LineNumber N;

        public LlvmObjDumpParser()
        {
            Reset(FileRef.Empty);
        }

        void Reset(in FileRef src)
        {
            Row = ObjDumpRow.Init(src);
            Section = EmptyString;
            Buffer = new();
            ParsingSection = false;
            BlockAddress = MemoryAddress.Zero;
            BlockName = EmptyString;
            N = LineNumber.Empty;
        }

        public Outcome ParseSource(in FileRef src, out Index<ObjDumpRow> dst)
        {
            Reset(src);
            var result = Outcome.Success;
            var path = src.Path;
            dst = sys.empty<ObjDumpRow>();
            var data = path.ReadLines().Where(x => x != null).View;
            var count = data.Length;
            var docseq = 0u;
            for(var x =0; x<count; x++)
            {
                N++;

                var content = skip(data,x);
                if(empty(content))
                    continue;

                var i = text.index(content, SectionMarker);
                if(i >= 0)
                {
                    var j = text.index(content,Chars.Colon);
                    if(j >=0)
                        Section = text.inside(content, i + SectionMarker.Length - 1, j);
                    ParsingSection = true;
                    continue;
                }

                if(!ParsingSection)
                    continue;

                if(DefinesBlockLabel(content))
                {
                    result = ParseBlockLabel(content);
                    if(result.Fail)
                        break;

                    // Buffer.Add(Row);
                    // Row = ObjDumpRow.Init(src);
                }
                else
                {
                    var k = text.index(content, Chars.Colon);
                    if(k>=0)
                    {
                        Row = ObjDumpRow.Init(src);
                        Row.Line = N;
                        Row.Section = Section;
                        Row.Source = path;
                        result = DataParser.parse(text.left(content, k), out Row.IP);
                        if(result.Fail)
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(Row.IP), content));
                            break;
                        }
                        Row.BlockAddress = BlockAddress;
                        Row.BlockName = BlockName;
                        var asm = text.right(content, k);
                        var y = text.index(asm, Chars.Tab);
                        if(y > 0)
                        {
                            AsmHexCode.parse(text.trim(text.left(asm, y)), out Row.HexCode);
                            var statement = text.trim(text.right(asm, y)).Replace(Chars.Tab, Chars.Space);
                            Row.Asm = statement;
                            if(AsmInlineComment.parse(statement, out Row.Comment))
                            {
                                var m = text.index(statement, Chars.Hash);
                                if(m>0)
                                    Row.Asm = text.left(statement, m);
                            }
                        }
                        Row.DocSeq = docseq++;
                        Buffer.Add(Row);
                        Row = ObjDumpRow.Init(src);
                    }
                }
            }

            dst = Buffer.Array();
            return result;
        }

        Outcome ParseBlockLabel(string content)
        {
            var result = Outcome.Success;
            var j = text.index(content, Chars.Lt);
            if(j >=0)
            {
                Row.Source = Source;
                Row.Line = N;
                Row.Section = Section;
                Row.HexCode = BinaryCode.Empty;
                Row.Asm = ObjDumpRow.BlockStartMarker;
                var k = text.index(content, Chars.Gt);
                if(k>=0)
                    Row.BlockName = text.inside(content, j, k);

                var ip = text.left(content, j).Trim();
                result = DataParser.parse(ip, out Row.BlockAddress);
                if(result.Fail)
                    result = (false, AppMsg.ParseFailure.Format(nameof(Row.BlockAddress), ip));
                else
                    Row.IP = Row.BlockAddress;

                BlockName = Row.BlockName;
                BlockAddress = Row.BlockAddress;
            }
            else
            {
                result = (false, AppMsg.ParseFailure.Format("BlockMarker", content));
            }
            return result;
        }

        static bool DefinesBlockLabel(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var result = false;
            var gt = -1;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(i <16 && SQ.digit(base16,c))
                    continue;

                if(i == 16 && SQ.whitespace(c))
                    continue;

                if(i == 17 && SQ.lt(c))
                    continue;

                if(i > 17 && SQ.gt(c))
                    gt = i;

                if(gt > 0 && i == gt + 1 && SQ.colon(c))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}