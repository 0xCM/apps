//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;

    partial class CheckCmdProvider
    {
        [CmdOp("check/lookups")]
        Outcome TestKeys(CmdArgs args)
        {
            var outcome = Outcome.Success;
            ushort rows = 128;
            ushort cols = 128;

            var keys = LookupTables.keys(rows,cols);
            for(var i=z16; i<rows; i++)
            for(var j=z16; j<cols; j++)
            {
                ref readonly var key = ref keys[i,j];
                LookupKey expect = (i,j);
                if(!expect.Equals(key))
                    return (false, "Test failed");
            }

            Status(string.Format("Verifified {0} lookup operations", rows*cols));

            return true;
        }
    }
}