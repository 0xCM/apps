//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigModels;

    using M = AsmSigModels;

    partial class AsmSigs
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmSigOp<K> sigop<K>(AsmSigOpKind kind, K value)
            where K : unmanaged
                => new AsmSigOp<K>(kind,value);

        [MethodImpl(Inline), Op]
        public static M.FarPtr sigop(FarPtrToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static FpuMem sigop(FpuMemToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static FpuReg sigop(FpuRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static GpReg sigop(GpRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static GpRm sigop(GpRmToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static MemPair sigop(MemPairToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static MmxReg sigop(MmxRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Moffs sigop(MoffsToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Rel sigop(RelToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static SrcOp sigop(SrcOpToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static VecRm sigop(VecRmToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static BCast sigop(BroadcastToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static SysReg sigop(SysRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static OpMask sigop(Reg r, OpMaskToken src)
            => new OpMask(r, src);

        [MethodImpl(Inline), Op]
        public static Imm sigop(ImmToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Mem sigop(MemToken src)
            => src;
    }
}