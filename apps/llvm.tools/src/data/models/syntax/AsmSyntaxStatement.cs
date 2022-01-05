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
        public struct AsmSyntaxStatement
        {
            public uint Seq;

            public uint BlockSeq;

            public AsmBlockLabel BlockLabel;

            public AsmStatement Asm;

            public AsmIdentifier AsmId;

            public DelimitedIndex<Operand> Operands;

            public FS.FileUri Source;
        }
    }
}