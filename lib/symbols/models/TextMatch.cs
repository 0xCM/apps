//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TextMatch
    {
        public TextMarker Marker {get;}

        public LineOffset Match {get;}

        [MethodImpl(Inline)]
        public TextMatch(TextMarker marker, LineOffset match)
        {
            Marker = marker;
            Match = match;
        }
    }
}