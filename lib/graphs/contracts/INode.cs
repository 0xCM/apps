//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface INode
    {
        uint Index {get;}
    }

    /// <summary>
    /// Characterizes an atomic value
    /// </summary>
    /// <typeparam name="T">The value type</typeparam>
    public interface INode<T> : INode
    {
        T Payload {get;}
    }

    public interface INode<K,T> : INode<T>
        where K : unmanaged
    {
        new K Index {get;}

        uint INode.Index
            => core.bw32(Index);
    }
}