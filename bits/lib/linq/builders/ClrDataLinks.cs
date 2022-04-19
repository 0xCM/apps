//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using static ClrDataLinks;

    public static class ClrDataLinks
    {
        public static MemberArrow define<S,T>(Expression<Func<S,object>> s, Expression<Func<T,object>> t)
            => new MemberArrow(s.GetDataMember(), t.GetDataMember());

        public static ClrDataLinkBuilder<S,T> build<S,T>()
            => new ClrDataLinkBuilder<S,T>();
    }

    public class ClrDataLinkBuilder<S,T>
    {
        HashSet<MemberArrow> Arrows {get;}
            = new HashSet<MemberArrow>();

        public ClrDataLinkBuilder<S,T> Include(Expression<Func<S, object>> s, Expression<Func<T,object>> t)
        {
            Arrows.Add(define(s, t));
            return this;
        }

        public ClrDataLinkBuilder<S,T> Include(params (Expression<Func<S,object>> SourceMember, Expression<Func<T, object>> TargetMember)[] pairs)
        {
            foreach (var association in pairs.Select(p => define(p.SourceMember, p.TargetMember)))
                Arrows.Add(association);
            return this;
        }

        public MemberArrows<S,T> Complete()
            => new MemberArrows<S,T>(Arrows);

        public static implicit operator MemberArrows<S,T>(ClrDataLinkBuilder<S,T> builder)
            => builder.Complete();
    }
}