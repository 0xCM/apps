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

    [ApiHost]
    public class AsmVars : AppService<AsmVars>
    {
        AsmRegSets RegSets => Service(Wf.AsmRegSets);

        public uint Regs(VarSymbol name, RegClassCode @class, Span<RegVar> dst)
        {
            var src = RegSets.Regs(@class);
            var count = min(src.Count,(uint)dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = reg(name, src[i]);
            return count;
        }

        public uint GpRegs(VarSymbol name, NativeSize size, Span<RegVar> dst)
        {
            var src = RegSets.GpRegs(size);
            var count = (uint)min(src.Count,dst.Length);
            for(var i=0u; i<count; i++)
                seek(dst,i) = reg(name, src[i]);

            return count;
        }

        [MethodImpl(Inline), Op]
        public static ImmVar imm(VarSymbol name)
            => new ImmVar(name);

        [MethodImpl(Inline), Op]
        public static ImmVar imm(VarSymbol name, Imm value)
            => new ImmVar(name,value);

        [MethodImpl(Inline), Op]
        public static RegVar reg(VarSymbol name)
            => new RegVar(name);

        [MethodImpl(Inline), Op]
        public static RegVar reg(VarSymbol name, RegOp value)
            => new RegVar(name,value);

        [MethodImpl(Inline), Op]
        public static DispVar disp(VarSymbol name)
            => new DispVar(name);

        [MethodImpl(Inline), Op]
        public static DispVar disp(VarSymbol name, Disp value)
            => new DispVar(name,value);

        [MethodImpl(Inline), Op]
        public static MemVar mem(VarSymbol name)
            => new MemVar(name);

        [MethodImpl(Inline), Op]
        public static MemVar mem(VarSymbol name, MemOp value)
            => new MemVar(name,value);
    }
}