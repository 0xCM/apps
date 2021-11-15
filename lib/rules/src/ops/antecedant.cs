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
        public static Antecedant<T> antecedant<T>(TermId id, Index<T> terms)
            where T : IEquatable<T>
                => new Antecedant<T>(id, terms);
    }
}