//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Regs;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential)]
    public struct CpuId : ITextual
    {
        [Op]
        public static string format(in CpuId src)
        {
            const string FormatPattern = "fx:{0} subfx:{1} => eax:{2} ebx:{3} ecx:{4} edx:{5}";
            return text.format(FormatPattern, src.Fx, src.SubFx, src.Eax, src.Ebx, src.Ecx, src.Edx);
        }

        public eax Fx;

        public ecx SubFx;

        public eax Eax;

        public ebx Ebx;

        public ecx Ecx;

        public edx Edx;

        public void Clear()
            => clear(ref this);

        [MethodImpl(Inline)]
        public CpuId WithRequest(eax fx, ecx subfx)
        {
            Fx = fx;
            SubFx = subfx;
            return this;
        }

        [MethodImpl(Inline)]
        public CpuId WithResponse(in Cell128 src)
            => response(src, ref this);

        public string Format()
            => format(this);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static ref CpuId clear(ref CpuId target)
        {
            core.@as<CpuId,ByteBlock24>(target) = ByteBlocks.alloc(n24);
            return ref target;
        }

        [MethodImpl(Inline)]
        public static CpuId request(eax fx, ecx subfx)
        {
            var cpuid = new CpuId();
            cpuid.Fx = fx;
            cpuid.SubFx = subfx;
            return cpuid;
        }

        [MethodImpl(Inline)]
        public static ref CpuId response(in Cell128 src, ref CpuId dst)
        {
            ref var target = ref seek64(@byte(dst),1);
            @as<Cell128>(target) = src;
            return ref dst;
        }
    }
}