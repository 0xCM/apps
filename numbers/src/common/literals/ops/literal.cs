//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Literals
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Literal<T> literal<T>(string name, T value)
            => new Literal<T>(name, value);
    }
}