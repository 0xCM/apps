//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct Spaces
    {
        /// <summary>
        /// Characterizes a projector
        /// </summary>
        /// <typeparam name="S">The source element type</typeparam>
        /// <typeparam name="T">The target element type</typeparam>
        public interface IProjector<S,T>
        {
            /// <summary>
            /// Projects elements from a specified source into a specified target
            /// </summary>
            /// <param name="src">The data source</param>
            /// <param name="dst">The data target</param>
            /// <returns>The count of projected elements, if successful; otherwise an error specification</returns>
            Outcome<uint> Project(ReadOnlySpan<S> src, Span<T> dst);
        }

        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static Outcome<uint> apply<S,T>(Projector<S,T> p, ReadOnlySpan<S> src, Span<T> dst)
        {
            var count = (uint)min(src.Length,dst.Length);
            for(var i=0; i<count; i++)
                seek(dst,i) = p.F(skip(src,i));
            return count;
        }

        [MethodImpl(Inline), Op]
        public static DomainKey domain(uint kind, uint id)
            => new DomainKey(kind,id);

        [MethodImpl(Inline), Op]
        public static SourceKey source(DomainKey domain, uint id)
            => new SourceKey(domain,id);

        [MethodImpl(Inline), Op]
        public static TargetKey target(DomainKey domain, uint id)
            => new TargetKey(domain,id);

        [MethodImpl(Inline), Op]
        public static ProjectionKey projection(uint id, SourceKey src, TargetKey dst)
            => new ProjectionKey(id, src, dst);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DomainKey<D> domain<D>(D descriptor)
            where D : unmanaged
                => new DomainKey<D>(descriptor);

        [MethodImpl(Inline)]
        public static Projector<S,T> projector<S,T>(Func<S,T> f)
            => new Projector<S,T>(f);

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

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static DomainKey untyped<D>(DomainKey<D> d)
            where D : unmanaged
        {
            var k = 0u;
            var i = 0u;
            var data = @readonly(bytes(d.Descriptor));
            if(size<D>() == 1)
            {
                ref readonly var b = ref skip(data,0);
                k = (uint)b & 0xF;
                i = (uint)b >> 4;
            }
            else if(size<D>() == 2)
            {
                k = skip(data,0);
                i = skip(data,1);
            }
            else if(size<D>() == 4)
            {
                k = skip16(data,0);
                i = skip16(data,2);
            }
            else if(size<D>() == 8)
            {
                k = skip32(data,0);
                i = skip32(data,4);
            }
            return new DomainKey(k,i);
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct DomainKey
        {
            public uint Kind {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public DomainKey(uint kind, uint id)
            {
                Id = id;
                Kind = kind;
            }
        }

        /// <summary>
        /// Describes a domain, in 64 bits or less
        /// </summary>
        public readonly struct DomainKey<D>
            where D : unmanaged
        {
            public D Descriptor {get;}

            [MethodImpl(Inline)]
            public DomainKey(D d)
            {
                Descriptor = d;
            }

            [MethodImpl(Inline)]
            public static implicit operator DomainKey(DomainKey<D> src)
                => untyped(src);
        }

        /// <summary>
        /// Identifies a domain-relative source
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SourceKey
        {
            public DomainKey Domain {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public SourceKey(DomainKey d, uint id)
            {
                Domain = d;
                Id = id;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct SourceKey<S>
        {
            public DomainKey Domain {get;}

            public S Rep {get;}

            [MethodImpl(Inline)]
            public SourceKey(DomainKey d, S rep)
            {
                Domain = d;
                Rep = rep;
            }
        }

        /// <summary>
        /// Identifies a domain-relative target
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TargetKey
        {
            public DomainKey Domain {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public TargetKey(DomainKey d, uint id)
            {
                Domain = d;
                Id = id;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public readonly struct TargetKey<T>
        {
            public DomainKey Domain {get;}

            public T Rep {get;}

            [MethodImpl(Inline)]
            public TargetKey(DomainKey d, T rep)
            {
                Domain = d;
                Rep = rep;
            }
        }

        /// <summary>
        /// Identifies a projection
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProjectionKey
        {
            public SourceKey Source {get;}

            public TargetKey Target {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public ProjectionKey(uint id, SourceKey src, TargetKey dst)
            {
                Id = id;
                Source = src;
                Target = dst;
            }
        }

        /// <summary>
        /// Identifies a projection
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public readonly struct ProjectionKey<S,T>
        {
            public SourceKey<T> Source {get;}

            public TargetKey<T> Target {get;}

            public uint Id {get;}

            [MethodImpl(Inline)]
            public ProjectionKey(uint id, SourceKey<T> src, TargetKey<T> dst)
            {
                Id = id;
                Source = src;
                Target = dst;
            }
        }

        /// <summary>
        /// A default projection effector
        /// </summary>
        public readonly struct Projector<S,T> : IProjector<S,T>
        {
            internal readonly Func<S,T> F;

            [MethodImpl(Inline)]
            internal Projector(Func<S,T> f)
                => F = f;

            public Outcome<uint> Project(ReadOnlySpan<S> src, Span<T> dst)
                => apply(this,src,dst);
        }
    }
}