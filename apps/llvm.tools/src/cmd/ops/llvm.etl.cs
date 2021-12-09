//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    using static Root;

    partial class LlvmCmd
    {
        [CmdOp("llvm/etl")]
        Outcome RunRecordsEtl(CmdArgs args)
        {
            LlvmEtl.Run();
            return true;
        }

        [CmdOp(".asm-strings")]
        Outcome ListAsmStrings(CmdArgs args)
        {
            var instructions = DataProvider.SelectEntities(e => e.IsInstruction()).Select(x => x.ToInstruction());
            var asmids = DataProvider.SelectAsmIdDefs();
            var count = instructions.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var inst = ref instructions[i];
                var name = inst.InstName;
                if(asmids.Find(name, out var iddef))
                {
                    var id = iddef.Id;
                    var _result = AsmStrings.extract(inst);
                    Write(_result.Format());
                }
                else
                {
                    return (false, string.Format("{0} id not found", inst.InstName));
                }
            }

            return true;
        }
    }
}