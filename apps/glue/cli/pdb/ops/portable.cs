//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;
    using static core;

    partial struct PdbServices
    {
        [MethodImpl(Inline),Op]
        public static bit portable(in byte src)
        {
            var result = bit.On;
            var j=0;
            result &= (skip(src, j++) == 'B');
            result &= (skip(src, j++) == 'S');
            result &= (skip(src, j++) == 'J');
            result &= (skip(src, j++) == 'B');
            return result;
        }

        [MethodImpl(Inline),Op]
        public static bit portable(ReadOnlySpan<byte> src)
            => portable(first(src));

        [MethodImpl(Inline),Op]
        public static unsafe bit portable(byte* pSrc)
            => portable(@ref(pSrc));

        [Op]
        public static bit portable(Stream pdb)
        {
            pdb.Position = 0;
            var test = pdb.ReadByte() == 'B' && pdb.ReadByte() == 'S' && pdb.ReadByte() == 'J' && pdb.ReadByte() == 'B';
            pdb.Position = 0;
            return test;
        }
    }
}