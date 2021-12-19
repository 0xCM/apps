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
        where S : IType
        where T : IType
    {

    }

    [Free]
    public interface IDataFlow<A,S,T> : IDataFlow<S,T>
        where S : IType
        where T : IType
        where A : IActor
    {
        new A Actor {get;}

        IActor IDataFlow.Actor
            => Actor;
    }
}