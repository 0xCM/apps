//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".sdm-opcode-tests")]
        public Outcome TestOcStrings(CmdArgs args)
        {
            var result = Outcome.Success;
            var _strings = strings.memory(OpCodeStrings.Offsets, OpCodeStrings.Data);
            var offsets = recover<uint>(OpCodeStrings.Offsets);
            var formatter = Tables.formatter<MemoryStrings>();
            Write(formatter.Format(_strings, RecordFormatKind.KeyValuePairs));

            result = CheckOffsets(_strings, offsets);
            if(result.Fail)
                return result;
            else
            {
                var count = _strings.EntryCount;
                for(var i=0; i<count; i++)
                    Write(text.format(_strings[i]));
            }

            return result;
        }

        static Outcome CheckOffsets(in MemoryStrings src, ReadOnlySpan<uint> offsets)
        {
            var result = Outcome.Success;
            var count = src.EntryCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var actual = ref strings.offset(src,i);
                ref readonly var expect = ref skip(offsets,i);
                if(actual != expect)
                {
                    result = (false, $"{expect} != {actual}");
                    return result;
                }
            }

            return result;
        }
    }
}