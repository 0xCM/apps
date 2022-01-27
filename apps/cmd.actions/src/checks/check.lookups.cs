//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;
    using System.Runtime.InteropServices;

    using static core;
    using static Root;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct ParseTableEntry : IComparable<ParseTableEntry>
    {
        public const string TableId = "parse.tables";

        public const byte FieldCount = 5;

        public uint Seq;

        public ushort KindSeq;

        public text31 KindName;

        public ushort ExprSeq;

        public text31 Expr;

        public int CompareTo(ParseTableEntry src)
        {
            var result = KindSeq.CompareTo(src.KindSeq);
            if(result == 0)
                result = ExprSeq.CompareTo(src.ExprSeq);
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,32,8,32};
    }

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