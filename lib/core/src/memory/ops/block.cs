//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    unsafe partial struct memory
    {
        [Op]
        public static unsafe MemoryBlock block(byte* pSrc, ByteSize size)
        {
            var slice = MemorySpan.create(pSrc,size);
            return new MemoryBlock(slice.Origin, slice.Edit.ToArray());
        }
    }
}