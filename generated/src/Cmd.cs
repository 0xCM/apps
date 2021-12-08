namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using static core;

    using ST = llvm.stringtables;

    [ApiComplete]
    public readonly struct GenStrings
    {
        public static MemoryStrings<ushort> OpCodes
        {
            [MethodImpl(Inline)]
            get => strings.memory<ushort>(ST.Instruction.Offsets, ST.Instruction.Data);
        }
    }

    public class GenCheck
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
                //Write(string.Format("Verified {0} stringtable lookups", count));
            }

            return result;
        }


        public Outcome ValidateStringTables()
        {
            var result = Outcome.Success;
            var runtime = strings.memory(ST.AVX512.Offsets, ST.AVX512.Data);
            var offsets = runtime.Offsets;
            var count = runtime.EntryCount;
            var formatter = Tables.formatter<MemoryStrings>();
            //Write(formatter.Format(runtime, RecordFormatKind.KeyValuePairs));
            var symbols = Symbols.index<ST.AVX512.Index>();
            //Write(string.Format("Symbols:{0}", symbols.Length));
            for(var i=0; i<offsets.Length; i++)
            {
                var l = strings.length(runtime, i);
                if(l == 0)
                    break;
                var k = (ST.AVX512.Index)i;
                var o = skip(offsets,i);
                var c = text.format(runtime[i]);
                //Write(string.Format("{0}[{1}]='{2}'", typeof(ST.AVX512).Name, i, c));
            }
            return result;
        }
    }
}