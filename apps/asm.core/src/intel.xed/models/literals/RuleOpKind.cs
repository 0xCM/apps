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

            Reg,

            Mem,

            Imm,

            Ptr,

            Base,

            Seg,

            Index,

            Scale,

            Disp,

            RelBr,

            Agen
        }
    }
}