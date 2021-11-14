//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86.Regs
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;
    using static gbits;

    using K = Asm.RFlags.RFlagBits;
    using I = Asm.RFlags.RFlagIndex;

    [ApiComplete("regs.rflags")]
    public struct rflags : IReg<rflags,W32,K>
    {
        K Data;

        [Ignore]
        public K Content
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        [Ignore]
        public RegKind RegKind
            => RegKind.RFLAGS;

        public bit CF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.CF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.CF, value);
        }

        public bit PF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.PF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.PF, value);
        }

        public bit AF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.AF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.AF, value);
        }

        public bit ZF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.ZF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.ZF, value);
        }

        public bit SF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.SF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.SF, value);
        }

        public bit TF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.TF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.TF, value);
        }

        public bit IF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.IF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.IF, value);
        }

        public bit DF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.DF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.DF, value);
        }

        public bit OF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.OF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.OF, value);
        }

        public bit RF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.RF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.RF, value);
        }

        public bit VM
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.VM);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.VM, value);
        }

        public bit AC
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.AC);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.AC, value);
        }

        public bit VIF
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.VIF);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.VIF, value);
        }

        public bit VIP
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.VIP);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.VIP, value);
        }

        public bit ID
        {
            [MethodImpl(Inline)]
            get => testbit(Data, I.ID);

            [MethodImpl(Inline)]
            set => Data = setbit(Data, I.ID, value);
        }
    }
}