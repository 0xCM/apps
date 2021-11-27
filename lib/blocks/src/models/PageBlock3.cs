//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 3 pages of memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock3 : IPageBlock<PageBlock3>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 3;
    }
}