//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmdProvider
    {
        const string X86IntrinsicsQuery = "llvm/int/x86";

        [CmdOp(X86IntrinsicsQuery)]
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
                        specs.Add(intrinsic.CanonicalName);
                }
            }

            DataEmitter.EmitQueryResults(X86IntrinsicsQuery, specs.ViewDeposited());

            return true;
        }
    }
}