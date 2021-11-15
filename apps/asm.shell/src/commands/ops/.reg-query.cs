//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class AsmCmdService
    {
        [CmdOp(".reg-query")]
        Outcome RegQuery(CmdArgs args)
        {
            var result = Outcome.Success;
            var pred = arg(args,0).Value;
            var selected = RegSet.Empty;
            switch(pred)
            {
                case "gp8":
                    selected = RegSets.GpRegs(NativeSizeCode.W8);
                    break;
                case "gp16":
                    selected = RegSets.GpRegs(NativeSizeCode.W16);
                break;
                case "gp32":
                    selected = RegSets.GpRegs(NativeSizeCode.W32);
                break;
                case "gp64":
                    selected = RegSets.GpRegs(NativeSizeCode.W64);
                break;
                case "xmm":
                    selected = RegSets.XmmRegs();
                break;
                case "ymm":
                    selected = RegSets.YmmRegs();
                break;
                case "zmm":
                    selected = RegSets.ZmmRegs();
                break;
                case "k":
                case "mask":
                    selected = RegSets.MaskRegs();
                break;
            }

            var buffer = text.buffer();
            iter(selected.View, reg => buffer.AppendFormat("{0} ", reg));
            Write(buffer.Emit());

            return result;
        }
    }
}