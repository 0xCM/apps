//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        void ImportOpCodes()
        {
            var details = ImportOpCodeDetails();
            var forms = EmitForms(details);
            EmitSigOps(forms);
        }
   }
}