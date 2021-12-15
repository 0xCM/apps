//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public class XedDisassemblyParser : AppService<XedDisassemblyParser>
    {
        public Index<XedDisasmBlock> ParseDisasmBlocks(FS.FilePath src)
        {
            var lines = src.ReadNumberedLines();
            var count = lines.Length;
            var dst = list<XedDisasmBlock>();
            var blocklines = list<TextLine>();
            var imax = count-1;
            for(var i=0; i<imax; i++)
            {
                blocklines.Clear();

                ref readonly var l0 = ref skip(lines,i);
                ref readonly var l1 = ref skip(lines,i+1);
                if(l0.IsNonEmpty && l1.IsNonEmpty)
                {
                    ref readonly var c0 = ref l0.Content;
                    ref readonly var c1 = ref l1.Content;
                    if(c1[0] == '0')
                    {
                        blocklines.Add(l0);
                        blocklines.Add(l1);
                        i++;
                        while(i++ < imax)
                        {
                            ref readonly var l = ref skip(lines,i);
                            blocklines.Add(l);
                            if(l.StartsWith("XDIS"))
                                break;
                        }
                        dst.Add(blocklines.ToArray());
                    }
                }
            }

            return dst.ToArray();
        }
    }
}