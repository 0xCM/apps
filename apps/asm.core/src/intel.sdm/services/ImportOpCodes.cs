//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        void ImportOpCodes()
        {
            var details = ImportOpCodeDetails();
            var forms = EmitFormRecords(details);
            EmitSigOps(forms);
        }
   }
}