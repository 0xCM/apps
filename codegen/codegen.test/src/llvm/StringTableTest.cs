namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using stringtables;

    [ApiComplete]
    public readonly struct GenStrings
    {
        public static MemoryStrings<ushort> OpCodes
        {
            [MethodImpl(Inline)]
            get => strings.memory<ushort>(InstructionST.Offsets, InstructionST.Data);
        }
    }


    public class StringTableChecks : Checks<StringTableChecks>
    {
        Outcome LabelTest1()
        {
            var result = Outcome.Success;
            var data = strings.memory(InstructionST.Offsets, InstructionST.Data);
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
                //Write(string.Format("Verified {0} stringtable lookups", count));
            }

            return result;
        }


        public override void Run()
        {
            var result = Outcome.Success;
            var runtime = strings.memory(AVX512ST.Offsets, AVX512ST.Data);
            var offsets = runtime.Offsets;
            var count = runtime.EntryCount;
            var formatter = Tables.formatter<MemoryStrings>();
            var symbols = Symbols.index<AVX512Kind>();
            for(var i=0; i<offsets.Length; i++)
            {
                var l = strings.length(runtime, i);
                if(l == 0)
                    break;
                var k = (AVX512Kind)i;
                var o = skip(offsets,i);
                var c = text.format(runtime[i]);
                var info = string.Format("{0} = '{1}'", k, c);
                Write(info);
            }
        }
    }
}