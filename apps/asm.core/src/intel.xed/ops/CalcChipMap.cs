//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static core;
    using static XedModels;

    partial class IntelXed
    {
        public Outcome CalcChipMap(out XedChipMap dst)
            => CalcChipMap(XedPaths.DocSource(XedDocKind.ChipData), out dst);

        Outcome CalcChipMap(FS.FilePath src, out XedChipMap dst)
        {
            dst = default;
            var flow = Running(string.Format("Parsing {0}", src.ToUri()));
            var chip = ChipCode.INVALID;
            var chips = dict<ChipCode,ChipIsaKinds>();
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                if(line.StartsWith(Chars.Hash))
                    continue;

                var i = line.Index(Chars.Colon);
                if(i != -1)
                {
                    if(Verbose)
                        Write(line);

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
                    var isaKinds = line.Content.SplitClean(Chars.Tab).Trim().Select(x => Enums.parse<IsaKind>(x,0)).Where(x => x != 0).Array();
                    chips[chip].Add(isaKinds);
                    if(chips.TryGetValue(chip, out var entry))
                        entry.Add(isaKinds);
                }

            }

            var kinds = Symbols.index<ChipCode>().Kinds.ToArray();
            var count = kinds.Length;

            var buffer = new Index<ChipCode,IsaKinds>(alloc<IsaKinds>(count));
            for(var i=0; i<count; i++)
            {
                var _code = (ChipCode)i;
                if(chips.TryGetValue(_code, out var entry))
                    buffer[_code] = entry.Kinds;
                else
                    buffer[_code] = XedModels.IsaKinds.Empty;
            }
            dst = new XedChipMap(kinds,buffer);

            Ran(flow, string.Format("Parsed {0} chip codes", count));

            return true;
        }
    }
}