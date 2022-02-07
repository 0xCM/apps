//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        public enum RuleOpKind : byte
        {
            None,

            Agen,

            Base,

            Disp,

            Imm,

            Index,

            Mem,

            Ptr,

            Reg,

            RelBr,

            Scale,

            Seg,
        }
    }
}