//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("gen/asm/code")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.Emit();
            return true;
        }

        [CmdOp("asm/gen/regnames")]
        Outcome EmitRegNames(CmdArgs args)
        {
            var dst = text.emitter();
            var input = AsmRegData.gp();
            var count = input.Length;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                if(i != 0 && i%4 == 0)
                    buffer.AppendLine();
                buffer.AppendFormat("{0,-6}", skip(input,i));
            }

            //var data = recover<RegOp,byte>(regs).ToArray();
            var data = recover<byte>(span(buffer.Emit()));
            var spec = SpanRes.specify("GpRegNames", data.ToArray());
            var format = SpanResFormatter.format(spec);
            AppSvc.FileEmit(format, count, AppDb.CgStage().Path("regnames", FileKind.Cs));

            return true;
        }
    }
}