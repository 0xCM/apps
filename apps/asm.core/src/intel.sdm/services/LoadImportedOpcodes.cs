//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<SdmOpCodeDetail> LoadImportedOpcodes()
        {
            return Data(nameof(LoadImportedOpcodes), Load);

            Index<SdmOpCodeDetail> Load()
            {
                var dst = sys.empty<SdmOpCodeDetail>();
                var src = SdmPaths.ImportTable<SdmOpCodeDetail>();
                var lines = SdmPaths.ImportTable<SdmOpCodeDetail>().ReadNumberedLines();
                var count = lines.Count -1;
                dst = alloc<SdmOpCodeDetail>(count);
                SdmOps.rows(slice(lines.View,1), dst);
                return dst;
            }
        }
    }
}