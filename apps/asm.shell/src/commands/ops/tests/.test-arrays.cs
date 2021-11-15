//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DataTableTest<T>
    {
        readonly T[,] Storage;

        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;

            internal byte Head;
        }

        [MethodImpl(Inline)]
        public DataTableTest(uint m, uint n)
        {
            Storage = new T[m,n];
        }

        [MethodImpl(Inline)]
        public DataTableTest(T[,] src)
        {
            Storage = src;
        }

        static byte Delta => (core.size<T>() == 8) ? (byte)1 : core.size<T>() == 4 ? (byte)2 : (byte)0;

        public TableInfo StorageInfo
        {
            [MethodImpl(Inline)]
            get => Unsafe.As<TableInfo>(Storage);
        }

        [MethodImpl(Inline)]
        public static ref T seek(T[,] src, uint i, uint j)
        {
            var header = Unsafe.As<TableInfo>(src);
            ref T lead = ref Unsafe.As<byte,T>(ref header.Head);
            var offset = i*j + j;
            return ref core.seek(lead, offset);
        }

        public ref T this[uint i, uint j]
        {
            [MethodImpl(Inline)]
            get => ref seek(Storage,i,j);
        }
    }

    partial class AsmCmdService
    {
        public class TableInfo
        {
            public ulong Count;

            public uint M;

            public uint N;
        }

        [CmdOp(".test-arrays")]
        unsafe Outcome TestArrays(CmdArgs args)
        {
            var m = 0xF;
            var n = 0xA;
            var src = new ulong[m,n];
            for(var i=0; i<m; i++)
            for(var j=0; j<n; j++)
                src[i,j] = (ulong)(i*j);

            fixed(ulong* pSrc = src)
            {
                MemoryAddress @base = pSrc;
                var pCurrent = pSrc;
                for(var i=0; i<m; i++)
                {
                    for(var j=0; j<n; j++)
                    {
                        MemoryAddress loc = pCurrent;
                        var value = *pCurrent++;
                        Require.equal(value, (ulong)(i*j));
                        Write(string.Format("{0} {1} {2}x{3}={4}", loc, loc - @base, i, j, value));
                    }
                }
            }

            var dst = Unsafe.As<TableInfo>(src);
            Write(string.Format("{0}={1}x{2}", dst.Count, dst.M, dst.N));

            return true;
        }
    }
}