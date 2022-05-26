//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Hashed
    {
        public static bool perfect(ReadOnlySpan<MemorySymbol> src, out Index<HashEntry<MemorySymbol>> dst)
        {
            var codes = src.Select(x => x.HashCode);
            var count = (uint)codes.Length;
            dst = alloc<HashEntry<MemorySymbol>>(count);
            ref var records = ref dst.First;
            for(var i=0u; i<count; i++)
            {
                ref var entry = ref dst[i];
                ref readonly var hash = ref skip(codes,i);
                entry.Key = (hash % count);
                entry.Code = hash;
                entry.Content = skip(src,i);
            }

            var distinct = dst.ToHashSet();
            return distinct.Count == count;
        }

        public static bool perfect(ReadOnlySpan<string> src, out Index<HashEntry<string>> dst)
        {
            dst = sys.empty<HashEntry<string>>();
            var count = (uint)src.Length;
            var n = Pow2.test(count) ? count : (uint)Pow2.next(count);
            var result = perfect(src, x => x, new StringHasher(), out var hashed);
            if(result)
            {
                var codes = hashed.Codes;
                dst = alloc<HashEntry<string>>(n);
                ref var records = ref dst.First;
                for(var j=0u; j<count; j++)
                {
                    ref readonly var hash = ref skip(codes,j);
                    ref var record = ref dst[j];
                    record.Key = hash.Hash % n;
                    record.Code = hash.Hash;
                    record.Content = hash.Source;
                }
                dst.Sort();
            }

            return result;
        }

        public static bool perfect<T>(ReadOnlySpan<T> src, Func<T,string> f, StringHasher hasher, out HashedIndex<T> dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = alloc<HashCode<T>>(count);
            var accumulator = hashset<uint>();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var computed = hasher.Compute(f(input));
                seek(buffer,i) = (input, computed);
                accumulator.Add(computed);
            }
            var collisions = count - (uint)accumulator.Count;
            dst = new HashedIndex<T>(buffer, t => hasher.Compute(f(t)));
            return collisions == 0;
        }

        public static bool perfect<T>(ReadOnlySpan<T> src, Func<T,string> format, out HashedIndex<T> dst)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = alloc<HashCode<T>>(count);
            var accumulator = hashset<uint>();
            var fx = new StringHasher();
            for(var i=0; i<count; i++)
            {
                ref readonly var input = ref skip(src,i);
                var computed = fx.Compute(format(input));
                seek(buffer,i) = (input, computed);
                accumulator.Add(computed);
            }
            var collisions = count - (uint)accumulator.Count;
            dst = new HashedIndex<T>(buffer, t => fx.Compute(format(t)));
            return collisions == 0;
        }
    }
}