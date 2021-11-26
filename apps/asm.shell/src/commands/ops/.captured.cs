//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".captured")]
        Outcome ShowCaptured(CmdArgs args)
        {
            var packs = ApiPacks.List();
            iter(packs, a => Wf.Row(a.Root));
            var current = packs.Last;
            var archive = ApiPacks.Archive(current.Root);
            var entries = ApiCatalogs.LoadApiCatalog(archive.ContextRoot());
            var formatter = Z0.Tables.formatter<ApiCatalogEntry>();
            iter(entries, entry => Wf.Row(formatter.Format(entry)));
            return true;
        }
    }
}