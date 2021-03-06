//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChecker
    {
        void Run();

        void Run(bool pll);

        ref readonly Index<string> Specs {get;}

        string Name
            => Checkers.name(GetType());
    }
}