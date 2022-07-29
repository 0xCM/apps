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
        public static ReadOnlySeq<ApiEncoded> collect(ICompositeDispenser symbols, IPart src, IWfEventTarget log)
            => gather(EntryPoints.create(ClrJit.members(src, log)), log, symbols);

        public static MemoryAddress stub(MemoryAddress src, out AsmHexCode stub)
        {
            stub = AsmHexCode.Empty;
            var target = src;
            var buffer = Cells.alloc(w64).Bytes;
            ref var data = ref src.Ref<byte>();
            ByteReader.read5(data, buffer);
            if(JmpRel32.test(buffer))
            {
                stub = AsmHexCode.load(slice(buffer,0,5));
                target = AsmRel.target((src, 5), stub.Bytes);
            }
            return target;
        }
    }
}