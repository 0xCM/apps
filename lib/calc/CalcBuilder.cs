//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public class CalcBuilder : AppService<CalcBuilder>
    {
        const NumericKind Closure = Integers;

        PageBank16x4x4 PageBlocks;

        ByteSize BlockSize;

        public CalcBuilder()
        {
            PageBlocks = PageBank16x4x4.allocated();
            BlockSize = PageBank16x4x4.BlockSize;
        }

        public void Calc(W128 w)
        {
            var flow = Wf.Running(w.ToString());
            var size = RunCalc(w);
            Wf.Ran(flow, size);
        }

        [Op]
        ByteSize RunCalc(W128 w)
        {
            var sizes = 0ul;
            var cells = BlockSize/w.DataSize;
            ref var left = ref PageBlocks.Block(n0).Segment<Cell128>(0);
            ref var right = ref PageBlocks.Block(n1).Segment<Cell128>(1);
            ref var target = ref PageBlocks.Block(n2).Segment<Cell128>(2);
            var f = Calcs.vor<uint>(w);
            for(var i=0u; i<cells; i++)
            {
                ref var a = ref seek(left,i);
                a = cpu.vbroadcast(w,i);
                ref var b = ref seek(right,i);
                b = cpu.vbroadcast(w,i + Pow2.T12);
                seek(target,i) = f.Invoke(a,b);
                sizes += 3*16;
            }
            return sizes;
        }
    }
}