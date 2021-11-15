//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    /// <summary>
    /// Designates a rectangular multi-line text segment
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack =1)]
    public readonly struct LineBlock
    {
        /// <summary>
        /// The first line included in the block
        /// </summary>
        public readonly LineNumber MinLine;

        /// <summary>
        /// The first column of the first line
        /// </summary>
        public readonly ushort MinCol;

        /// <summary>
        /// The last line included in the block
        /// </summary>
        public readonly LineNumber MaxLine;

        /// <summary>
        /// The last column of the last line
        /// </summary>
        public readonly ushort MaxCol;

        [MethodImpl(Inline)]
        public LineBlock(LineNumber minL, ushort minC, LineNumber maxL, ushort maxC)
        {
            MinLine = minL;
            MinCol = minC;
            MaxLine = maxL;
            MaxCol = maxC;
        }
    }
}