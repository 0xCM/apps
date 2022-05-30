//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Symbolic
    {
        [MethodImpl(Inline), Op, Closures(UInt64k)]
        public static bit deposit<T>(in T src, ref SymStore<T> dst, out SymRef s)
            => dst.Deposit(src, out s);
    }
}