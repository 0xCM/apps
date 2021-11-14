//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".test-strings")]
        Outcome TestStrings(CmdArgs args)
        {
            var result = Outcome.Success;

            result = CheckStringAllocator();
            return result;
        }

        Outcome CheckStringAllocator()
        {
            var result = Outcome.Success;
            var count = Pow2.T16;
            var inputlen = Pow2.T04;
            var totallen = count*inputlen;
            var size = totallen*core.size<char>();
            using var buffer = strings.buffer(totallen);
            var allocator = buffer.Allocator();
            var refs = core.alloc<StringRef>(count);
            for(var i=0; i<count; i++)
            {
                var input = BitRender.format16((ushort)i);
                if(!allocator.Allocate(input, out seek(refs,i)))
                {
                    result = (false,"Capacity exceeded");
                    break;
                }

                ref readonly var allocated = ref skip(refs,i);
                var formatted = allocated.Format();
                if(!input.Equals(formatted))
                {
                    result = (false, string.Format("input:{0} != output:{1}", input, formatted));
                    break;
                }
            }
            if(result)
                result = (true, string.Format("Verified string allocator for {0} inputs over a buffer of size {1}", count, size));

            return result;
        }
    }
}