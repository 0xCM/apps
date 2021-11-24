//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct MergeMask : IChannelMask<MergeMask>
    {
        public ulong Value {get;}

        [MethodImpl(Inline)]
        public MergeMask(ulong value)
        {
            Value = value;
        }

        public MaskKind Kind
            => MaskKind.Merge;

        public string Format()
            => flows.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MergeMask(ulong src)
            => new MergeMask(src);

        [MethodImpl(Inline)]
        public static implicit operator ChannelMask(MergeMask src)
            => new ChannelMask(MaskKind.Merge, src.Value);
    }
}