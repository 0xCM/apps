//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ApiCode
    {
        public static MemoryAddress stub(MemoryAddress src, out AsmHexCode stub)
        {
            stub = AsmHexCode.Empty;
            var target = src;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref src.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(JmpRel32.test(buffer))
            {
                stub = AsmHexCode.asmhex(slice(buffer,0,5));
                target = AsmRel32.target((src, 5), stub.Bytes);
            }
            return target;
        }
    }
}