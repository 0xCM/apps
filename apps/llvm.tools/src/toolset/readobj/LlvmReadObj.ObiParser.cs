//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    partial class LlvmReadObjSvc
    {
        public class LlvmObiParser : AppService<LlvmObiParser>
        {
            public enum ParserState : byte
            {
                None = 0,

                ParsingSections,

                ParsingSection,

                ParsingCharacteristics,

                ParsingSectionData,

                ParsedSectionData
            }

            const char SectionDataEndMarker = Chars.RParen;

            const char SectionDataLeftMarker = Chars.Colon;

            const char SectionDataRightMarker = Chars.Pipe;

            LlvmReadObjSvc ReadObj;

            protected override void Initialized()
            {
                ReadObj = Wf.LlvmReadObj();
            }

            public Outcome Parse(FS.FilePath obipath, out CoffObjInfo dst)
            {
                dst = ReadObj.Load(obipath);
                Hydrate(dst.DataLines, dst);
                return Outcome.Success;
            }

            void Hydrate(ReadOnlySpan<TextLine> src, CoffObjInfo dst)
            {
                const string SectionsMarker = "Sections [";
                const string SectionMarker = "Section {";
                const string SectionDataMarker = "SectionData (";
                const string SymbolMarker = "Symbol {";

                var symseq = 0u;
                var count = src.Length;
                var state = ParserState.None;
                for(var i=0u; i<count; i++)
                {
                    ref readonly var line = ref skip(src,i);
                    var content = line.Content.Trim();
                    if(text.contains(content,SectionMarker))
                    {
                        state = ParserState.ParsingSection;
                    }
                    else if(text.contains(content,SectionDataMarker))
                    {
                        state = ParserState.ParsingSectionData;
                        i++;
                        if(ParseSectionData(src, ref i, out var data))
                        {

                        }
                    }
                    else if(text.contains(content,SymbolMarker))
                    {
                        i++;
                        if(ParseSymbol(src, ref i, out var sym))
                        {
                            sym.Seq = symseq++;
                            dst.AddSymbol(sym);
                            Write(string.Format("{0:D4} {1}:{2}", sym.Seq, sym.Name, sym.Value));
                        }
                    }
                }
            }

            Outcome ParseSectionData(ReadOnlySpan<TextLine> src, ref uint i, out BinaryCode dst)
            {
                var result = Outcome.Success;
                dst = BinaryCode.Empty;
                var buffer = list<uint>();
                for(; i<src.Length; i++)
                {
                    ref readonly var line = ref skip(src,i);
                    var content = line.Content.Trim();
                    if(content.Length == 1 && content[0] == SectionDataEndMarker)
                        break;

                    var values = text.trim(text.inside(content, SectionDataLeftMarker, SectionDataRightMarker));
                    if(text.nonempty(values))
                    {
                        var numbers = text.split(values, Chars.Space);
                        var count = numbers.Length;
                        for(var j=0; j<count; j++)
                        {
                            result = Hex.parse32u(skip(numbers,j), out var n);
                            if(result.Fail)
                                return result;
                            buffer.Add(n);
                        }
                    }
                }
                dst = bytes(buffer.ViewDeposited()).ToArray();
                return result;
            }

            bool ParseSymbol(ReadOnlySpan<TextLine> src, ref uint i, out CoffSymbol dst)
            {
                const string AuxMarker = "AuxSectionDef {";
                var seq = 0u;
                dst = CoffSymbol.Empty;
                for(; i<src.Length; i++)
                {
                    ref readonly var line = ref skip(src,i);
                    var content = line.Content.Trim();
                    if(content.Contains(AuxMarker) || text.index(content, Chars.RBrace) == 0)
                        return true;
                    else
                    {
                        var kv = text.split(content, Chars.Colon).Select(text.trim);
                        if(kv.Length == 2)
                        {
                            var prop = text.trim(skip(kv,0));
                            var val = text.trim(skip(kv,1));
                            switch(prop)
                            {
                                case "Name":
                                    dst.Name = val;
                                break;
                                case "Value":
                                    DataParser.parse(val, out dst.Value);
                                break;
                                case "Section":
                                break;
                                case "BaseType":
                                break;
                                case "StorageClass":
                                break;
                            }
                        }
                    }
                }
                return false;
            }
        }
    }
}