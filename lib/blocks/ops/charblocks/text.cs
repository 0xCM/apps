//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CharBlocks
    {
        [MethodImpl(Inline)]
        public static text<C> text<C>(in C src)
            where C : unmanaged, ICharBlock<C>
                => new text<C>(src);

        [MethodImpl(Inline), Op]
        public static text<CharBlock1> text(N1 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock2> text(N2 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock3> text(N3 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock4> text(N4 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock5> text(N5 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock6> text(N6 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock7> text(N7 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock8> text(N8 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock9> text(N9 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock10> text(N10 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock11> text(N11 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock12> text(N12 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock13> text(N13 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock14> text(N14 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock15> text(N15 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock16> text(N16 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock24> text(N24 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock32> text(N32 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock48> text(N48 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock64> text(N64 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock80> text(N80 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock84> text(N84 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock128> text(N128 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock256> text(N256 n, string src = EmptyString)
            => src;

        [MethodImpl(Inline), Op]
        public static text<CharBlock512> text(N512 n, string src = EmptyString)
            => src;
    }
}