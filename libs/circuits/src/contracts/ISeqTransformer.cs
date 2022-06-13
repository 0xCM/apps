//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface ISeqTransformer<S,T> : ITransformer<S,T>
    {
        uint Map(ReadOnlySpan<S> src, Span<T> dst)
        {
            var count = (uint)min(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = Map(skip(src,i));
            return count;
        }
    }
}