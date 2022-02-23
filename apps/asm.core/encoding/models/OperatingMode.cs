//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct OperatingMode
    {
        public OpModeKind Kind {get;}

        [MethodImpl(Inline)]
        public OperatingMode(OpModeKind kind)
        {
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator OperatingMode(OpModeKind src)
            => new OperatingMode(src);

        [MethodImpl(Inline)]
        public static implicit operator OpModeKind(OperatingMode src)
            => src.Kind;
    }
}