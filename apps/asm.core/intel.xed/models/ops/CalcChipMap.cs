//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Linq;

    using static core;
    using static XedModels;

    partial class IntelXed
    {
        public XedChipMap CalcChipMap()
        {
            return Data(nameof(CalcChipMap), Calc);

            XedChipMap Calc()
            {
                var src = XedPaths.ChipMapSource();
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

                        if(XedParsers.parse(name, out chip))
                        {
                            if(!chips.TryAdd(chip, new ChipIsaKinds(chip)))
                                Errors.Throw(DuplicateChipCode.Format(chip));
                        }
                        else
                            Errors.Throw(ChipCodeNotFound.Format(name));
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
                    var code = (ChipCode)i;
                    if(chips.TryGetValue(code, out var entry))
                        buffer[code] = entry.Kinds;
                    else
                        buffer[code] = XedModels.IsaKinds.Empty;
                }
                Ran(flow, string.Format("Parsed {0} chip codes", count));
                return new XedChipMap(kinds,buffer);
            }
        }
    }
}