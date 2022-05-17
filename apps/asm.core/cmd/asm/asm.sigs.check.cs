//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/sigs/check")]
        Outcome CheckSigs(CmdArgs args)
        {
            using var dispenser = Alloc.allocate();
            var specs = new NativeOperandSpec[3];
            seek(specs,0) = NativeSigs.ptr("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.@const("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.@out("op2", NativeTypes.u32());
            var sig = dispenser.Sig("funcs","f2", NativeTypes.i32(), specs);
            Write(sig.Format(SigFormatStyle.C));
            sig = dispenser.Sig("funcs","f1", NativeTypes.i32(), specs);

            ref readonly var ret = ref sig.Return;
            ref readonly var op0 = ref sig[0];
            ref readonly var op1 = ref sig[1];
            ref readonly var op2 = ref sig[2];
            ref readonly var name = ref sig.Name;
            ref readonly var scope = ref sig.Scope;

            var x0 = string.Format("{0}:{1}", op0.Name, op0.Type);
            var x1 = string.Format("{0}:{1}", op1.Name, op1.Type);
            var x2 = string.Format("{0}:{1}", op2.Name, op2.Type);
            Write(sig.Format(SigFormatStyle.C));

            var intrinsics = new IntrinsicSigs();
            var f0 = intrinsics._mm_add_epi8();
            Write(f0.Format(SigFormatStyle.C));

            var f0x = dispenser.Sig(f0);
            Write(f0x.Format(SigFormatStyle.C));

            var f1 = intrinsics._mm_add_epi16();
            Write(f1.Format(SigFormatStyle.C));

            var f1x = dispenser.Sig(f1);
            Write(f1x.Format(SigFormatStyle.C));

            var f2 = intrinsics._mm_add_epi32();
            Write(f2.Format(SigFormatStyle.C));

            var f2x = dispenser.Sig(f2);
            Write(f2x.Format(SigFormatStyle.C));

            var f3 = intrinsics._mm_add_epi64();
            Write(f3.Format(SigFormatStyle.C));

            var f3x = dispenser.Sig(f3);
            Write(f3x.Format(SigFormatStyle.C));

            seek(specs,0) = NativeSigs.op("op0", NativeTypes.u8());
            seek(specs,1) = NativeSigs.op("op1", NativeTypes.i16());
            seek(specs,2) = NativeSigs.op("op2", NativeTypes.u32());

            return true;
        }
    }
}