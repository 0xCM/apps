//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 2 pages of memory that cover 2^13 = 8,192 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size)]
    public struct PageBlock2 : IPageBlock<PageBlock2>
    {
        public const uint Size = PageCount*PageSize;

        public const uint PageCount = 2;
    }
}