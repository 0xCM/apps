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

                    var names = Regs.RegNames(@class);
                    if(names.IsNonEmpty)
                        selected.Add(names);
                }
            }
            else
            {
                selected.Add(Regs.Gp8RegNames());
                selected.Add(Regs.Gp16RegNames());
                selected.Add(Regs.Gp32RegNames());
                selected.Add(Regs.Gp64RegNames());
                var classes = AsmRegCodes.Classes().View.Where(k => k != RegClassCode.GP && k != RegClassCode.GP8HI);
                var count = classes.Length;
                for(var i=0u; i<count; i++)
                {
                    var @class = skip(classes,i);
                    var names = Regs.RegNames(@class);

                    if(names.IsNonEmpty)
                        selected.Add(names);
                }
            }

            var buffer = text.buffer();
            iter(selected, reg => buffer.AppendLine(reg.Format()));
            Write(buffer.Emit());

            return result;
        }
    }
}