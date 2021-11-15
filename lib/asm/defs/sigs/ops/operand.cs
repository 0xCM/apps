//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        [MethodImpl(Inline), Op]
        public static ref readonly AsmSigOpExpr operand(in AsmSig src, byte i)
        {
            if(i==3)
                return ref src.Op3;
            if(i==2)
                return ref src.Op2;
            if(i==1)
                return ref src.Op1;
            return ref src.Op0;
        }

        [MethodImpl(Inline), Op]
        public static FarPtr operand(FarPtrToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static FpuMem operand(FpuMemToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static FpuReg operand(FpuRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static GpReg operand(GpRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static GpRm operand(GpRmToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static OpMask operand(OpMaskToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static MemPair operand(MemPairToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static MmxReg operand(MmxRegToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Moffs operand(MoffsToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Ptr operand(PtrToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Rel operand(RelToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static SrcOp src(SrcOpToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static VecRm src(VecRmToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static Broadcast src(BroadcastToken src)
            => src;

        [MethodImpl(Inline), Op]
        public static SysReg src(SysRegToken src)
            => src;
    }
}