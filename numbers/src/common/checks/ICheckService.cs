//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckRunner
    {
        void Run();

        void Run(bool pll);
    }

    public interface ICheckService : ICheckRunner
    {
        Identifier Name => GetType().Name;

        ReadOnlySpan<Name> Checks {get;}
    }
}