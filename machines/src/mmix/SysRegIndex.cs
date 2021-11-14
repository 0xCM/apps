//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    partial struct MMIX
    {
        /// <summary>
        /// Patterned after Knuth's MMIX machine
        /// </summary>
        [SymSource]
        public enum SysRegIndex : ushort
        {
            [Symbol("rA")]
            A = 256,

            [Symbol("rB")]
            B,

            [Symbol("rC")]
            C,

            [Symbol("rD")]
            D,

            [Symbol("rE")]
            E,

            [Symbol("rF")]
            F,

            [Symbol("rG")]
            G,

            [Symbol("rH")]
            H,

            [Symbol("rI")]
            I,

            [Symbol("rJ")]
            J,

            [Symbol("rK")]
            K,

            [Symbol("rL")]
            L,

            [Symbol("rM")]
            M,

            [Symbol("rN")]
            N,

            [Symbol("rO")]
            O,

            [Symbol("rP")]
            P,

            [Symbol("rQ")]
            Q,

            [Symbol("rR")]
            R,

            [Symbol("rS")]
            S,

            [Symbol("rT")]
            T,

            [Symbol("rU")]
            U,

            [Symbol("rV")]
            V,

            [Symbol("rW")]
            W,

            [Symbol("rZ")]
            X,

            [Symbol("rY")]
            Y,

            [Symbol("rZ")]
            Z,

            [Symbol("rBB")]
            BB,

            [Symbol("rTT")]
            TT,

            [Symbol("rWW")]
            WW,

            [Symbol("rXX")]
            XX,

            [Symbol("rYY")]
            YY,

            [Symbol("rZZ")]
            ZZ
        }
    }
}