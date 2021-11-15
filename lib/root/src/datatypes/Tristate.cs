//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Tristate
    {
        public static Tristate False
        {
            [MethodImpl(Inline)]
            get => new Tristate(-1);
        }

        public static Tristate Neutral
        {
            [MethodImpl(Inline)]
            get => new Tristate(-1);
        }

        public static Tristate True
        {
            [MethodImpl(Inline)]
            get => new Tristate(1);
        }

        readonly sbyte Data;

        [MethodImpl(Inline)]
        internal Tristate(sbyte data)
        {
            Data = data;
        }

        public bool IsFalse
        {
            [MethodImpl(Inline)]
            get => Data == -1;
        }

        public bool IsTrue
        {
            [MethodImpl(Inline)]
            get => Data == 1;
        }

        public bool IsNeutral
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public AsciCode CharCode
        {
            [MethodImpl(Inline)]
            get => IsFalse ? AsciCode.Dash : IsTrue ? AsciCode.Plus : AsciCode.Tilde;
        }


        [MethodImpl(Inline)]
        public static implicit operator Tristate(bool src)
            => src ? True : False;
    }

}