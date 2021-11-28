//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 1 pages of memory that covers 2^12 = 4096 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock1 : IPageBlock<PageBlock1>
    {
        public const uint SZ = PageSize;

        public const uint PageCount = 1;
    }
}