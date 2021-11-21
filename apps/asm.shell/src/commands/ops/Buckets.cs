//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    public readonly struct Buckets
    {

        public static Bucket<T> bucket<T>(uint capacity, string label = null)
            => new Bucket<T>(capacity, label);

        public static Bucket<L,T> bucket<L,T>(L label, uint capacity)
            => new Bucket<L,T>(capacity, label);

        public static Bucket<L,T> bucket<L,T>(L label, T[] items)
            => new Bucket<L,T>(items, label);

        public static BucketList<T> list<T>(uint capacity)
            => new BucketList<T>(capacity);

        public static BucketList<T> list<T>(params Bucket<T>[] src)
            => new BucketList<T>(src);

        public static BucketList<L,T> list<L,T>(params Bucket<L,T>[] src)
            => new BucketList<L,T>(src);

        public static BucketList<uint,SeqTerm<string>> seq(ReadOnlySpan<string> src)
        {
            var slots = dict<uint,DataList<SeqTerm<string>>>();
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var s = ref skip(src,i);
                var length = (uint)s.Length;
                var term = new SeqTerm<string>(i, s);
                if(slots.TryGetValue(length, out var list))
                    list.Add(term);
                else
                {
                    slots[length] = new DataList<SeqTerm<string>>();
                    slots[length].Add(term);
                }
            }

            var buckets = slots.Map(x => (x.Key,x.Value)).OrderBy(x => x.Key);
            return Buckets.list(buckets.Map(x => Buckets.bucket(x.Key, x.Value.Array())));
        }
    }
}