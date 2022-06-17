//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface ICmdReactor
    {
        void Init(IWfRuntime wf);

        CmdId CmdId {get;}

        CmdResult Invoke(ICmd cmd);
    }

    [Free]
    public interface ICmdReactor<C> : ICmdReactor
        where C : struct, ICmd
    {
        CmdId ICmdReactor.CmdId
            => default(C).CmdId;

        CmdResult<C> Invoke(C src);
    }

    [Free]
    public interface ICmdReactor<C,T> : ICmdReactor
        where C : struct, ICmd
    {
        CmdId ICmdReactor.CmdId
            => default(C).CmdId;

        CmdResult<C,T> Invoke(C Cmd);
    }
}