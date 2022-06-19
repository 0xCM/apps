//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IExecutable
    {
        void Execute(params string[] args);

    }

    public interface IExecutable<A> : IExecutable
    {
        void Execute(params A[] args);
    }

    public interface IExecutable<M,A> : IExecutable<A>
        where M : IExecutable<M,A>, new()
    {

    }
}