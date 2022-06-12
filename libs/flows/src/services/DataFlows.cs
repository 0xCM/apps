//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static FS;

    [ApiHost]
    public class DataFlows
    {
        [MethodImpl(Inline)]
        public static DataFlow<Actor,S,T> flow<S,T>(Identifier actor, S src, T dst)
            => new DataFlow<Actor,S,T>(actor,src,dst);

        [MethodImpl(Inline)]
        public static FlowId identify<A,S,T>(in DataFlow<A,S,T> src)
            where A : IActor
            where S : ITextual
            where T : ITextual
        {
            var a = alg.hash.marvin(src.Actor.Name.Format());
            var s = alg.hash.marvin(src.Source.Format());
            var t = alg.hash.marvin(src.Target.Format());
            return new FlowId(a,s,t);
        }

        [MethodImpl(Inline)]
        public static FlowId identify<S,T>(Identifier actor, S src, T dst)
            where S : ITextual
            where T : ITextual
                => identify(flow(actor, src, dst));


        /// <summary>
        /// Defines an edge from a specified source to specified target
        /// </summary>
        /// <param name="source">The source value</param>
        /// <param name="target">The target value</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static Arrow<S,T> flow<S,T>(S src, T dst)
            => new Arrow<S,T>(src, dst);

        [MethodImpl(Inline)]
        public static Arrow<S,T,K> flow<S,T,K>(S src, T dst, K kind)
            where K : unmanaged
                => new Arrow<S,T,K>(src, dst, kind);

        [MethodImpl(Inline), Op]
        public static Arrow<FileUri> flow(FilePath src, FilePath dst)
            => (src,dst);

        [MethodImpl(Inline), Op]
        public static Arrow<FolderPath> flow(FolderPath src, FolderPath dst)
            => (src,dst);

        [MethodImpl(Inline), Op]
        public static Arrow<FilePath,FolderPath> flow(FilePath src, FolderPath dst)
            => (src,dst);

        [MethodImpl(Inline), Op]
        public static Arrow<FolderPath,FilePath> flow(FolderPath src, FilePath dst)
            => (src,dst);
    }
}