//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdActions
    {
        IEnumerable<string> Specs {get;}

        bool Find(string spec, out ICmdActionInvoker runner);

        ref readonly ReadOnlySeq<ShellCmdDef> Defs {get;}

        ICollection<ICmdActionInvoker> Invokers {get;}
    }
}