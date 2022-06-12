//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;

    public interface IToolWs : IWorkspace
    {
        IToolWs Configure(ToolConfig[] src);

        ReadOnlySpan<ToolConfig> Configured {get;}

        DbSources Toolbase {get;}

        FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

        new DbSources ToolHome(ToolId id)
            => new DbSources(Toolbase, id.Format());
    }
}