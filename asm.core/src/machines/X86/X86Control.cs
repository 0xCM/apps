//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using static core;

    using X86;

    public readonly struct X86Control
    {
        public static RegStore8x64 regs(N8 n, W64 w)
            => default;

        public static X86Machine intel64(EventSignal signal)
            => new X86Machine(signal);

        public static void state(X86Machine src, ITextBuffer dst)
        {
            var allocations = src.Bank.Allocations;
            var count = allocations.Length;
            var offset = Address16.Zero;
            for(var i=0; i<count; i++)
            {
                ref var a = ref seek(allocations,i);
                var def = a.Definition;
                dst.AppendLine(string.Format("[bank{0:D2}:{1}:{2}]", i, a.Range, def.Format()));
                for(var j=0u; j<def.RegCount; j++)
                {
                    var address = a.RegAddress(j);
                    var content = cover<byte>(address, def.RegSize);
                    dst.AppendFormat("[reg{0:D2}:{1}:{2}] ", j, offset, address.Format());
                    for(var k=0; k<def.RegSize; k++)
                    {
                        ref var cell = ref seek(content,k);
                        dst.Append(cell.FormatHex(specifier:false));
                    }
                    dst.AppendLine();
                    offset += (Address16)(ulong)def.RegSize;
                }
            }
        }
    }
}