//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;
    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct AsmSyntaxModel
    {
        [MethodImpl(Inline), Op]
        public static RegOperand register(RegIdentifier reg)
            => new RegOperand(reg);

        [MethodImpl(Inline), Op]
        public static ImmOperand imm(ImmOp src)
            => new ImmOperand(src);

        [MethodImpl(Inline), Op]
        public static MemoryOperand memory(NativeSize mode, NativeSize size)
        {
            var dst = MemoryOperand.Empty;
            dst.Mode = mode;
            dst.Size = size;
            return dst;
        }

        [MethodImpl(Inline), Op]
        public static ref MemoryOperand @base(RegIdentifier src, ref MemoryOperand dst)
        {
            dst.Base = src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref MemoryOperand index(RegIdentifier src, ref MemoryOperand dst)
        {
            dst.Index= src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref MemoryOperand scale(MemoryScale src, ref MemoryOperand dst)
        {
            dst.Scale= src;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static ref MemoryOperand disp(Disp src, ref MemoryOperand dst)
        {
            dst.Displacement = src;
            return ref dst;
        }

        public struct AsmSyntaxTree
        {
            public FS.FileUri Source;

            public Index<AsmSyntaxStatement> Statements;
        }
    }
}