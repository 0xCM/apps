//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IFileFlowCmd : ICmd
    {
        IActor Actor {get;}

        FS.FilePath Source {get;}

        FS.FilePath Target {get;}
    }

    public interface IFileFlowCmd<C> : IFileFlowCmd, ICmd<C>
        where C : struct, IFileFlowCmd<C>
    {
        IActor IFileFlowCmd.Actor
            => new Tool(typeof(C).Tag<CmdAttribute>().MapValueOrDefault(x => x.Name, GetType().Name));
    }
}