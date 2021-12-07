//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        const string X86IntQuery = "llvm/int/x86";

        [CmdOp(X86IntQuery)]
        Outcome LoadIntrinsics(CmdArgs args)
        {
            var entities = DataProvider.SelectEntities().Members;
            var count = entities.Length;
            var counter = 0u;
            var specs = list<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var entity = ref skip(entities,i);
                if(entity.IsIntrinsic())
                {
                    var intrinsic = entity.ToIntrinsic();
                    if(intrinsic.TargetPrefix == "x86")
                        specs.Add(intrinsic.CanonicalName);
                }
            }

            Flow(X86IntQuery, specs.ViewDeposited());

            return true;
        }
    }
}