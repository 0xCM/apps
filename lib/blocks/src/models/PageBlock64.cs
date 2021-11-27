//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 16 pages of memory that covers 2^18 = 262,144 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock64 : IPageBlock<PageBlock64>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 64;
    }
}