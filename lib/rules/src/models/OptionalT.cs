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
        public readonly struct Optional<T>
        {
            readonly Option<T> x;

            [MethodImpl(Inline)]
            public Optional(T value)
            {
                x = value;
            }

            [MethodImpl(Inline)]
            public bool Value(out T dst)
            {
                if(x.Exists && x.Value != null)
                {
                    dst = x.Value;
                    return true;
                }
                else
                {
                    dst = default;
                    return false;
                }
            }

            public static Optional<T> Empty => default;

            [MethodImpl(Inline)]
            public static implicit operator Optional<T>(T value)
                => new Optional<T>(value);
        }
    }
}