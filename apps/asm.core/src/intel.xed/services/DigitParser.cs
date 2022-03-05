//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using SQ = SymbolicQuery;

    struct DigitParser
    {
        CharBlock32 Storage;

        [MethodImpl(Inline)]
        Span<char> DigitBuffer()
        {
            Storage = CharBlock32.Null;
            return Storage.Data;
        }

        public ReadOnlySpan<char> Parse(Base10 @base, string src)
        {
            var dst = DigitBuffer();
            var count = SQ.digits(@base,src,dst);
            if(count > 0)
                return slice(dst,0,count);
            else
                return default;
        }
    }
}