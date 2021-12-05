//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;

    using static core;

    public sealed class CBag<T> : IReceiver<T>
    {
        readonly ConcurrentBag<T> Data;

        public CBag()
        {
            Data = new();
        }


        public CBag(ReadOnlySpan<T> src)
            : this()
        {
            Add(src);
        }

        public void Deposit(in T src)
        {
            Data.Add(src);
        }

        public void Add(ReadOnlySpan<T> src)
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
                Data.Add(skip(src,i));
        }

        public Index<T> Emit()
        {
            var data = Data.ToArray();
            Data.Clear();
            return data;
        }
    }
}