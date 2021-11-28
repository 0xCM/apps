//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 8 pages of memory that covers 2^15 = 32,768 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock8 : IPageBlock<PageBlock8>
    {
        public const uint SZ = Pow2.T15;

        public const uint PageCount = 8;
    }
}