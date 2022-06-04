//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILlvmWorkspace : IWorkspace
    {
        FS.FolderPath BuildRoot {get;}
    }
}