//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Z0.Asm;

    using static core;

    partial class ApiExtractor
    {
        void EmitAsmSource(ApiHostUri host, ReadOnlySpan<AsmRoutine> src)
        {
            var counter = 0u;
            var count = (uint)src.Length;
            if(count == 0)
                return;
            var dst = PackArchive.AsmSrcPath(host);
            var flow = EmittingFile(dst);
            using var writer = dst.Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var routine = ref skip(src,i);
                if(routine is null || routine.IsEmpty)
                    continue;

                writer.Write(AsmFormatter.format(routine, FormatConfig));
                counter++;
            }
            EmittedFile(flow, counter);
        }
    }
}