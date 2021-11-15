//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Sign
    {
        public PolarityKind Kind {get;}

        [MethodImpl(Inline)]
        public Sign(PolarityKind kind)
            => Kind = kind;

        [MethodImpl(Inline)]
        public static implicit operator Sign(PolarityKind src)
            => new Sign(src);

        [MethodImpl(Inline)]
        public static implicit operator Sign(sbyte src)
            => new Sign(src < 0 ? PolarityKind.Left : PolarityKind.Right);

        [MethodImpl(Inline)]
        public static implicit operator Sign(short src)
            => new Sign(src < 0 ? PolarityKind.Left : PolarityKind.Right);

        [MethodImpl(Inline)]
        public static implicit operator Sign(int src)
            => new Sign(src < 0 ? PolarityKind.Left : PolarityKind.Right);

        [MethodImpl(Inline)]
        public static implicit operator Sign(long src)
            => new Sign(src < 0 ? PolarityKind.Left : PolarityKind.Right);

        [MethodImpl(Inline)]
        public static implicit operator PolarityKind(Sign src)
            => src.Kind;

        [MethodImpl(Inline)]
        public static explicit operator char(Sign src)
            => src.Kind == PolarityKind.Left ? Chars.Dash : Chars.Plus;
    }
}