//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdDef
    {

        CmdKind CmdKind {get;}
    }

    public interface ICmdDef<D> : ICmdDef
        where D : struct, ICmdDef<D>
    {


    }
    public interface IShellCmd<D> : ICmdDef<D>
        where D : struct, IShellCmd<D>
    {
        CmdKind ICmdDef.CmdKind => CmdKind.ShellCmd;
    }
}