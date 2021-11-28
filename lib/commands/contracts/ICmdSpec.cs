//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ICmd : ITextual
    {
        CmdId CmdId {get;}
    }

    [Free]
    public interface ICmd<T> : ICmd
        where T : struct, ICmd<T>
    {
        CmdId ICmd.CmdId
            => CmdId.from<T>();

        string ITextual.Format()
            => Cmd.format(this);
    }
}