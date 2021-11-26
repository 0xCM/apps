//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static LlvmNames;
    using static core;

    partial class LlvmCmd
    {
        [CmdOp(Queries.fields)]
        Outcome Fields(CmdArgs args)
        {
            var result = Outcome.Success;
            if(args.Length == 2)
            {
                DataParser.parse(arg(args,0).Value, out uint offset);
                DataParser.parse(arg(args,1).Value, out uint length);
                var fields = Db.Fields(offset,length);
                iter(fields, f => Write(f.Format()));
            }
            return result;
        }
    }
}