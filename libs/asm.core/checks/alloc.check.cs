//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmChecks
    {
        [CmdOp("alloc/check")]
        Outcome CheckAlloc(CmdArgs args)
        {
            var result = Outcome.Success;

            result = CheckStringAllocator();
            if(result.Fail)
                return result;
            else
                Status(result.Message);

            result = CheckLabelAllocator();
            if(result.Fail)
                return result;
            else
                Status(result.Message);

            return result;
        }

        Outcome CheckStringAllocator()
        {
            var result = Outcome.Success;
            var count = Pow2.T16;
            var inputlen = Pow2.T04;
            var totallen = count*inputlen;
            var size = totallen*core.size<char>();
            using var dispenser = Dispense.strings(size);
            var strings = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
            {
                var input = BitRender.format16((ushort)i);
                ref var @string = ref seek(strings,i);
                @string = dispenser.String(input);
                if(!input.Equals(@string.Format()))
                {
                    result = (false, string.Format("input:{0} != output:{1}", input, @string.Format()));
                    break;
                }
            }
            if(result)
                result = (true, string.Format("Verified string allocator for {0} inputs over a buffer of size {1}", count, size));

            return result;
        }

        Outcome CheckLabelAllocator()
        {
            var count = 256;
            var result = Outcome.Success;
            var src = alloc<string>(count);
            for(uint i=0; i<count; i++)
                seek(src,i) = BitRender.format8((byte)i);

            using var allocation = LabelAllocation.alloc(src);
            var labels = allocation.Cells;
            if(labels.Length != count)
                result = (false, string.Format("{0} != {1}", labels.Length, count));
            else
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var label = ref skip(labels,i);
                    ref readonly var input = ref skip(src,i);
                    var same = label.Format() == input;
                    if(!same)
                    {
                        result = (false, string.Format("{0} != {1}", label, input));
                        break;
                    }
                }
            }
            if(result)
                result = (true, string.Format("Verified {0} label allocations", count));

            return result;
        }
    }
}