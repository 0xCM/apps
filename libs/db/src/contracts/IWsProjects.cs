//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWsProjects : IRootedArchive
    {
        IWsProjects Projects(string scope)
            => new WsProjects(Root, scope);
    }
}