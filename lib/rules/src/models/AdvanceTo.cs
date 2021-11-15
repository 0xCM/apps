//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct AdvanceTo
        {
            public Marker Marker {get;}

            [MethodImpl(Inline)]
            public AdvanceTo(Marker marker)
            {
                Marker = marker;
            }

            [MethodImpl(Inline)]
            public static implicit operator AdvanceTo(Marker marker)
                => new AdvanceTo(marker);
        }
    }
}