//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static Root;

    partial class AsmCmdService
    {
        [CmdOp(".lookup")]
        Outcome TestKeys(CmdArgs args)
        {
            var outcome = Outcome.Success;
            outcome = DataParser.parse(arg(args,0), out ushort rows);
            if(outcome.Fail)
                return outcome;

            outcome = DataParser.parse(arg(args,1), out ushort cols);
            if(outcome.Fail)
                return outcome;

            var keys = LookupTables.keys(rows,cols);
            for(var i=z16; i<rows; i++)
            for(var j=z16; j<cols; j++)
            {
                ref readonly var key = ref keys[i,j];
                LookupKey expect = (i,j);
                if(!expect.Equals(key))
                    return (false, "Test failed");
            }

            Write("Success");

            return true;
        }
    }
}