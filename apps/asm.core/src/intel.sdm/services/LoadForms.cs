//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public AsmForms LoadForms()
            => Data(nameof(LoadForms), () => SdmOps.forms(LoadImportedOpcodes()));
    }
}