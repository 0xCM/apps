//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct lang
    {
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
    }
}