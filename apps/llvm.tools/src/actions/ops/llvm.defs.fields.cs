//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;
    partial class LlvmCmdProvider
    {
        const string DefFieldQuery = "llvm/defs/fields";

        [CmdOp(DefFieldQuery)]
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

                Query.FileEmit(DefFieldQuery, slice(DataProvider.DefFields().View, offset, length));
            }
            return result;
        }
    }
}