//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    using static Asm.AsmRegTokens;
    partial class CheckCmdProvider
    {

        Outcome CheckSigs(CmdArgs args)
        {
            using var dispenser = Alloc.allocate();
            var specs = new NativeOperandSpec[3];
            seek(specs,0) = ("op0", NativeTypes.u8());
            seek(specs,0) = ("op1", NativeTypes.i16());
            seek(specs,0) = ("op2", NativeTypes.u32());
            dispenser.NativeSig("f1", NativeTypes.i32());




            return true;
        }

        [CmdOp("check/ccv")]
        Outcome CheckCcv(CmdArgs args)
        {

            var r0 = Win64Ccv.reg(w64,0);
            Require.invariant(r0 == Gp64Reg.rcx);
            var r1 = Win64Ccv.reg(w64,1);
            Require.invariant(r1 == Gp64Reg.rdx);
            var r2 = Win64Ccv.reg(w64,2);
            Require.invariant(r2 == Gp64Reg.r8);
            var r3 = Win64Ccv.reg(w64,3);
            Require.invariant(r3 == Gp64Reg.r9);

            Write(string.Format("{0} | {1} | {2} | {3}", r0, r1, r2, r3));
            return true;
        }
    }
}