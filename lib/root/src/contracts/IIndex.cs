// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    using static minicore;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IIndex<T> : ISeq<T>, IMeasured, IEnumerable<T>, ITextual
    {
        T[] Storage {get;}

        char CellDelimiter
            => Chars.Semicolon;
        string ITextual.Format()
            => string.Format("({0}:{1})*", typeof(T).Name, Storage?.Length ?? 0);

        Span<T> Edit
            => Storage;

        ReadOnlySpan<T> ISeq<T>.View
            => Storage;

        int IMeasured.Length
            => Storage?.Length ?? 0;

        ref T this[int index]
            => ref seek(Storage,index);

        ref T Lookup(int index)
            => ref seek(Storage, index);

        ref T First
            => ref first(Storage);

        ref T Last
            => ref seek(Storage,Length - 1);

        bool INullity.IsEmpty
            => Length == 0;

        IEnumerator IEnumerable.GetEnumerator()
            => Storage.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => Storage.ToList().GetEnumerator();
    }

    public interface IIndex<K,T> : IIndex<T>
        where K : unmanaged
    {
        ref T this[K index] {get;}

        ref T IIndex<T>.this[int index]
            => ref this[@as<int,K>(index)];

        ref T Lookup(K index)
            => ref this[index];
    }

    public interface IIndex<H,I,T> : IIndex<I,T>
        where I : unmanaged
        where H : struct, IIndex<H,I,T>
    {

    }
}