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

        bool Find(string spec, out IActionRunner runner);

        ref readonly ReadOnlySeq<AppCmdDef> Defs {get;}

        ICollection<IActionRunner> Invokers {get;}
    }
}