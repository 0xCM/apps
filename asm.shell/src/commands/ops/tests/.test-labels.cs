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
            {
                Write(string.Format("Verified {0} direct label allocations", count));
            }

            return result;
        }

        Outcome LabelTest3()
        {
            var result = Outcome.Success;
            var count = 256u;
            var length = 8u;
            using var buffer = strings.buffer(count*length);
            var labels = core.alloc<Label>(count);
            for(uint i=0,j=0; i<256; i++,j+=length)
            {
                var s = BitRender.format8((byte)i);
                seek(labels,i) = buffer.StoreLabel(s,j);
            }

            for(var i=0; i<count; i++)
            {
                ref readonly var label = ref skip(labels,i);
                var fmt = label.Format();
                Write(fmt);
            }
            return result;

        }

        Outcome CheckLabelAllocator()
        {
            var result = Outcome.Success;
            var count = 256u;
            var length = 8u;
            using var buffer = strings.buffer(count*length);
            var allocator = buffer.LabelAllocator();
            var labels = core.alloc<Label>(count);
            for(uint i=0; i<256; i++)
            {
                var s = BitRender.format8((byte)i);
                if(!allocator.Allocate(s, out seek(labels,i)))
                {
                    result = (false,"Capacity exceeded");
                    break;
                }
            }

            if(result)
            {
                for(var i=0; i<count; i++)
                {
                    ref readonly var label = ref skip(labels,i);
                    var fmt = label.Format();
                    Write(fmt);
                }
            }

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

            result = LabelTest3();
            if(result.Fail)
                return result;

            result = CheckLabelAllocator();
            if(result.Fail)
                return result;

            return result;
        }
   }
}