//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("intrinsics/x86")]
        Outcome LoadIntrinsics(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities().Members;
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