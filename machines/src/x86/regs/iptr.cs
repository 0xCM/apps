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
        public ushort Data;

        [MethodImpl(Inline)]
        public IP(ushort src)
        {
            Data = src;
        }

        public ushort Content
        {
            [MethodImpl(Inline)]
            get => Data;
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
        public uint Data;

        [MethodImpl(Inline)]
        public EIP(uint src)
        {
            Data = src;
        }

        public uint Content
        {
            [MethodImpl(Inline)]
            get => Data;
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
        public ulong Data;

        [MethodImpl(Inline)]
        public RIP(ulong src)
        {
            Data = src;
        }

        public ulong Content
        {
            [MethodImpl(Inline)]
            get => Data;
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