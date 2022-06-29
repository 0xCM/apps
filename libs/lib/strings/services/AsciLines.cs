//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using D = DecimalDigitFacets;

    [ApiHost]
    public class AsciLines
    {

        [MethodImpl(Inline), Op]
        public static CmdFlagSpec flag(string name, string desc)
            => new CmdFlagSpec(name, desc);

        [MethodImpl(Inline), Op]
        static bool test(Base10 @base, byte c)
            => (DecimalDigitValue)c >= D.MinDigit && (DecimalDigitValue)c <= D.MaxDigit;

        [Op]
        public static bool number(ReadOnlySpan<byte> src, out uint j, out LineNumber dst)
        {
            j=0;
            dst = 0;
            const char Delimiter = Chars.Colon;
            const byte LastIndex = 8;
            const byte ContentLength = 9;

            var result = false;
            var storage = CharBlock8.Null;
            var buffer = storage.Data;

            while(j++ <= LastIndex)
            {
                ref readonly var c = ref skip(src, j);
                if(test(base10, c))
                    seek(buffer, j) = (char)c;
                else if(c == Delimiter && j==LastIndex)
                {
                    result = uint.TryParse(buffer, out var n);
                    if(result)
                        dst = n;
                    break;
                }
                else
                    break;
            }
            return result;
        }

    }
}