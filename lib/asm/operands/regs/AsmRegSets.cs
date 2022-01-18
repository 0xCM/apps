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
    using static RegFacets;

    [ApiComplete]
    public class AsmRegSets : AppService<AsmRegSets>
    {
        Index<char> _Buffer;

        public AsmRegSets()
        {
            _Buffer = alloc<char>(256);
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

        public RegOpSeq Regs(RegClassCode @class)
        {
            var regs = RegOpSeq.Empty;
            switch(@class)
            {
                case RegClassCode.GP:
                    regs = GpRegs();
                break;
                case RegClassCode.GP8HI:
                    regs = Gp8HiRegs();
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
                case RegClassCode.MMX:
                    regs = MaskRegs();
                break;
                case RegClassCode.BND:
                    regs = BndRegs();
                break;
            }
            return regs;
        }

        public RegOpSeq GpRegs()
        {
            return Data(nameof(GpRegs), Load);

            RegOpSeq Load()
            {
                var gp8 = Gp8Regs();
                var gp16 = Gp16Regs();
                var gp32 = Gp32Regs();
                var gp64 = Gp64Regs();
                return gp8.Concat(gp16, gp32, gp64);
            }
        }

        public RegOpSeq XmmRegs()
        {
            return Data(nameof(XmmRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = XmmRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W128, RegClassCode.XMM, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq YmmRegs()
        {
            return Data(nameof(YmmRegs), Load);
            RegOpSeq Load()
            {
                const byte Count = YmmRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W128, RegClassCode.YMM, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq ZmmRegs()
        {
            return Data(nameof(ZmmRegs), Load);
            RegOpSeq Load()
            {
                const byte Count = ZmmRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W512, RegClassCode.ZMM, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq Gp8HiRegs()
        {
            return Data(nameof(Gp8HiRegs), Load);

            RegOpSeq Load()
            {
                var width = NativeSizeCode.W8;
                var count = Gp8HiRegCount;
                var buffer = alloc<RegOp>(count);
                for(var i=0; i<count; i++)
                    seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP8HI, (RegIndexCode)(i - 16));
                return buffer;
            }
        }

        public RegOpSeq Gp8LoRegs()
        {
            return Data(nameof(Gp8LoRegs), Load);

            RegOpSeq Load()
            {
                var width = NativeSizeCode.W8;
                var count = Gp8LoRegCount;
                var buffer = alloc<RegOp>(count);
                for(var i=0; i<count; i++)
                    seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq Gp8Regs()
        {
            return Data(nameof(Gp8Regs), Load);

            RegOpSeq Load()
            {
                var width = NativeSizeCode.W8;
                var count = GpRegCount;
                var buffer = alloc<RegOp>(count);
                for(var i=0; i<16; i++)
                    seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP, (RegIndexCode)i);
                for(var i=16; i<20; i++)
                    seek(buffer,i) = AsmRegs.reg(width, RegClassCode.GP8HI, (RegIndexCode)(i - 16));
                return buffer;
            }
        }

        public RegOpSeq Gp16Regs()
        {
            return Data(nameof(Gp16Regs), Load);

            RegOpSeq Load()
            {
                const byte Count = Gp16RegCount;
                var buffer = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(buffer,i) = AsmRegs.reg(NativeSizeCode.W16, RegClassCode.GP, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq Gp32Regs()
        {
            return Data(nameof(Gp32Regs), Load);

            RegOpSeq Load()
            {
                const byte Count = Gp32RegCount;
                var buffer = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(buffer,i) = AsmRegs.reg(NativeSizeCode.W32, RegClassCode.GP, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq Gp64Regs()
        {
            return Data(nameof(Gp64Regs), Load);

            RegOpSeq Load()
            {
                const byte Count = Gp64RegCount;
                var buffer = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(buffer,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.GP, (RegIndexCode)i);
                return buffer;
            }
        }

        public RegOpSeq GpRegs(NativeSizeCode width)
        {
            var dst = RegOpSeq.Empty;
            switch(width)
            {
                case NativeSizeCode.W8:
                    dst = Gp8Regs();
                break;
                case NativeSizeCode.W16:
                    dst = Gp16Regs();
                break;
                case NativeSizeCode.W32:
                    dst = Gp32Regs();
                break;
                case NativeSizeCode.W64:
                    dst = Gp64Regs();
                break;
            }
            return dst;
        }

        public RegOpSeq MaskRegs()
        {
            return Data(nameof(MaskRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = MaskRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.MASK, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq CrRegs()
        {
            return Data(nameof(CrRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = CrRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.CR, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq DbRegs()
        {
            return Data(nameof(DbRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = DbRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.DB, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq MmxRegs()
        {
            return Data(nameof(MmxRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = MmxRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.MMX, (RegIndexCode)i);
                return dst;
            }
        }

        public RegOpSeq BndRegs()
        {
            return Data(nameof(BndRegs), Load);

            RegOpSeq Load()
            {
                const byte Count = BndRegCount;
                var dst = alloc<RegOp>(Count);
                for(var i=0; i<Count; i++)
                    seek(dst,i) = AsmRegs.reg(NativeSizeCode.W64, RegClassCode.BND, (RegIndexCode)i);
                return dst;
            }
        }
    }
}