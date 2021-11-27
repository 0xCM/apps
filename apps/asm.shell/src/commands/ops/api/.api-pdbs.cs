//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    partial class AsmCmdService
    {
        [CmdOp(".api-pdbs")]
        Outcome IndexApiPdbFiles(CmdArgs args)
        {
            var catalog = ApiRuntimeLoader.catalog();
            var components = catalog.Components;
            var builder = Wf.PdbIndexBuilder();
            builder.IndexComponents(components);
            return true;
        }

        [CmdOp(".symstores")]
        Outcome ReadSymbols(CmdArgs args)
        {
            var reader = SOS.SymbolReader.create();
            reader.ShowSymbolStore(data => Wf.Row(data));
            return true;
        }

        void GetMethodInfo()
        {
            var path = Parts.Lib.Assembly.Location;
            var catalog = Wf.ApiCatalog.PartCatalogs(PartId.Lib).Single();
            var methods = catalog.Methods;
            SOS.SymbolReader.InitializeSymbolReader("");
            foreach(var method in methods)
            {
                if(SOS.SymbolReader.GetInfoForMethod(path, method.MetadataToken, out var info))
                {
                    var size = info.size;
                    Wf.Row($"{method.Name} | {size}");
                }
            }
        }
    }
}