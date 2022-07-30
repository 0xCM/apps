//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IRunnable
    {
        void Run();

        Task Start()
            => Task.Run(Run);
    }

    [Free]
    public interface IRunnable<S> : IRunnable
        where S : new()
    {
        S Settings {get;}
    }
}