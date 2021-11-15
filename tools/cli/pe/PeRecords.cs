//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;

    [RecordGroup]
    public readonly partial struct PeRecords
    {
        [MethodImpl(Inline), Op]
        public static DirectoryInfo directory(Address32 rva, uint size)
        {
            var dst = new DirectoryInfo();
            dst.Rva = rva;
            dst.Size = size;
            return dst;
        }
    }
}