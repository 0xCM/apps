//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct IceConverters
    {
        [MethodImpl(Inline), Op]
        public static IceMemDirect memDirect(in IceInstruction src)
            => new IceMemDirect(src.MemoryBase, src.MemoryIndexScale, src.MemoryDisplacement, (uint)src.MemoryDisplSize);

        [Op]
        public static IceMemoryInfo meminfo(in IceInstruction src, byte index)
        {
            var k = opkind(src, (byte)index);
            if(IceOpTest.isMem(k))
            {
                var direct = IceOpTest.isMemDirect(k);
                var segBase = IceOpTest.isSegBase(k);
                var mem64 = IceOpTest.isMem64(k);
                var info = new IceMemoryInfo();
                var sz = src.MemorySize;
                var memdirect = direct ? memDirect(src) : IceMemDirect.Empty;
                var prefix = (direct || segBase) ? src.SegmentPrefix : Z0.Asm.IceRegister.None;
                var sReg = (direct || segBase) ? src.MemorySegment : Z0.Asm.IceRegister.None;
                var address = mem64 ? src.MemoryAddress64 : 0;
                return new IceMemoryInfo(sReg, prefix, memdirect, address, sz);
            }

            return default;
        }
   }
}