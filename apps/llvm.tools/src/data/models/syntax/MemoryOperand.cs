//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System.Runtime.InteropServices;

    using Asm;

    partial struct AsmSyntaxModel
    {
        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct MemoryOperand : IOperand<AsmOpClass,MemoryOperand>
        {
            public NativeSize Mode;

            public NativeSize Size;

            public RegIdentifier Base;

            public RegIdentifier Index;

            public MemoryScale Scale;

            public Disp Displacement;

            public AsmOpClass Kind => AsmOpClass.M;

            public MemoryOperand Value
                => this;

            public static MemoryOperand Empty => default;
        }
    }
}