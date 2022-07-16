//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWsProject : IRootedArchive, IProjectWs
    {
        ProjectId Id
            => Project;
    }
}