//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86.Regs
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using Asm;

    using api = Asm.AsmRegs;

    public struct IP : IReg16<IP,ushort>
    {
        public ushort Content;

        [MethodImpl(Inline)]
        public IP(ushort src)
        {
            Content = src;
        }

        public RegKind RegKind
        {
            [MethodImpl(Inline)]
            get => RegKind.IP;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => api.index(RegKind);
        }
    }

    public struct EIP : IReg32<EIP,uint>
    {
        public uint Content;

        [MethodImpl(Inline)]
        public EIP(uint src)
        {
            Content = src;
        }

        public RegKind RegKind
        {
            [MethodImpl(Inline)]
            get => RegKind.EIP;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => api.index(RegKind);
        }
    }

    public struct RIP : IReg64<RIP,ulong>
    {
        public ulong Content;

        [MethodImpl(Inline)]
        public RIP(ulong src)
        {
            Content = src;
        }

        public RegKind RegKind
        {
            [MethodImpl(Inline)]
            get => RegKind.RIP;
        }

        public RegIndexCode Index
        {
            [MethodImpl(Inline)]
            get => api.index(RegKind);
        }
    }
}