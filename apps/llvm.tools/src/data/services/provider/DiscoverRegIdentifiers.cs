//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static LlvmNames;

    partial class LlvmDataProvider
    {
        public RegIdentifiers DiscoverRegIdentifiers()
        {
            const string BeginRegsMarker = "NoRegister,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Registers);
            if(src.Count != 1)
            {
                Error("Path not found");
                return llvm.RegIdentifiers.Empty;
            }
            return IdentifierDiscovery.discover<ushort>(src[0],BeginRegsMarker).Map(x => new RegIdentifier(x.Key, x.Value));
        }
    }
}