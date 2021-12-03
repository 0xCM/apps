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

    [ApiHost]
    public readonly partial struct TS
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static DomainKey domain(uint kind, uint id)
            => new DomainKey(kind, id);

        [MethodImpl(Inline), Op]
        public static SourceKey source(DomainKey domain, uint id)
            => new SourceKey(domain,id);

        [MethodImpl(Inline), Op]
        public static TargetKey target(DomainKey domain, uint id)
            => new TargetKey(domain,id);

        [MethodImpl(Inline), Op]
        public static ProjectionKey projection(uint id, SourceKey src, TargetKey dst)
            => new ProjectionKey(id, src, dst);

        [MethodImpl(Inline)]
        public static SeqProjector<S,T> projector<S,T>(Func<S,T> f)
            => new SeqProjector<S,T>(f);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SourceKey untype<T>(SourceKey<T> src, Func<SourceKey<T>,uint> f)
            => new SourceKey(src.Domain, f(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TargetKey untype<T>(TargetKey<T> src, Func<TargetKey<T>,uint> f)
            => new TargetKey(src.Domain, f(src));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static SourceKey<T> source<T>(DomainKey d, T rep)
            => new SourceKey<T>(d,rep);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static TargetKey<T> target<T>(DomainKey d, T rep)
            => new TargetKey<T>(d,rep);

        [MethodImpl(Inline)]
        public static ProjectionKey<S,T> projection<S,T>(uint id, SourceKey<T> src, TargetKey<T> dst)
            => new ProjectionKey<S,T>(id,src,dst);

        [MethodImpl(Inline)]
        public static ProjectionKey untype<S,T>(ProjectionKey<S,T> p, Func<SourceKey<T>,uint> f, Func<TargetKey<T>,uint> g)
        {
            var src = untype(p.Source,f);
            var dst = untype(p.Target,g);
            return new ProjectionKey(p.Id,src,dst);
        }


        public sealed class Canonical : TypeSystem<Canonical, CanonicalKind>
        {
            public const string SystemName = "canonical";

            public Canonical()
                : base(SystemName)
            {

            }

            public override ReadOnlySpan<TypeKind<CanonicalKind>> Kinds => throw new NotImplementedException();
        }
    }
}