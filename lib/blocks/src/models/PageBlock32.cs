//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Reserves 16 pages of memory that covers 2^17 = 131,072 bytes
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = (int)SZ)]
    public struct PageBlock32 : IPageBlock<PageBlock32>
    {
        public const uint SZ = Pow2.T17;

        public const uint PageCount = 32;
    }
}