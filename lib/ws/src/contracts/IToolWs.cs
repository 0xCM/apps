//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static WsAtoms;

    public interface IToolWs : IWorkspace
    {
        IToolWs Configure(ToolConfig[] src);

        ReadOnlySpan<ToolConfig> Configured {get;}

        FS.FolderPath Toolbase {get;}

        FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);
    }
}