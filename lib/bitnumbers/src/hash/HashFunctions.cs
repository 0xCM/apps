//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public readonly struct HashFunctions
    {
        [MethodImpl(Inline), Op]
        public static StringHasher strings()
            => default(StringHasher);

        public static uint collisions<S,T>(Index<S> src, Func<S,T> hash)
            where T : unmanaged
        {
            var accumulator = hashset<T>();
            var count = src.Count;
            var view = src.View;
            for(var i=0; i<count; i++)
                accumulator.Add(hash(skip(view, i)));
            return count - (uint)accumulator.Count;
        }

        public static Outcome perfect(ReadOnlySpan<MemorySymbol> src, out Index<HashEntry> dst)
        {
            var result = Outcome.Success;
            dst = default;
            var codes = src.Map(x => x.HashCode);
            var count = (uint)codes.Length;
            dst = alloc<HashEntry>(count);
            ref var records = ref dst.First;
            for(var i=0u; i<count; i++)
            {
                ref var record = ref seek(records,i);
                ref readonly var hash = ref skip(codes,i);
                record.Key = (hash % count);
                record.Code = hash;
                record.Content = skip(src,i).Expr.Text;
            }

            var distinct = hashset(dst.Storage);
            if(distinct.Count != count)
                result = (false, "Imperfect");

            return result;
        }

        public static Outcome perfect(ReadOnlySpan<string> src, out Index<HashEntry> dst)
        {
            var result = Outcome.Success;
            var count = (uint)src.Length;
            var n = Pow2.test(count) ? count : (uint)Pow2.next(count);
            dst = default;
            try
            {
                var codes = perfect(src, x => x, HashFunctions.strings()).Codes;
                dst = alloc<HashEntry>(n);
                ref var records = ref dst.First;
                for(var j=0u; j<count; j++)
                {
                    ref readonly var hash = ref skip(codes,j);
                    ref var record = ref seek(records,j);
                    record.Key = hash.Hash % n;
                    record.Code = hash.Hash;
                    record.Content = hash.Source;
                }
                dst.Sort();
            }
            catch(Exception e)
            {
                result = e;
            }

            return result;
        }

        public static HashedIndex<T> perfect<T>(ReadOnlySpan<T> src, Func<T,string> f, StringHasher hasher)
        {
            var count = src.Length;
            var buffer = alloc<HashCode<T>>(count);
            ref var dst = ref first(buffer);
            var accumulator = hashset<uint>();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var computed = hasher.Compute(f(input));
                seek(dst,i) = (input, computed);
                accumulator.Add(computed);
            }
            var collisions = count - (uint)accumulator.Count;
            if(collisions != 0)
                @throw("Imperfect");
            return new HashedIndex<T>(buffer, t => hasher.Compute(f(t)));
        }

        public static HashedIndex<T> perfect<T>(ReadOnlySpan<T> src, Func<T,string> format)
        {
            var count = src.Length;
            var buffer = alloc<HashCode<T>>(count);
            ref var dst = ref first(buffer);
            var accumulator = hashset<uint>();
            var algorithm = strings();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var computed = algorithm.Compute(format(input));
                seek(dst,i) = (input, computed);
                accumulator.Add(computed);
            }
            var collisions = count - (uint)accumulator.Count;
            if(collisions != 0)
                @throw("Imperfect");
            return new HashedIndex<T>(buffer, t => algorithm.Compute(format(t)));
        }
    }
}