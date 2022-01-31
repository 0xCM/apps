//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
     using static core;

    partial struct SdmOps
    {
        public static Index<SdmOpCodeDetail> deduplicate(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var outgoing = span<SdmOpCodeDetail>(count);
            var j = 0u;
            var logicalKeys = hashset<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var logicalKey = input.Sig.Format() + input.OpCode.Format();
                if(logicalKeys.Contains(logicalKey))
                    continue;
                else
                    logicalKeys.Add(logicalKey);

                seek(outgoing, j) = input;
                seek(outgoing, j).OpCodeKey = j;
                j++;

            }
            return slice(outgoing, 0, j).ToArray();
        }

    }
}