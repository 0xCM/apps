//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.IO;

    using static Root;
    using static core;

    [ApiComplete]
    public class AsmRegSets : Service<AsmRegSets>
    {
        AsmSymbols Symbols;

        GpRegGrid _GpGrid;

        Index<char> _Buffer;

        public AsmRegSets()
        {
            _GpGrid = GpRegGrid.Empty;
            _Buffer = alloc<char>(256);
        }

        protected override void Initialized()
        {
            Symbols = Context.AsmSymbols();
        }

        Span<char> Buffer()
            => _Buffer.Clear();

        public uint Emit(in AsciGrid src, StreamWriter dst)
        {
            var count = src.RowCount;
            for(byte i=0; i<count; i++)
                dst.WriteLine(AsciSymbols.format(src.Row(i), Buffer()));
            return (uint)count;
        }

        public RegSet Regs(RegClassCode @class, NativeSizeCode width = default)
        {
            var regs = RegSet.Empty;
            switch(@class)
            {
                case RegClassCode.GP:
                    regs = GpRegs(width);
                break;
                case RegClassCode.XMM:
                    regs = XmmRegs();
                break;
                case RegClassCode.YMM:
                    regs = YmmRegs();
                break;
                case RegClassCode.ZMM:
                    regs = ZmmRegs();
                break;
                case RegClassCode.MASK:
                    regs = MaskRegs();
                break;
            }
            return regs;
        }

        public RegSet XmmRegs()
        {
            const byte Count = 32;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = AsmRegs.reg(NativeSizeCode.W128, RegClassCode.XMM, (RegIndexCode)i);
            return dst;
        }

        public RegSet YmmRegs()
        {
            const byte Count = 32;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = AsmRegs.reg(NativeSizeCode.W128, RegClassCode.YMM, (RegIndexCode)i);
            return dst;
        }

        public RegSet ZmmRegs()
        {
            const byte Count = 32;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = AsmRegs.reg(NativeSizeCode.W512, RegClassCode.ZMM, (RegIndexCode)i);
            return dst;
        }

        public RegSet GpRegs(NativeSizeCode width)
        {
            var dst = RegSet.Empty;
            switch(width)
            {
                case NativeSizeCode.W8:
                    {
                        var count = 20;
                        var buffer = alloc<RegOp>(count);
                        for(var i=0; i<16; i++)
                            seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP, (RegIndexCode)i);
                        for(var i=16; i<20; i++)
                            seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP8HI, (RegIndexCode)(i - 16));
                        dst = buffer;
                    }
                break;
                case NativeSizeCode.W16:
                case NativeSizeCode.W32:
                case NativeSizeCode.W64:
                {
                    var Count = 16;
                    var buffer = alloc<RegOp>(Count);
                    for(var i=0; i<Count; i++)
                        seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP, (RegIndexCode)i);
                    dst = buffer;
                }
                break;
            }
            return dst;
        }

        public RegSet MaskRegs()
        {
            const byte Count = 8;
            var dst = alloc<RegOp>(Count);
            for(var i=0; i<Count; i++)
                seek(dst,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.MASK, (RegIndexCode)i);
            return dst;
        }
    }
}