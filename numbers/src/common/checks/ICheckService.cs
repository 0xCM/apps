//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICheckService
    {
        Identifier Name => GetType().Name;

        ReadOnlySpan<Name> Checks {get;}

        void Run();
    }
}