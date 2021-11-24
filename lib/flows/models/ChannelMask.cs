//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ChannelMask : IChannelMask<ChannelMask>
    {
        public ulong Value {get;}

        public MaskKind Kind {get;}

        [MethodImpl(Inline)]
        public ChannelMask(MaskKind kind, ulong value)
        {
            Kind = kind;
            Value = value;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Kind == 0 || Value == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Kind != 0;
        }

        public string Format()
            => flows.format(this);


        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ChannelMask((MaskKind kind, ulong value) src)
            => new ChannelMask(src.kind, src.value);

        [MethodImpl(Inline)]
        public static implicit operator ChannelMask(Paired<MaskKind,ulong> src)
            => new ChannelMask(src.Left, src.Right);

        public static ChannelMask Empty => default;
    }
}