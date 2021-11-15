//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using K = ApiClasses;

    partial struct CalcHosts
    {
        [Closures(AllNumeric), Parse]
        public readonly struct Parse<T> : ITextParserFunc<T>
            where T : unmanaged
        {
            [MethodImpl(Inline)]
            public readonly T Invoke(string a)
            {
                if(NumericParser.create<T>().Parse(a, out var dst))
                    return dst;
                else
                    return default;
            }
        }
    }
}