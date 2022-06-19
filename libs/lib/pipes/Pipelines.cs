//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;


    [ApiHost]
    public readonly partial struct Pipelines
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline)]
        public static BlockPipeline128<S,T> compose<S,T>(IPipeline pipeline, IBlockSource128<S> src, IBlockProjector128<S,T> map, IBlockSink128<T> dst)
            where S : unmanaged
            where T : unmanaged
                => new BlockPipeline128<S,T>(pipeline, src, map, dst);

        [MethodImpl(Inline)]
        public static BlockPipeline256<S,T> compose<S,T>(IPipeline pipeline, IBlockSource256<S> src, IBlockProjector256<S,T> map, IBlockSink256<T> dst)
            where S : unmanaged
            where T : unmanaged
                => new BlockPipeline256<S,T>(pipeline, src, map, dst);

        [MethodImpl(Inline)]
        public static BlockPipeline128<A,S,P,B,T> compose<A,S,P,B,T>(W128 w, IPipeline pipeline, A src, P map, B dst)
            where S : unmanaged
            where A : IBlockSource128<S>
            where P : IBlockProjector128<S,T>
            where T : unmanaged
            where B : IBlockSink128<T>
                => new BlockPipeline128<A,S,P,B,T>(pipeline, src,map,dst);

        [MethodImpl(Inline)]
        public static BlockPipeline256<A,S,P,B,T> compose<A,S,P,B,T>(W256 w, IPipeline pipeline, A src, P map, B dst)
            where S : unmanaged
            where A : IBlockSource256<S>
            where P : IBlockProjector256<S,T>
            where T : unmanaged
            where B : IBlockSink256<T>
                => new BlockPipeline256<A,S,P,B,T>(pipeline, src,map,dst);

        [MethodImpl(Inline)]
        public static SBlockPipeline128<B,M,R,S,T> create<B,M,R,S,T>(W128 w, B blocks, M mapper, R sink, S s = default, T t = default)
            where R : IBlockSink128<R,T>
            where B : IBlockSource128<S>
            where M : IVMap128<M,S,T>
            where S : unmanaged
            where T : unmanaged
                => new SBlockPipeline128<B,M,R,S,T>(blocks,mapper,sink);

        [MethodImpl(Inline)]
        public static SBlockPipeline256<B,M,R,S,T> create<B,M,R,S,T>(W256 w, B blocks, M mapper, R sink, S s = default, T t = default)
            where R : IBlockSink256<R,T>
            where B : IBlockSource256<S>
            where M : IVMap256<M,S,T>
            where S : unmanaged
            where T : unmanaged
                => new SBlockPipeline256<B,M,R,S,T>(blocks,mapper,sink);

        [MethodImpl(Inline)]
        public static BlockRelay128<S,T> relay<S,T>(IPipeline pipes, IBlockSource128<S> src, IBlockSink128<T> dst)
            where S : unmanaged
            where T : unmanaged
                => new BlockRelay128<S,T>(pipes, src,dst);

        [MethodImpl(Inline)]
        public static BlockRelay128<A,S,B,T> relay<A,S,B,T>(W128 w, IPipeline pipes,  A src, B dst)
            where S : unmanaged
            where A : IBlockSource128<S>
            where T : unmanaged
            where B : IBlockSink128<T>
                => new BlockRelay128<A,S,B,T>(pipes, src,dst);

        [MethodImpl(Inline)]
        public static BlockRelay256<S,T> relay<S,T>(IPipeline pipes, IBlockSource256<S> src, IBlockSink256<T> dst)
            where S : unmanaged
            where T : unmanaged
                => new BlockRelay256<S,T>(pipes, src,dst);

        [MethodImpl(Inline)]
        public static BlockRelay256<A,S,B,T> relay<A,S,B,T>(W256 w, IPipeline pipes, A src, B dst)
            where S : unmanaged
            where A : IBlockSource256<S>
            where T : unmanaged
            where B : IBlockSink256<T>
                => new BlockRelay256<A,S,B,T>(pipes, src,dst);

        [MethodImpl(Inline)]
        public static void project<P,S,T>(BlockRelay128<S,T> relay, P projector)
            where S : unmanaged
            where T : unmanaged
            where P : IBlockProjector128<P,S,T>
        {
            var w = w128;
            var count = relay.BlockCount;
            var buffer = SpanBlocks.single<T>(w);
            for(var i=0u; i<count; i++)
            {
                buffer.BlockLead(0) = default;
                var emission = relay.Emit(i);
                projector.Project(emission, buffer);
                relay.Deposit(buffer);
            }
        }

        [MethodImpl(Inline)]
        public static void project<P,A,S,B,T>(BlockRelay128<A,S,B,T> relay, P projector)
            where S : unmanaged
            where A : IBlockSource128<S>
            where T : unmanaged
            where B : IBlockSink128<T>
            where P : IBlockProjector128<P,S,T>
        {
            var w = w128;
            var count = relay.BlockCount;
            var buffer = SpanBlocks.single<T>(w);
            for(var i=0u; i<count; i++)
            {
                buffer.BlockLead(0) = default;
                var emission = relay.Emit(i);
                projector.Project(emission, buffer);
                relay.Deposit(buffer);
            }
        }
    }
}
