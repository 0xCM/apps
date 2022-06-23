//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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
            => CmdId.identify<T>();

        string ITextual.Format()
            => CmdRender.format(this);
    }
}