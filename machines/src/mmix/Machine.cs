//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static MMIX.SysRegIndex;

    partial struct MMIX
    {
        /// <summary>
        /// Patterned after Knuth's MMIX machine
        /// </summary>
        [ApiComplete("machine.mmix")]
        public class Machine
        {
            readonly NativeBuffer<ulong> Regs;

            public uint Id {get;}

            public static Machine allocate(uint id)
                => new Machine(id);

            internal Machine(uint id)
            {
                Id = id;
                Regs = memory.native<ulong>(256 + 32);
            }

            [MethodImpl(Inline)]
            public ref ulong GpReg(byte index)
                => ref Regs[index];

            [MethodImpl(Inline)]
            public ref ulong SysReg(SysRegIndex index)
                => ref Regs[(ushort)index];

            [MethodImpl(Inline)]
            public ref ulong rA()
                => ref SysReg(A);

            [MethodImpl(Inline)]
            public ref ulong rB()
                => ref SysReg(B);

            [MethodImpl(Inline)]
            public ref ulong rC()
                => ref SysReg(C);

            [MethodImpl(Inline)]
            public ref ulong rD()
                => ref SysReg(D);

            [MethodImpl(Inline)]
            public ref ulong rE()
                => ref SysReg(E);

            [MethodImpl(Inline)]
            public ref ulong rF()
                => ref SysReg(F);

            [MethodImpl(Inline)]
            public ref ulong rG()
                => ref SysReg(B);

            [MethodImpl(Inline)]
            public ref ulong rH()
                => ref SysReg(H);

            [MethodImpl(Inline)]
            public ref ulong rI()
                => ref SysReg(I);

            [MethodImpl(Inline)]
            public ref ulong rJ()
                => ref SysReg(J);

            [MethodImpl(Inline)]
            public ref ulong rK()
                => ref SysReg(K);

            [MethodImpl(Inline)]
            public ref ulong rL()
                => ref SysReg(L);

            [MethodImpl(Inline)]
            public ref ulong rM()
                => ref SysReg(M);

            [MethodImpl(Inline)]
            public ref ulong rN()
                => ref SysReg(N);

            [MethodImpl(Inline)]
            public ref ulong rO()
                => ref SysReg(O);

            [MethodImpl(Inline)]
            public ref ulong rP()
                => ref SysReg(P);

            [MethodImpl(Inline)]
            public ref ulong rQ()
                => ref SysReg(Q);

            [MethodImpl(Inline)]
            public ref ulong rR()
                => ref SysReg(R);

            [MethodImpl(Inline)]
            public ref ulong rS()
                => ref SysReg(S);

            [MethodImpl(Inline)]
            public ref ulong rT()
                => ref SysReg(T);

            [MethodImpl(Inline)]
            public ref ulong rU()
                => ref SysReg(U);

            [MethodImpl(Inline)]
            public ref ulong rV()
                => ref SysReg(V);

            [MethodImpl(Inline)]
            public ref ulong rW()
                => ref SysReg(W);

            [MethodImpl(Inline)]
            public ref ulong rX()
                => ref SysReg(N);

            [MethodImpl(Inline)]
            public ref ulong rY()
                => ref SysReg(Y);

            [MethodImpl(Inline)]
            public ref ulong rZ()
                => ref SysReg(Z);

            [MethodImpl(Inline)]
            public ref ulong rBB()
                => ref SysReg(BB);

            [MethodImpl(Inline)]
            public ref ulong rTT()
                => ref SysReg(TT);

            [MethodImpl(Inline)]
            public ref ulong rWW()
                => ref SysReg(WW);

            [MethodImpl(Inline)]
            public ref ulong rXX()
                => ref SysReg(XX);

            [MethodImpl(Inline)]
            public ref ulong rYY()
                => ref SysReg(YY);

            [MethodImpl(Inline)]
            public ref ulong rZZ()
                => ref SysReg(ZZ);
        }
    }
}