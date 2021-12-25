//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 7 pages of memory
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)Size)]
    public struct PageBlock7 : IPageBlock<PageBlock6>
    {
        public const uint Size = PageCount*PageSize;

        public const uint PageCount = 7;
    }
}