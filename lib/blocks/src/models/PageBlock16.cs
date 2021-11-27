//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 16 pages of memory that covers 2^16 = 65,536 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock16 : IPageBlock<PageBlock16>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 16;
    }
}