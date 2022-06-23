//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static DelimitedSeq;

    [Free]
    public class DelimitedSeq<S,T> : ReadOnlySeq<DelimitedSeq<S,T>,T>
    {
        public readonly string Delimiter;

        public readonly int CellPad;

        public readonly Fence<char>? Fence;

        [MethodImpl(Inline)]
        public DelimitedSeq(T[] src, char delimiter, int pad, Fence<char>? fence)
            : base(src)
        {
            Delimiter = delimiter.ToString();
            CellPad = pad;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public DelimitedSeq(T[] src, string delimiter, int pad, Fence<char>? fence)
            : base(src)
        {
            Delimiter = delimiter;
            CellPad = pad;
            Fence = fence;
        }

        [MethodImpl(Inline)]
        public DelimitedSeq(T[] src)
            : base(src)
        {
            Delimiter = DefaultDelimiter.ToString();
            CellPad = 0;
            Fence = null;
        }


        [MethodImpl(Inline)]
        public string Format()
        {
            var content = text.delimit(Data.View, Delimiter, CellPad);
            if(Fence != null && text.nonempty(content))
                return text.enclose(content, Fence.Value);
            else
                return content;
        }

        public override string ToString()
            => Format();
    }
}