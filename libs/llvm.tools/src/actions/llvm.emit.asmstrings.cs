//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/emit/asmstrings")]
        void EmitAsmStrings()
        {
            var entities = DataProvider.Entities();
            var count = entities.Length;
            var specs = list<AsmString>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(inst.isCodeGenOnly || inst.isPseudo)
                        continue;

                    specs.Add(inst.AsmString);
                }
            }

            Query.TableEmit("llvm.asm.strings", specs.ViewDeposited());
        }
    }
}