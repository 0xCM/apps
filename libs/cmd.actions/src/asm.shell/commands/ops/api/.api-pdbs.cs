//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
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