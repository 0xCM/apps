//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("inst")]
        public Outcome ShowInst(CmdArgs args)
        {
            var entities = DataLoader.LoadEntities().Members;
            var count = entities.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsInstruction())
                {
                    var inst = entity.ToInstruction();
                    if(inst.isCodeGenOnly || inst.isPseudo)
                        continue;

                    Write(string.Format("{0,-24} | {1,-16} | {2}", inst.InstName, inst.Mnemonic, inst.AsmString));
                }
            }
            return true;
        }

        [CmdOp("inst-alias")]
        Outcome ShowInstAlias(CmdArgs args)
        {
            var entities = DataLoader.LoadEntities().Members;
            var count = entities.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);

                if(entity.IsInstAlias())
                {
                    var alias = entity.ToInstAlias();
                    Write(string.Format("{0,-24} | {1,-16} | {2}", alias.InstName, alias.Mnemonic, alias.AsmString));
                }
            }

            return true;
        }

        [CmdOp("x86-intrinsics")]
        Outcome LoadIntrinsics(CmdArgs args)
        {
            var entities = DataLoader.LoadEntities().Members;
            var count = entities.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsIntrinsic())
                {
                    var intrinsic = entity.ToIntrinsic();
                    if(intrinsic.TargetPrefix == "x86")
                    {
                        Write(intrinsic.IntrinsicName);
                    }
                }
            }

            return true;
        }
    }
}