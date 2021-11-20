//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-class.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [SymSource(xed)]
        public enum RegClass : byte
        {
            None,

            BNDCFG,

            BNDSTAT,

            BOUND,

            CR,

            DR,

            FLAGS,

            GPR,

            GPR16,

            GPR32,

            GPR64,

            GPR8,

            IP,

            MASK,

            MMX,

            MSR,

            MXCSR,

            PSEUDO,

            PSEUDOX87,

            SR,

            TMP,

            TREG,

            UIF,

            X87,

            XCR,

            XMM,

            YMM,

            ZMM,
        }
    }
}