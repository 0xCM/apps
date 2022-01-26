//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [ApiHost]
    public class AsmVars : AppService<AsmVars>
    {
        AsmRegSets RegSets => Service(Wf.AsmRegSets);

        [MethodImpl(Inline), Op]
        public static RegVar reg(VarSymbol name)
            => new RegVar(name);

        [MethodImpl(Inline), Op]
        public static RegVar reg(VarSymbol name, RegOp value)
            => new RegVar(name, value);

        [MethodImpl(Inline), Op]
        public static MemVar mem(VarSymbol name)
            => new MemVar(name);

        [MethodImpl(Inline), Op]
        public static MemVar mem(VarSymbol name, MemOp value)
            => new MemVar(name,value);

        [MethodImpl(Inline), Op]
        public static ImmVar imm(VarSymbol name)
            => new ImmVar(name);

        [MethodImpl(Inline), Op]
        public static ImmVar imm(VarSymbol name, Imm value)
            => new ImmVar(name, value);
    }
}