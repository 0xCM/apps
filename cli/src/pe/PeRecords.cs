//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PeRecords
    {
        [MethodImpl(Inline), Op]
        public static PeDirInfo directory(Address32 rva, uint size)
        {
            var dst = new PeDirInfo();
            dst.Rva = rva;
            dst.Size = size;
            return dst;
        }
    }
}