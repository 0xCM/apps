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
        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;
        }

        [CmdOp("check/data/tables")]
        unsafe Outcome TestDataTables(CmdArgs args)
        {
            var m = 0xF;
            var n = 0xA;
            var data = new ulong[m,n];
            for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                data[i,j] = (ulong)(i*j);


            fixed(ulong* pSrc = data)
            {
                MemoryAddress @base = pSrc;
                var pCurrent = pSrc;
                for(var i=0; i<m; i++)
                {
                    for(var j=0; j<n; j++)
                    {
                        MemoryAddress loc = pCurrent;
                        var a = *pCurrent++;
                        Require.equal(a, (ulong)(i*j));
                        //Require.equal(b, a);
                        Write(string.Format("{0} {1} {2}x{3}={4}", loc, loc - @base, i, j, a));
                    }
                }
            }

            var dst = Unsafe.As<TableInfo>(data);
            Write(string.Format("{0}={1}x{2}", dst.Count, dst.M, dst.N));

            return true;
        }

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