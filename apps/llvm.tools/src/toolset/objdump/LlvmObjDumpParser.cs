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
            Reset();
        }

        void Reset()
        {
            Row = ObjDumpRow.Empty();
            Section = EmptyString;
            Buffer = new();
            ParsingSection = false;
            BlockAddress = MemoryAddress.Zero;
            BlockName = EmptyString;
            N = LineNumber.Empty;
        }

        public Outcome ParseSource(FS.FilePath src, out Index<ObjDumpRow> dst)
        {
            var result = Outcome.Success;
            dst = sys.empty<ObjDumpRow>();
            Reset();

            var data = src.ReadLines().Where(x => x != null).View;
            var count = data.Length;
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

                    Buffer.Add(Row);
                    Row = ObjDumpRow.Empty();
                }
                else
                {
                    var k = text.index(content, Chars.Colon);
                    if(k>=0)
                    {
                        Row = ObjDumpRow.Empty();
                        Row.Line = N;
                        Row.Section = Section;
                        Row.Source = src;
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
                            DataParser.parse(text.trim(text.left(asm, y)), out Row.Encoding);
                            var statement = text.trim(text.right(asm, y)).Replace(Chars.Tab, Chars.Space);
                            Row.Statement = statement;
                            if(AsmParser.comment(statement, out Row.Comment))
                            {
                                var m = text.index(statement, Chars.Hash);
                                if(m>0)
                                    Row.Statement = text.left(statement, m);
                            }
                        }
                        Buffer.Add(Row);
                        Row = ObjDumpRow.Empty();
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
                Row.Encoding = BinaryCode.Empty;
                Row.Statement = ObjDumpRow.BlockStartMarker;
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