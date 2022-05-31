//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;
    using System.Collections;

    public interface IBinaryResLookup : IContentIndex<BinaryRes>
    {
    }

    /// <summary>
    /// Characterizes a finite container over sequentially-indexed discrete content - an array
    /// </summary>
    /// <typeparam name="T">The element type</typeparam>
    [Free]
    public interface IContentIndex<T> : IContented<T[]>, IMeasured, IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator()
            => Content.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Content.ToList().GetEnumerator();

        int IMeasured.Length
            => Content?.Length ?? 0;

        ref T this[int index]
            => ref Content[index];

        ref T Lookup(int index)
            => ref this[index];
    }
}