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
        public readonly struct AdvanceTo<T>
        {
            public Marker<T> Marker {get;}

            [MethodImpl(Inline)]
            public AdvanceTo(T marker)
            {
                Marker = marker;
            }

            [MethodImpl(Inline)]
            public AdvanceTo(Marker<T> marker)
            {
                Marker = marker;
            }

            [MethodImpl(Inline)]
            public static implicit operator AdvanceTo<T>(T marker)
                => new AdvanceTo<T>(marker);

            [MethodImpl(Inline)]
            public static implicit operator AdvanceTo(AdvanceTo<T> src)
                => new AdvanceTo(src.Marker);
        }
    }
}