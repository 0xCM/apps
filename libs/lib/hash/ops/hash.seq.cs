//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static MarvinHash;

    partial class HashCodes
    {
        [MethodImpl(Inline), Op]
        public static uint hash(string src)
            => marvin(text.ifempty(src,EmptyString));

        [MethodImpl(Inline), Op]
        public static uint hash(ReadOnlySpan<char> src)
            => marvin(src);

        [MethodImpl(Inline), Op]
        public static uint hash(ReadOnlySpan<byte> src)
            => marvin(src);
    }
}