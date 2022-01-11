//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FileFlowType<F,A,K,S,T> : DataFlow<F,A,S,T>, IFlowType
        where A : IActor
        where S : IFileType<K>
        where T : IFileType<K>
        where K : unmanaged
        where F : FileFlowType<F,A,K,S,T>, new()
    {
        protected FileFlowType(A actor, S src, T dst)
            : base(actor,src,dst)
        {

        }

        IActor IFlowType.Actor
            => Actor;

    }
}