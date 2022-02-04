//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/regs/query")]
        Outcome RegQuery(CmdArgs args)
        {
            var selected = list<RegNameSet>();
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                for(var i=0; i<args.Count; i++)
                {
                    var pred = arg(args,i).Value;
                    result = DataParser.eparse(pred, out RegClassCode @class);
                    if(result.Fail)
                        return result;

                    var names = RegSets.RegNames(@class);
                    if(names.IsNonEmpty)
                        selected.Add(names);
                }
            }
            else
            {
                selected.Add(RegSets.Gp8RegNames());
                selected.Add(RegSets.Gp16RegNames());
                selected.Add(RegSets.Gp32RegNames());
                selected.Add(RegSets.Gp64RegNames());
                var classes = AsmRegCodes.Classes().View.Where(k => k != RegClassCode.GP && k != RegClassCode.GP8HI);
                var count = classes.Length;
                for(var i=0u; i<count; i++)
                {
                    var @class = skip(classes,i);
                    var names = RegSets.RegNames(@class);

                    if(names.IsNonEmpty)
                        selected.Add(names);
                }
            }

            // switch(pred)
            // {
            //     case "gp8":
            //         selected = RegSets.GpRegs(NativeSizeCode.W8);
            //         break;
            //     case "gp16":
            //         selected = RegSets.GpRegs(NativeSizeCode.W16);
            //     break;
            //     case "gp32":
            //         selected = RegSets.GpRegs(NativeSizeCode.W32);
            //     break;
            //     case "gp64":
            //         selected = RegSets.GpRegs(NativeSizeCode.W64);
            //     break;
            //     case "xmm":
            //         selected = RegSets.XmmRegs();
            //     break;
            //     case "ymm":
            //         selected = RegSets.YmmRegs();
            //     break;
            //     case "zmm":
            //         selected = RegSets.ZmmRegs();
            //     break;
            //     case "k":
            //     case "mask":
            //         selected = RegSets.MaskRegs();
            //     break;
            // }

            var buffer = text.buffer();
            iter(selected, reg => buffer.AppendLine(reg.Format()));
            Write(buffer.Emit());

            return result;
        }
    }
}