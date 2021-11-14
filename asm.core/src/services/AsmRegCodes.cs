//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;

    using static AsmRegTokens;

    [ApiHost]
    public class AsmRegCodes
    {
        [Op]
        public static Type[] RegCodeTypes()
            => _RegCodeTypes.Storage;

        [Op]
        public static Symbols<Gp8Reg> Gp8Regs()
            => _Gp8;

        [Op]
        public static Symbols<Gp8HiReg> Gp8Regs(bit hi)
            => _Gp8Hi;

        [Op]
        public static Symbols<Gp16Reg> Gp16Regs()
            => _Gp16;

        [Op]
        public static Symbols<Gp32Reg> Gp32Regs()
            => _Gp32;

        [Op]
        public static Symbols<Gp64Reg> Gp64Regs()
            => _Gp64;

        [Op]
        public static Symbols<XmmReg> XmmRegs()
            => _Xmm;

        [Op]
        public static Symbols<YmmReg> YmmRegs()
            => _Ymm;

        [Op]
        public static Symbols<ZmmReg> ZmmRegs()
            => _Zmm;

        [Op]
        public static Symbols<KReg> MaskRegs()
            => _KRegs;

        [Op]
        public static Symbols<MmxReg> MmxRegs()
            => _MmxRegs;

        [Op]
        public static Symbols<BndReg> BndRegs()
            => _BndRegs;

        [Op]
        public static Symbols<ControlReg> ControlRegs()
            => _CrRegs;

        [Op]
        public static Symbols<DebugReg> DebugRegs()
            => _DebugRegs;

        [Op]
        public static Symbols<SegReg> SegRegs()
            => _SegRegs;

        [Op]
        public static Symbols<FpuReg> FpuRegs()
            => _FpuRegs;

        [Op]
        public static Symbols<TestReg> TestRegs()
            => _TestRegs;

        [Op]
        public static Symbols<SPtrReg> SysPtrRegs()
            => _SysPtrRegs;

        [Op]
        public static Symbols<NativeSizeCode> RegWidths()
            => _RegWidths;

        [Op]
        public static Symbols<RegIndexCode> RegIndices()
            => _RegIndices;

        [Op]
        public static Symbols<RegClassCode> RegClasses()
            => _RegClasses;

        static Symbols<Gp8Reg> _Gp8;

        static Symbols<Gp8HiReg> _Gp8Hi;

        static Symbols<Gp16Reg> _Gp16;

        static Symbols<Gp32Reg> _Gp32;

        static Symbols<Gp64Reg> _Gp64;

        static Symbols<XmmReg> _Xmm;

        static Symbols<YmmReg> _Ymm;

        static Symbols<ZmmReg> _Zmm;

        static Symbols<KReg> _KRegs;

        static Symbols<MmxReg> _MmxRegs;

        static Symbols<ControlReg> _CrRegs;

        static Symbols<SegReg> _SegRegs;

        static Symbols<FpuReg> _FpuRegs;

        static Symbols<DebugReg> _DebugRegs;

        static Symbols<SPtrReg> _SysPtrRegs;

        static Symbols<BndReg> _BndRegs;

        static Symbols<TestReg> _TestRegs;

        static Symbols<NativeSizeCode> _RegWidths;

        static Symbols<RegIndexCode> _RegIndices;

        static Symbols<RegClassCode> _RegClasses;

        static Index<Type> _RegCodeTypes;

        static Symbols<K> symbols<K>()
            where K : unmanaged, Enum
                => Symbols.index<K>();

        static AsmRegCodes()
        {
            _RegCodeTypes = typeof(AsmCodes).GetNestedTypes().Tagged<RegCodeAttribute>();
            _Gp8 = symbols<Gp8Reg>();
            _Gp8Hi = symbols<Gp8HiReg>();
            _Gp16 = symbols<Gp16Reg>();
            _Gp32 = symbols<Gp32Reg>();
            _Gp64 = symbols<Gp64Reg>();
            _Xmm = symbols<XmmReg>();
            _Ymm = symbols<YmmReg>();
            _Zmm = symbols<ZmmReg>();
            _KRegs = symbols<KReg>();
            _MmxRegs = symbols<MmxReg>();
            _SegRegs  = symbols<SegReg>();
            _CrRegs = symbols<ControlReg>();
            _FpuRegs = symbols<FpuReg>();
            _DebugRegs = symbols<DebugReg>();
            _BndRegs = symbols<BndReg>();
            _TestRegs = symbols<TestReg>();
            _SysPtrRegs = symbols<SPtrReg>();
            _RegWidths = symbols<NativeSizeCode>();
            _RegIndices = symbols<RegIndexCode>();
            _RegClasses = symbols<RegClassCode>();
        }
    }
}