//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    partial class LlvmCmd
    {
        [CmdOp("llvm/defs/fields")]
        Outcome ShowDefFields(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Length == 2)
            {
                result = DataParser.parse(arg(args,0).Value, out uint offset);
                if(result.Fail)
                    return result;
                result = DataParser.parse(arg(args,1).Value, out uint length);

                if(result.Fail)
                    return result;

                Query.FileEmit("llvm/defs/fields", slice(DataProvider.DefFields().View, offset, length));
            }
            return result;
        }
    }
}