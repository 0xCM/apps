//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        public readonly struct Delimit<T>
            where T : IEquatable<T>
        {
            public T Marker {get;}

            [MethodImpl(Inline)]
            public Delimit(T marker)
            {
                Marker = marker;
            }

            [MethodImpl(Inline)]
            public bool Test(T src)
                => src.Equals(Marker);

            [MethodImpl(Inline)]
            public static implicit operator Delimit<T>(T src)
                => new Delimit<T>(src);
        }
    }
}