//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static Char5;
    using static core;
    using static XedGrids;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var cells = CalcRuleCells();
            ref readonly var tables = ref cells.Tables;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref tables[i];
                for(var j=0; i<table.RowCount; j++)
                {
                    ref readonly var row = ref table[i];
                    for(var k=0; i<row.CellCount; k++)
                    {
                        ref readonly var cell = ref row[k];
                    }
                }
            }

            return true;
        }

    }
}