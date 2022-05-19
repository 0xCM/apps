//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeLiteral<T> : INativeLiteral<T>
        where T : unmanaged
    {
        public readonly Label Name;

        public readonly T Value;

        [MethodImpl(Inline)]
        public NativeLiteral(Label name, T value)
        {
            Name = name;
            Value = value;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => core.bytes(Value);
        }

        T INativeLiteral<T>.Value
            => Value;

        Label INativeLiteral.Name
            => Name;

        public static implicit operator NativeLiteral<T>((Label name, T value) src)
            => new NativeLiteral<T>(src.name, src.value);
    }
}