//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDataFlow : IArrow
    {
        IActor Actor {get;}
    }

    /// <summary>
    /// Characterizes a data flow
    /// </summary>
    /// <typeparam name="S">The source type</typeparam>
    /// <typeparam name="T">The target type</typeparam>
    [Free]
    public interface IDataFlow<S,T> : IDataFlow, IArrow<S,T>
    {
        string ITextual.Format()
            => string.Format("{0}:{1} -> {2}", Actor, Source, Target);
    }

    [Free]
    public interface IDataFlow<A,S,T> : IDataFlow<S,T>
        where A : IActor
    {
        new A Actor {get;}

        IActor IDataFlow.Actor
            => Actor;
    }
}