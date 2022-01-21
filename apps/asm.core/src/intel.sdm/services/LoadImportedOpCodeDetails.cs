//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Index<SdmSigOpCode> LoadImportedSigOpCodes()
            => LoadImportedOpcodeDetails().Select(x => sigoc(x));

        public Index<SdmOpCodeDetail> LoadImportedOpcodeDetails()
        {
            return Data(nameof(LoadImportedOpcodeDetails), Load);

            Index<SdmOpCodeDetail> Load()
            {
                var dst = sys.empty<SdmOpCodeDetail>();
                var src = SdmPaths.ImportTable<SdmOpCodeDetail>();
                var lines = src.ReadNumberedLines();
                var count = lines.Count -1;
                dst = alloc<SdmOpCodeDetail>(count);
                ocdetails(slice(lines.View,1), dst);
                return dst;
            }
        }
    }
}