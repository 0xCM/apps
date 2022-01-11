//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileFlow<F,A,K,S,T> : DataFlow<F,A,S,T>
        where A : IActor
        where S : IFileType<K>
        where T : IFileType<K>
        where K : unmanaged
        where F : FileFlow<F,A,K,S,T>, new()
    {
        protected FileFlow(A actor, S src, T dst)
            : base(actor,src,dst)
        {

        }

    }
}