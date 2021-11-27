//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IWfDb : IEnvPaths
    {
        FS.FolderPath Root {get;}

        IWfDb Relocate(FS.FolderPath root);
    }
}