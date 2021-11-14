//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static XedModels;

    [ApiHost]
    public class XedParsers : AppService<XedParsers>
    {
        bool Verbose {get;} = false;

        Symbols<AttributeKind> Attributes;

        Symbols<Category> Categories;

        public XedParsers()
        {
            Attributes = Symbols.index<AttributeKind>();
            Categories = Symbols.index<Category>();
        }

        static AttributeKind[] attributes(string src)
        {
            var parts = src.SplitClean(Chars.Colon).ToReadOnlySpan();
            var count = parts.Length;
            if(count == 0)
                return default;

            var counter = 0u;
            var dst = span<AttributeKind>(count);
            for(var i=0; i<count; i++)
            {
                var result = DataParser.eparse(skip(parts,i), out seek(dst,i));
                if(result)
                {
                    counter++;
                }
                else
                    return default;
            }
            return slice(dst,0,counter).ToArray();
        }

        public Outcome ParseFormImport(TextLine src, out XedFormImport dst)
        {
            const char Delimiter = Chars.Pipe;

            dst = default;
            var result = Tables.cells(src, Delimiter, XedFormImport.FieldCount, out var cells);
            if(result.Fail)
                return result;
            var j=0;

            result = DataParser.parse(skip(cells,j++), out dst.Index);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out IFormType ft);
            if(result.Fail)
                return result;
            else
                dst.Form = ft;

            result = DataParser.eparse(skip(cells,j++), out dst.Class);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Category);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.IsaKind);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Extension);
            if(result.Fail)
                return result;

            dst.Attributes = attributes(skip(cells,j++));

            return result;
        }

        public Outcome ParseChipMap(FS.FilePath src, out ChipMap dst)
        {
            dst = default;
            var flow = Wf.Running(string.Format("Parsing {0}", src.ToUri()));
            var chip = ChipCode.None;
            var chips = dict<ChipCode,ChipIsaKinds>();
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                if(line.StartsWith(Chars.Hash))
                    continue;

                var i = line.Index(Chars.Colon);
                if(i != NotFound)
                {
                    if(Verbose)
                        Wf.Row(line);

                    var name = line.Left(i).Trim();
                    if(blank(name))
                        continue;

                    if(Enums.parse<ChipCode>(name, out chip))
                    {
                        if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                            return (false, DuplicateChipCode.Format(chip));
                    }
                    else
                        return (false, ChipCodeNotFound.Format(name));
                }
                else
                {
                    var kinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<IsaKind>(x,IsaKind.None)).Where(x => x != 0);
                    chips[chip].Add(kinds);
                    if(chips.TryGetValue(chip, out var entry))
                        entry.Add(kinds);
                }
            }

            var allChips = ChipCodes().ToArray();
            var count = allChips.Length;
            Wf.Ran(flow, string.Format("Parsed {0} chip codes", count));

            var buffer = new Index<ChipCode,IsaKinds>(alloc<IsaKinds>(count));
            for(var i=0; i<count; i++)
            {
                var _code = (ChipCode)i;
                if(chips.TryGetValue(_code, out var entry))
                    buffer[_code] = entry.Kinds;
                else
                    buffer[_code] = IsaKinds.Empty;
            }
            dst = new ChipMap(allChips,buffer);
            return true;
        }

        ReadOnlySpan<ChipCode> ChipCodes()
            => Symbols.index<ChipCode>().Kinds;

        static MsgPattern<ChipCode> DuplicateChipCode => "Duplicate chip code {0}";

        static MsgPattern<string> ChipCodeNotFound => "Code for chip {0} not found";

        public Outcome Parse(in XedFormSource src, ushort seq, out XedFormImport dst)
        {
            var result = Outcome.Success;
            dst.Index = seq;
            result = DataParser.eparse(src.Class, out dst.Class);
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = DataParser.eparse(src.Form, out IFormType ft);
            dst.Form = ft;

            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = Z0.seq.index(Chars.Colon, 0, attributes(src.Attributes));

            return true;
        }
    }
}