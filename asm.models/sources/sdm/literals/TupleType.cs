//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial struct SdmModels
    {
        [SymSource]
        public enum TupleType : byte
        {
            None = 0,

            [Symbol("Full")]
            Full,

            [Symbol("Full Mem")]
            FullMem,
        }
    }
}