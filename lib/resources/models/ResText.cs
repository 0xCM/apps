//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Size=16, Pack =1), ApiHost]
    public readonly struct ResText
    {
        [MethodImpl(Inline), Op]
        public static ResText from(StringAddress src)
            => new ResText(src);

        [MethodImpl(Inline), Op]
        public static ResText from(string src)
            => new ResText(strings.address(src));

        public static string format(ResText src)
        {
            Span<char> dst = stackalloc char[(int)src.Address.Length];
            var i=0u;
            var count = src.Render(ref i, dst);
            return text.format(slice(dst,0,count));
        }

        public readonly StringAddress Address;

        [MethodImpl(Inline)]
        public ResText(StringAddress src)
        {
            Address = src;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => Address.Render(ref i, dst);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ResText(ReadOnlySpan<char> src)
            => new ResText(strings.address(src));

        [MethodImpl(Inline)]
        public static implicit operator ResText(ReadOnlySpan<byte> src)
            => new ResText(strings.address(src));
    }
}