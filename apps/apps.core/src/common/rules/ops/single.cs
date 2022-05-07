//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SingleRule<T> single<T>(T term)
            => new SingleRule<T>(term);
    }
}