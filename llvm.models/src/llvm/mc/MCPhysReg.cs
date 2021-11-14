//-----------------------------------------------------------------------------
// Copyright   :  (c) LLVM Project
// License     :  Apache-2.0 WITH LLVM-exceptions
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Replica of typedef defined in https://github.com/llvm/llvm-project/blob/b0ab79ee2dfab993d95f01aaa2d51bbe6af9ecbe/llvm/include/llvm/MC/MCRegister.h
    /// </summary>
    public struct MCPhysReg
    {
        public Hex16 Data;

        [MethodImpl(Inline)]
        public MCPhysReg(ushort src)
        {
            Data = src;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator MCPhysReg(ushort src)
            => new MCPhysReg(src);
    }
}