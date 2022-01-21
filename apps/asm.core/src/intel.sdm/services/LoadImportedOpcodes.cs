//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public Index<SdmSigOpCode> LoadImportedOpCodes()
        {
            return Data(nameof(LoadImportedOpCodes), () => LoadImportedOpcodeDetails().Map(x => SdmOps.sigoc(x)));
        }
    }
}