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

    public readonly struct ScalarValue<T> : IScalarValue<T>
        where T : unmanaged, IEquatable<T>
    {
        public T Value {get;}

        public BitWidth ContentWidth {get;}

        [MethodImpl(Inline)]
        public ScalarValue(T value, BitWidth content = default)
        {
            Value = value;
            ContentWidth = content == 0 ? core.width<T>() : content;
        }

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();
    }
}