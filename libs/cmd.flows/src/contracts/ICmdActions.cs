//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdActions
    {
        IEnumerable<string> Specs {get;}

        bool Find(string spec, out CmdActionInvoker runner);
    }
}