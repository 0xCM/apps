//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using F = RFlagBits;
    using I = RFlagIndex;

    [ApiComplete]
    public struct RFlags : IEquatable<RFlags>
    {
        RFlagBits State;

        [MethodImpl(Inline)]
        public RFlags(RFlagBits state)
            => State = state;

        [MethodImpl(Inline)]
        public RFlags(StatusFlagBits state)
            => State = (RFlagBits)state;

        [MethodImpl(Inline)]
        public bit CF()
            => (State & F.CF) != 0;

        [MethodImpl(Inline)]
        public void CF(bit f)
            => State = (F)bit.set((uint)State, (byte)I.CF, f);

        [MethodImpl(Inline)]
        public bit PF()
            => (State & F.PF) != 0;

        [MethodImpl(Inline)]
        public void PF(bit pf)
            => State = (F)bit.set((uint)State, (byte)I.PF, pf);

        [MethodImpl(Inline)]
        public bit AF()
            => (State & F.AF) != 0;

        [MethodImpl(Inline)]
        public void AF(bit f)
            => State = (F)bit.set((uint)State, (byte)I.AF, f);

        [MethodImpl(Inline)]
        public bit OF()
            => (State & F.OF) != 0;

        [MethodImpl(Inline)]
        public void OF(bit f)
            => State = (F)bit.set((uint)State, (byte)I.OF, f);

        [MethodImpl(Inline)]
        public bit SF()
            => (State & F.SF) != 0;

        [MethodImpl(Inline)]
        public void SF(bit f)
            => State = (F)bit.set((uint)State, (byte)I.SF, f);

        [MethodImpl(Inline)]
        public bit ZF()
            => (State & F.ZF) != 0;

        [MethodImpl(Inline)]
        public void ZF(bit f)
            => State = (F)bit.set((uint)State, (byte)I.ZF, f);

        [MethodImpl(Inline)]
        public bit NO()
            => (State & F.OF) == 0;

        [MethodImpl(Inline)]
        public bit NC()
            => (State & F.CF) == 0;

        [MethodImpl(Inline)]
        public bit NZ()
            => (State & F.ZF) == 0;

        [MethodImpl(Inline)]
        public bit NS()
            => (State & F.SF) == 0;

        [MethodImpl(Inline)]
        public bit NP()
            => (State & F.PF) == 0;

        [MethodImpl(Inline)]
        public bit LT()
            => SF() != OF();

        [MethodImpl(Inline)]
        public bit A()
            => (State & F.CF) == 0 && (State & F.ZF) == 0;

        [MethodImpl(Inline)]
        public bit NA()
            => !A();

        [MethodImpl(Inline)]
        public bit TF()
            => (State & F.TF) == 0;

        [MethodImpl(Inline)]
        public bit IF()
            => (State & F.IF) == 0;

        [MethodImpl(Inline)]
        public bit DF()
            => (State & F.DF) == 0;

        [MethodImpl(Inline)]
        public bit RF()
            => (State & F.RF) == 0;

        [MethodImpl(Inline)]
        public bit VM()
            => (State & F.VM) == 0;

        [MethodImpl(Inline)]
        public bit AC()
            => (State & F.AC) == 0;

        [MethodImpl(Inline)]
        public bit VIF()
            => (State & F.VIF) == 0;

        [MethodImpl(Inline)]
        public bit VIP()
            => (State & F.VIP) == 0;

        [MethodImpl(Inline)]
        public bit ID()
            => (State & F.ID) == 0;

        [MethodImpl(Inline)]
        public bit Read(I i)
            => bit.test((uint)State, (byte)i);

        [MethodImpl(Inline)]
        public void Write(I index, bit b)
            => State = (F)bit.set((uint)State, (byte)index, b);

        [MethodImpl(Inline)]
        public bool Equals(RFlags src)
            => State == src.State;

        public string Format()
        {
            const string H = "CF | PF | AF | ZF | SF | TF | IF | DF | OF | RF | VM | AC | VIF | VIP | ID";
            const string P = "{0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} | {10} | {11} | {12} | {13} | {14}";
            var values = string.Format(P,CF(), PF(), AF(), ZF(), SF(), TF(), IF(), DF(), OF(), RF(), VM(), AC(), VIF(), VIP(), ID());
            return string.Format("{0}\n{1}", H, values);
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator RFlags(StatusFlagBits src)
            => new RFlags(src);

        [MethodImpl(Inline)]
        public static implicit operator RFlags(RFlagBits src)
            => new RFlags(src);
    }
}