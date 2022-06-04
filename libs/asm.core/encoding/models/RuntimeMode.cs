//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct RuntimeMode
    {
        public RuntimeModeKind Kind {get;}

        [MethodImpl(Inline)]
        public RuntimeMode(RuntimeModeKind kind)
        {
            Kind = kind;
        }

        [MethodImpl(Inline)]
        public static implicit operator RuntimeMode(RuntimeModeKind src)
            => new RuntimeMode(src);

        [MethodImpl(Inline)]
        public static implicit operator RuntimeModeKind(RuntimeMode src)
            => src.Kind;
    }
}