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

    using api = AsmRegs;

    public readonly struct RegOp<T> : IRegOp<T>
        where T : unmanaged, IRegOp
    {
        readonly T Data;

        [MethodImpl(Inline)]
        public RegOp(T src)
        {
            Data = src;
        }

        public ushort Bitfield
        {
            [MethodImpl(Inline)]
            get => u16(Data);
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => Data.Index;
        }

        public RegClassCode RegClassCode
        {
            [MethodImpl(Inline)]
            get => Data.RegClassCode;
        }

        public NativeSizeCode Size
        {
            [MethodImpl(Inline)]
            get => Data.WidthCode;
        }

        public NativeSizeCode WidthCode
        {
            [MethodImpl(Inline)]
            get => Data.WidthCode;
        }

        public RegWidth RegWidth
        {
            [MethodImpl(Inline)]
            get => WidthCode;
        }

        public RegClass RegClass
        {
            [MethodImpl(Inline)]
            get => RegClassCode;
        }

        public AsmOpClass OpClass
        {
            [MethodImpl(Inline)]
            get => AsmOpClass.R;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        public AsmRegName Name
        {
            [MethodImpl(Inline)]
            get => api.name(this);
        }

        public string Format()
            => string.Format("{0}/{1}/{2}", Index, RegClassCode, WidthCode);

        public override string ToString()
            =>  Format();
    }
}