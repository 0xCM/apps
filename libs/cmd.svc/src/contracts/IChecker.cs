//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IChecker : ICmdProvider
    {
        void Run(WfEventLogger log, bool pll);

        ref readonly Index<string> Specs {get;}
    }
}