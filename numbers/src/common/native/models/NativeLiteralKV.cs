//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct NativeLiteral<K,V>
        where K : unmanaged
        where V : unmanaged
    {
        public readonly K Name;

        public readonly V Value;

        [MethodImpl(Inline)]
        public NativeLiteral(K name, V value)
        {
            Name = name;
            Value = value;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => core.bytes(Value);
        }
    }
}