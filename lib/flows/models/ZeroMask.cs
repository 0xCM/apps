//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ZeroMask : IChannelMask<ZeroMask>
    {
        public ulong Value {get;}

        [MethodImpl(Inline)]
        public ZeroMask(ulong value)
        {
            Value = value;
        }

        public MaskKind Kind
            => MaskKind.Zero;

        public string Format()
            => flows.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ZeroMask(ulong src)
            => new ZeroMask(src);

        [MethodImpl(Inline)]
        public static implicit operator ChannelMask(ZeroMask src)
            => new ChannelMask(MaskKind.Merge, src.Value);
    }
}