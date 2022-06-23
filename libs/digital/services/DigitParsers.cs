//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly partial struct DigitParsers
    {
        public static ISpanSeqParser<char,char> chars(Base2 @base)
            => new Base2Digits();

        public static ISpanSeqParser<char,char> chars(Base10 @base)
            => new Base10Digits();

        public static ISpanSeqParser<char,char> chars(Base16 @base)
            => new Base16Digits();

        public static ISpanSeqParser<char,DecimalDigitValue> values(Base10 @base)
            => new Base10SeqParser();

        public static ISpanValueParser<char,uint> value(Base16 @base, W32 w)
            => new Base16U32Parser();

        public static uint digits<B>(ReadOnlySpan<char> src, Span<char> dst)
            where B : unmanaged, INumericBase
        {
            var count = 0u;
            if(typeof(B) == typeof(Base2))
                count = Digital.digits(@base2, src, dst);
            else if(typeof(B) == typeof(Base10))
                count = Digital.digits(@base10, src, dst);
            else if(typeof(B) == typeof(Base16))
                count = Digital.digits(@base16, src, dst);
            else
                throw no<B>();
            return count;
        }
    }
}