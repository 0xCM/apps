//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [StructLayout(LayoutKind.Sequential, Size=16, Pack =1), ApiHost]
    public unsafe readonly struct ResText
    {
        [MethodImpl(Inline), Op]
        static ResText from(string src)
            => new ResText(new (core.address(src), src.Length));

        [MethodImpl(Inline), Op]
        static ResText from(ReadOnlySpan<char> src)
            => new ResText(new (core.address(src), src.Length));

        static string format(ResText src)
        {
            Span<char> dst = stackalloc char[(int)src.Address.Length];
            var i=0u;
            var count = src.Render(ref i, dst);
            return text.format(slice(dst,0,count));
        }

        public readonly MemoryString Address;

        [MethodImpl(Inline)]
        public ResText(MemoryString src)
        {
            Address = src;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => text.render(Address.Cells, ref i, dst);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ResText(ReadOnlySpan<char> src)
            => from(src);

        [MethodImpl(Inline)]
        public static implicit operator ResText(string src)
            => from(src);
    }
}