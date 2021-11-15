//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RuleModels
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Optional<T> optional<T>()
            => Optional<T>.Empty;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Optional<T> optional<T>(T value)
            => new Optional<T>(value);
    }
}