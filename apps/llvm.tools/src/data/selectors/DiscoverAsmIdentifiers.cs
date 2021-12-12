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
        public AsmIdentifiers DiscoverAsmIdentifiers()
        {
            const string BeginAsmIdMarker = "PHI	= 0,";
            var src = LlvmPaths.TableGenHeaders().Where(x => x.FileName.WithoutExtension.Format() == TableGenHeaders.X86Info);
            if(src.Count != 1)
            {
                Wf.Error("Path not found");
                return llvm.AsmIdentifiers.Empty;
            }
            return IdentifierDiscovery.discover<ushort>(src[0],BeginAsmIdMarker).Map(x => new AsmIdentifier(x.Key, x.Value));
        }
    }
}