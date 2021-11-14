//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static AsmRegTokens;
    using static SdmModels;

    [ApiHost]
    public class AsmSymbols
    {
        readonly Symbols<AsmMnemonicCode> _Mnemonics;

        readonly Symbols<Gp8Reg> _Gp8Regs;

        readonly Symbols<Gp8HiReg> _Gp8HiRegs;

        readonly Symbols<Gp16Reg> _Gp16Regs;

        readonly Symbols<Gp32Reg> _Gp32Regs;

        readonly Symbols<Gp64Reg> _Gp64Regs;

        readonly Symbols<KReg> _KRegs;

        readonly Symbols<XmmReg> _XmmRegs;

        readonly Symbols<YmmReg> _YmmRegs;

        readonly Symbols<ZmmReg> _ZmmRegs;

        readonly Symbols<MmxReg> _MmxRegs;

        readonly Symbols<ControlReg> _CrRegs;

        readonly Symbols<SegReg> _SegRegs;

        readonly Symbols<FpuReg> _FpuRegs;

        readonly Symbols<DebugReg> _DebugRegs;

        readonly Symbols<SPtrReg> _SysPtrRegs;

        readonly Symbols<BndReg> _BndRegs;

        readonly Symbols<TestReg> _TestRegs;

        readonly Symbols<NativeSizeCode> _RegWidths;

        readonly Symbols<RegIndexCode> _RegIndices;

        readonly Symbols<RegClassCode> _RegClasses;

        readonly Symbols<ModRmEncKind> _ModRmEncKind;

        public static AsmSymbols create()
            => new AsmSymbols();

        AsmSymbols()
        {
            _Mnemonics = Symbols.index<AsmMnemonicCode>();
            _Gp8Regs = AsmRegCodes.Gp8Regs();
            _Gp8HiRegs = AsmRegCodes.Gp8Regs(true);
            _Gp16Regs = AsmRegCodes.Gp16Regs();
            _Gp32Regs = AsmRegCodes.Gp32Regs();
            _Gp64Regs = AsmRegCodes.Gp64Regs();
            _KRegs = AsmRegCodes.MaskRegs();
            _XmmRegs = AsmRegCodes.XmmRegs();
            _YmmRegs = AsmRegCodes.YmmRegs();
            _ZmmRegs = AsmRegCodes.ZmmRegs();
            _MmxRegs = AsmRegCodes.MmxRegs();
            _SegRegs  = AsmRegCodes.SegRegs();
            _CrRegs = AsmRegCodes.ControlRegs();
            _FpuRegs = AsmRegCodes.FpuRegs();
            _DebugRegs = AsmRegCodes.DebugRegs();
            _BndRegs = AsmRegCodes.BndRegs();
            _TestRegs = AsmRegCodes.TestRegs();
            _SysPtrRegs = AsmRegCodes.SysPtrRegs();
            _RegIndices = AsmRegCodes.RegIndices();
            _RegWidths = AsmRegCodes.RegWidths();
            _RegClasses = AsmRegCodes.RegClasses();
            _ModRmEncKind = Symbols.index<ModRmEncKind>();
        }

        [MethodImpl(Inline), Op]
        public ref readonly Sym<AsmMnemonicCode> Symbol(AsmMnemonicCode key)
            => ref _Mnemonics[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<Gp8Reg> Symbol(Gp8Reg key)
            => ref _Gp8Regs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<Gp16Reg> Symbol(Gp16Reg key)
            => ref _Gp16Regs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<Gp32Reg> Symbol(Gp32Reg key)
            => ref _Gp32Regs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<Gp64Reg> Symbol(Gp64Reg key)
            => ref _Gp64Regs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<KReg> Symbol(KReg key)
            => ref _KRegs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<XmmReg> Symbol(XmmReg key)
            => ref _XmmRegs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<YmmReg> Symbol(YmmReg key)
            => ref _YmmRegs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<ZmmReg> Symbol(ZmmReg key)
            => ref _ZmmRegs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<ControlReg> Symbol(ControlReg key)
            => ref _CrRegs[key];

        [MethodImpl(Inline), Op]
        public ref readonly Sym<DebugReg> Symbol(DebugReg key)
            => ref _DebugRegs[key];

        public ref readonly Sym<AsmMnemonicCode> this[AsmMnemonicCode key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<Gp8Reg> this[Gp8Reg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<Gp16Reg> this [Gp16Reg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<Gp32Reg> this[Gp32Reg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<Gp64Reg> this[Gp64Reg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<KReg> this[KReg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<XmmReg> this[XmmReg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<YmmReg> this[YmmReg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<ZmmReg> this[ZmmReg key]
        {
            [MethodImpl(Inline)]
            get => ref Symbol(key);
        }

        public ref readonly Sym<MmxReg> this[MmxReg key]
        {
            [MethodImpl(Inline)]
            get => ref _MmxRegs[key];
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<Sym<K>> Regs<K>()
            where K : unmanaged
                => RegsGp<K>();

        [Op]
        public Symbols<Gp8Reg> Gp8Regs()
            => _Gp8Regs;

        [Op]
        public Symbols<Gp8HiReg> Gp8Regs(bit hi)
            => _Gp8HiRegs;

        [Op]
        public Symbols<Gp16Reg> Gp16Regs()
            => _Gp16Regs;

        [Op]
        public Symbols<Gp32Reg> Gp32Regs()
            => _Gp32Regs;

        [Op]
        public Symbols<Gp64Reg> Gp64Regs()
            => _Gp64Regs;

        [Op]
        public Symbols<XmmReg> XmmRegs()
            => _XmmRegs;

        [Op]
        public Symbols<YmmReg> YmmRegs()
            => _YmmRegs;

        [Op]
        public Symbols<ZmmReg> ZmmRegs()
            => _ZmmRegs;

        [Op]
        public Symbols<KReg> MaskRegs()
            => _KRegs;

        [Op]
        public Symbols<MmxReg> MmxRegs()
            => _MmxRegs;

        [Op]
        public Symbols<BndReg> BndRegs()
            => _BndRegs;

        [Op]
        public Symbols<ControlReg> ControlRegs()
            => _CrRegs;

        [Op]
        public Symbols<DebugReg> DebugRegs()
            => _DebugRegs;

        [Op]
        public Symbols<SegReg> SegRegs()
            => _SegRegs;

        [Op]
        public Symbols<FpuReg> FpuRegs()
            => _FpuRegs;

        [Op]
        public Symbols<TestReg> TestRegs()
            => _TestRegs;

        [Op]
        public Symbols<SPtrReg> SysPtrRegs()
            => _SysPtrRegs;

        [MethodImpl(Inline)]
        ReadOnlySpan<Sym<K>> RegsGp<K>()
            where K : unmanaged
        {
            if(typeof(K) == typeof(Gp8Reg))
                return recover<Sym<Gp8Reg>,Sym<K>>(_Gp8Regs.View);
            else if(typeof(K) == typeof(Gp16Reg))
                return recover<Sym<Gp16Reg>,Sym<K>>(_Gp16Regs.View);
            else if(typeof(K) == typeof(Gp32Reg))
                return recover<Sym<Gp32Reg>,Sym<K>>(_Gp32Regs.View);
            else if(typeof(K) == typeof(Gp64Reg))
                return recover<Sym<Gp64Reg>,Sym<K>>(_Gp64Regs.View);
            else
                return RegsMM<K>();
        }

        [MethodImpl(Inline)]
        ReadOnlySpan<Sym<K>> RegsMM<K>()
            where K : unmanaged
        {
            if(typeof(K) == typeof(XmmReg))
                return recover<Sym<XmmReg>,Sym<K>>(_XmmRegs.View);
            else if(typeof(K) == typeof(YmmReg))
                return recover<Sym<YmmReg>,Sym<K>>(_YmmRegs.View);
            else if(typeof(K) == typeof(ZmmReg))
                return recover<Sym<ZmmReg>,Sym<K>>(_ZmmRegs.View);
            else if(typeof(K) == typeof(MmxReg))
                return recover<Sym<MmxReg>,Sym<K>>(_MmxRegs.View);
            else
                return RegsCR<K>();
        }

        [MethodImpl(Inline)]
        ReadOnlySpan<Sym<K>> RegsCR<K>()
            where K : unmanaged
        {
            if(typeof(K) == typeof(ControlReg))
                return recover<Sym<ControlReg>,Sym<K>>(_CrRegs.View);
            else
                throw no<K>();
        }
    }
}