//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;

    public interface IToolWs : IWorkspaceObselete
    {
        FS.FolderPath Home {get;}

        FS.FolderPath Inputs() => Home + FS.folder(src);

        IToolWs Configure(ToolConfig[] src);

        FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);
    }
}