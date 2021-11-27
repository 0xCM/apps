//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 4 pages of memory that cover 2^14 = 16,384 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock4 : IPageBlock<PageBlock4>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 4;
    }
}