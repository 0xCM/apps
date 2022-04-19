//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using K = TextEncodingKind;

    public readonly struct TextEncodings
    {
        public static AsciPoints Asci => default;

        public static Utf8Points Utf8 => default;

        public static UnicodePoints Unicode => default;
    }

    public readonly struct AsciPoints : ITextEncodingKind<AsciPoints>
    {
        public static AsciPoints Value => default;

        public K Kind => K.Asci;
    }

    public readonly struct Utf8Points : ITextEncodingKind<Utf8Points>
    {
        public static Utf8Points Value => default;

        public K Kind => K.Utf8;
    }

    public readonly struct UnicodePoints : ITextEncodingKind<UnicodePoints>
    {
        public static UnicodePoints Value => default;

        public K Kind => K.Unicode;
    }

    public readonly struct Utf32Points : ITextEncodingKind<Utf32Points>
    {
        public K Kind => K.Utf32;
    }
}