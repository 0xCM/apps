//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using Windows.Image;

    using static Root;
    using static core;

    using C = Windows.Image.IMAGE_SECTION_CHARACTERISTICS;

    partial class LlvmCmd
    {

        [CmdOp(".flags")]
        Outcome FlagTest(CmdArgs args)
        {
            var result = Outcome.Success;
            //var flags = Flags.create<C>(w32,default);
            var flags = default(C);
            //var formatter = Flags.formatter<C>(w32);

            flags |= C.IMAGE_SCN_ALIGN_16BYTES;
            flags |= C.IMAGE_SCN_CNT_CODE;
            flags |= C.IMAGE_SCN_MEM_EXECUTE;
            flags |= C.IMAGE_SCN_MEM_READ;

            Write(flags.ToString());

            Write(((uint)flags).FormatHex());

            return result;
        }

        [CmdOp(".objinfo")]
        Outcome ObjInfo(CmdArgs args)
        {
            var result = Outcome.Success;

            var files = ReadObj.ObjInfoFiles(State.Project().OutDir());
            foreach(var file in files)
            {
                var obi = ReadObj.Load(file);
                Write(string.Format("{0} Lines", obi.DataLines.Length));
                Hydrate(obi.DataLines, obi);
            }

            return result;
        }

        void Hydrate(ReadOnlySpan<TextLine> src, CoffObjInfo dst)
        {
            const string SectionsMarker = "Sections [";
            const string SectionMarker = "Section {";
            const string SectionDataMarker = "SectionData (";
            const string SectionDataEndMarker = ")";
            const string SymbolMarker = "Symbol {";

            var symseq = 0u;
            var count = src.Length;
            var state = ParserState.None;
            Fence<char> DataLineFence = (Chars.Colon, Chars.Pipe);
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
                }
                else if(text.equals(content,SectionDataEndMarker))
                {
                    state = ParserState.ParsedSectionData;
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

        public enum ParserState : byte
        {
            None = 0,

            ParsingSections,

            ParsingSection,

            ParsingCharacteristics,

            ParsingSectionData,

            ParsedSectionData
        }
    }
}