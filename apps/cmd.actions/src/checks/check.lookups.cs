//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;


    partial class CheckCmdProvider
    {
        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;
        }


        [CmdOp("check/block/size")]
        Outcome CheckBlockSize(CmdArgs args)
        {
            ByteBlock4 block4 = 0xFF000000;
            Write(Storage.trim(block4).Format());


            ByteBlock4 block3 = 0xFF0000;
            Write(Storage.trim(block3).Format());

            ByteBlock4 block2 =  0xFF00;
            Write(Storage.trim(block2).Format());

            ByteBlock4 block1 =  0xFF;
            Write(Storage.trim(block1).Format());

            ByteBlock4 block0 =  0x0;
            Write(Storage.trim(block0).Format());


            return true;
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
            ushort rows = Pow2.T13;
            ushort cols = Pow2.T13;
            var keys = LookupTables.keys(rows,cols);
            var range = Intervals.closed(z16, (ushort)(rows - 1)).Partition();
            iter(range,i =>{
            for(var j=z16; j<cols; j++)
            {
                ref readonly var key = ref keys[i,j];
                LookupKey expect = (i,j);
                Require.invariant(expect.Equals(key));
            }
            },true);

            Status(string.Format("Verifified {0} lookup operations", rows*cols));

            return true;
        }
    }
}