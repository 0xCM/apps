//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 6 pages of memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock6 : IPageBlock<PageBlock6>
    {
        public const uint SZ = PageCount*PageSize;

        public const uint PageCount = 6;
    }
}