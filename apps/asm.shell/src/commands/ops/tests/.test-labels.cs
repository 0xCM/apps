//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        Outcome LabelTest1()
        {
            var result = Outcome.Success;
            var data = strings.memory(llvm.stringtables.Instruction.Offsets, llvm.stringtables.Instruction.Data);
            var count = data.EntryCount;

            for(var i=0; i<count; i++)
            {
                var current = data[i];
                var length = (uint)current.Length;
                var address = data.Address(i);
                var label = data.Label(i);
                var a = text.format(current);
                var b = label.Format();
                if(!text.equals(a,b))
                {
                    result = (false, string.Format("{0} != {1}", a, b));
                    break;
                }
            }

            if(result)
            {
                Write(string.Format("Verified {0} stringtable lookups", count));
            }

            return result;
        }

        Outcome LabelTest2()
        {
            var result = Outcome.Success;
            var count = Pow2.T12;
            var input = alloc<string>(count);
            for(var i=0; i<count; i++)
                seek(input,i) = i.FormatBits();

            using var buffer = strings.buffer(input, out var index);
            for(var i=0; i<count; i++)
            {
                ref readonly var label = ref index[i];
                var expect = i.FormatBits();
                var actual = label.Format();
                if(expect != actual)
                {
                    result = (false,string.Format("{0} != {1}", actual, expect));
                    break;
                }
            }

            if(result)
                Write(string.Format("Verified {0} direct label allocations", count));

            return result;
        }

        Outcome CheckLabelAllocator()
        {
            var count = 256;
            var result = Outcome.Success;
            var src = alloc<string>(count);
            for(uint i=0; i<count; i++)
                seek(src,i) = BitRender.format8((byte)i);

            using var allocation = LabelAllocation.allocate(src);
            var labels = allocation.Allocated;
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
                Write("Label allocation succeeded", FlairKind.Status);

            return result;
        }


        [CmdOp(".test-labels")]
        Outcome TestLabels(CmdArgs args)
        {
            var result = Outcome.Success;

            result = LabelTest1();
            if(result.Fail)
                return result;

            result = LabelTest2();
            if(result.Fail)
                return result;

            result = CheckLabelAllocator();
            if(result.Fail)
                return result;


            return result;
        }
   }
}