//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Defines a collection of directed member associations
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    public sealed class MemberArrows<S,T> : IEnumerable<MemberArrow>
    {
        HashSet<MemberArrow> Associations {get;}

        public MemberArrows(IEnumerable<MemberArrow> associations)
            => Associations = associations.ToHashSet();

        public IEnumerator<MemberArrow> GetEnumerator()
            => Associations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => Associations.GetEnumerator();
    }
}