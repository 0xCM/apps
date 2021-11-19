//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines
{

    using Asm.Operands;

    public interface IAsmMov
    {
        void mov(r8 a, r8 b);

        void mov(r16 a, r16 b);

        void mov(r32 a, r32 b);

        void mov(r64 a, r64 b);
    }
}