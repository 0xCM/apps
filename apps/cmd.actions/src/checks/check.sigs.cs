//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    partial class CheckCmdProvider
    {
        [CmdOp("check/sigs")]
        Outcome CheckSigs(CmdArgs args)
        {
            using var dispenser = Alloc.allocate();
            var specs = new NativeOperandSpec[3];
            seek(specs,0) = NativeSigs.ptr("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.@const("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.@out("op2", NativeTypes.u32());
            var sig = dispenser.NativeSig("funcs","f2", NativeTypes.i32(), specs);
            Write(sig.Format(SigFormatStyle.C));
            return true;
        }


        void CheckSig1()
        {
            using var dispenser = Alloc.allocate();
            var specs = new NativeOperandSpec[3];
            seek(specs,0) = NativeSigs.op("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.op("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.op("op2", NativeTypes.u32());
            var sig = dispenser.NativeSig("funcs","f1", NativeTypes.i32(), specs);

            ref readonly var ret = ref sig.Return;
            ref readonly var op0 = ref sig[0];
            ref readonly var op1 = ref sig[1];
            ref readonly var op2 = ref sig[2];
            ref readonly var name = ref sig.Name;
            ref readonly var scope = ref sig.Scope;

            var x0 = string.Format("{0}:{1}", op0.Name, op0.Type);
            var x1 = string.Format("{0}:{1}", op1.Name, op1.Type);
            var x2 = string.Format("{0}:{1}", op2.Name, op2.Type);
            var result = ret.Type.Format();
            var sigfmt = string.Format("{0}::{1}:{2} -> {3} -> {4} -> {5}", scope, name, x0, x1,x2, result);
            Write(sigfmt);
        }
    }
}