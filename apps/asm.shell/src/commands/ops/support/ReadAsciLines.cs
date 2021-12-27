//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        Outcome ReadAsciLines()
        {
            var result = Outcome.Success;
            var src = State.Files().View;
            var count = src.Length;
            var counter = 0u;
            var line = default(AsciLine<byte>);
            for(var i=0; i<count; i++)
            {
                var path = skip(src,i);
                using var reader = path.AsciLineReader2();
                while(reader.Next(out line))
                {
                    Write(line);
                    counter++;
                }
            }

            return result;
        }
    }
}