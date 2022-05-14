//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedImport
    {
        public static unsafe void decode(MemoryAddress src, uint size, out CharBlock32 dst)
        {
            var input = core.cover(src.Pointer<byte>(), size);
            dst = CharBlock32.Null;
            var buffer = recover<ushort>(dst.Data);
            if(size == 32)
                gcpu.vstore(Asci.decode(cpu.vload(w256, input)), buffer);
            else
            {
                for(var i=0; i<size; i++)
                    seek(buffer,i) = skip(input,i);
            }
        }

        public static unsafe void decode(MemoryFile src, uint blocks, uint blocksize, uint remainder)
        {
            var counter = 0u;
            var seg = src.Segment();
            var offset = src.BaseAddress;
            var dst = CharBlock32.Null;
            for(var i=0u; i<blocks; i++)
            {
                decode(offset, blocksize, out dst);
                offset = offset + blocksize;
            }
            decode(offset,remainder, out dst);
        }
    }
}