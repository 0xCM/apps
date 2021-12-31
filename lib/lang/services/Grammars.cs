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
    using Lang;

    [ApiHost]
    public readonly partial struct Grammars
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Atom<K> atom<K>(uint key, K value)
            where K : unmanaged
                => new Atom<K>(key, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Product<K> product<K>(K left, K right)
            => new Product<K>(left,right);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Sum<K> sum<K>(K left, K right)
            => new Sum<K>(left, right);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Sum<Product<K>> sum<K>(Product<K> left, Product<K> right)
            => new Sum<Product<K>>(left,right);

        [Op, Closures(Closure)]
        public static Sum<Atoms<K>> sum<K>(Atoms<K> src)
            where K : unmanaged
        {
            var empty = Atoms<K>.Empty;
            if(src.IsEmpty)
                return new Sum<Atoms<K>>(empty, empty);
            else
            {
                if(src.Length == 1)
                    return new Sum<Atoms<K>>(src, empty);
                else
                    return new Sum<Atoms<K>>(new Atoms<K>(src.First), new Atoms<K>(core.slice(src.Members,1).ToArray()));
            }
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Sum<Atoms<K>> sum<K>(Atoms<K> left, Atoms<K> right)
            where K : unmanaged
                => new Sum<Atoms<K>>(left,right);

        /// <summary>
        /// Defines an alphabet over a caller-supplied symbol sequence
        /// </summary>
        /// <param name="name">The alphabet name</param>
        /// <param name="src">The defining symbols</param>
        /// <typeparam name="K">The symbol kind</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Alphabet<K> alphabet<K>(Label name, K[] src)
            where K : unmanaged
                => new Alphabet<K>(name, src);

        /// <summary>
        /// Defines an alphabet over a caller-supplied symbol sequence
        /// </summary>
        /// <param name="name">The alphabet name</param>
        /// <param name="src">The defining symbols</param>
        /// <typeparam name="K">The symbol kind</typeparam>
        public static Alphabet<K> alphabet<K>(Label name, ReadOnlySpan<K> src)
            where K : unmanaged
                => new Alphabet<K>(name, src.ToArray());

        /// <summary>
        /// Defines an alphabet over a parametrically-defined symbol sequence
        /// </summary>
        /// <typeparam name="K">The symbol kind</typeparam>
        public static Alphabet<K> alphabet<K>()
            where K : unmanaged, Enum
                => alphabet(typeof(K).Name, Symbols.index<K>().Kinds);

        /// <summary>
        /// Defines an alphabet over a parametrically-defined symbol sequence
        /// </summary>
        /// <param name="name">The alphabet name</param>
        /// <typeparam name="K">The symbol kind</typeparam>
        public static Alphabet<K> alphabet<K>(Label name)
            where K : unmanaged, Enum
                => alphabet(name, Symbols.index<K>().Kinds);


        [Op, Closures(Closure)]
        public static Atoms<K> concat<K>(Atoms<K> a, Atoms<K> b)
            where K : unmanaged
        {
            var ka = a.Count;
            var kb = b.Count;
            var k=0u;
            var length = a.Count + b.Count;
            var dst = alloc<K>(length);
            for(var i=0; i<ka; i++)
                seek(dst,k++) = a[i];
            for(var i=0; i<kb; i++)
                seek(dst,k++) = b[i];
            return default;
        }

        internal static string format<K>(in Alphabet<K> src)
            where K : unmanaged
        {
            var dst = text.buffer();
            var count = src.MemberCount;
            dst.AppendFormat("{0}:{{", src.Name);
            for(var i=0; i<count; i++)
                dst.Append(src[i].ToString());
            dst.Append("}");
            return dst.Emit();
        }

    }
}