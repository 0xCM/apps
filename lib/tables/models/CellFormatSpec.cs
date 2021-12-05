//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines formatting specifications for a cell
    /// </summary>
    public readonly struct CellFormatSpec
    {
        public RenderPattern<dynamic> Pattern {get;}

        public RenderWidth Width {get;}

        [MethodImpl(Inline)]
        public CellFormatSpec(string pattern, RenderWidth width)
        {
            Pattern = pattern;
            Width = width;
        }
    }
}