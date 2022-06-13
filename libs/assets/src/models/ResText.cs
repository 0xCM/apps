//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = TextAssets;

    public unsafe readonly struct ResText
    {
        public readonly MemoryString Address;

        [MethodImpl(Inline)]
        public ResText(MemoryString src)
        {
            Address = src;
        }

        [MethodImpl(Inline)]
        public uint Render(ref uint i, Span<char> dst)
            => api.render(Address.Cells, ref i, dst);

        public string Format()
            => api.format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ResText(ReadOnlySpan<char> src)
            => api.restext(src);

        [MethodImpl(Inline)]
        public static implicit operator ResText(string src)
            => api.restext(src);
    }
}