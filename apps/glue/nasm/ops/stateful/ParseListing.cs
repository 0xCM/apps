//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class Nasm
    {
        public uint ParseListing(NasmListing src, Span<NasmListEntry> dst)
        {
            var flow = Wf.Running(ParsingNasmListEntries.Format(src.LineCount));
            var j = 0u;
            var lines = src.Lines.View;
            var count = lines.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var outcome = Nasm.entry(line, out var entry);
                if(outcome)
                    seek(dst, j++) = entry;
                else
                    Wf.Warn(outcome.Message);
            }

            Wf.Ran(flow, ParsedNasmListEntries.Format(j));
            return j;
        }
    }
}