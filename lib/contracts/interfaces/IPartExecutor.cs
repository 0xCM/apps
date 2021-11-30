//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IPartExecutor
    {
        Type ExecutorType {get;}

        void Run();

        void Run(dynamic context);

        Type ContextType
            => typeof(void);
    }

    public interface IPartExecutor<P> : IPartExecutor
        where P : IPartExecutor<P>
    {
        Type IPartExecutor.ExecutorType
            => typeof(P);
    }

    public interface IPartExecutor<P,C> : IPartExecutor<P>
        where P : IPartExecutor<P>
    {
        void Run(C context);

        void IPartExecutor.Run(dynamic context)
            => Run((C)context);

        Type IPartExecutor.ContextType
            => typeof(C);
    }
}