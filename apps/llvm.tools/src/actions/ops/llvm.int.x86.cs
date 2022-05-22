//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmdProvider
    {
        [CmdOp("llvm/int/x86")]
        Outcome LoadIntrinsics(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities();
            var count = entities.Length;
            var counter = 0u;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref entities[i];
                if(entity.IsIntrinsic())
                {
                    var intrinsic = entity.ToIntrinsic();
                    if(intrinsic.TargetPrefix == "x86")
                        specs.Add(intrinsic.EntityName);
                }
            }

            Query.EmitFile("llvm/int/x86", specs.ViewDeposited());

            return true;
        }
    }
}