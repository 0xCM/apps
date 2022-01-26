//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        public Index<AsmFormExpr> LoadImportedForms()
            => LoadImportedOpcodes().Select(x => SdmOps.form(x));
    }
}