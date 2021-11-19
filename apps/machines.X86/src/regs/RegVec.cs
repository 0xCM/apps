//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Asm;

    using static Root;

    public ref struct RegVec
    {
        readonly Span<RegKind> _Kinds;

        readonly Span<byte> _Data;

        [MethodImpl(Inline)]
        internal RegVec(Span<RegKind> kinds, Span<byte> data)
        {
            _Kinds = kinds;
            _Data = data;
        }

        public byte RegCount
        {
            [MethodImpl(Inline)]
            get => (byte)_Kinds.Length;
        }
    }

    public struct RegVec<R0>
        where R0 : unmanaged, IReg
    {
        public R0 r0;

        [MethodImpl(Inline)]
        public RegVec(R0 r0)
        {
            this.r0 = r0;
        }

        [MethodImpl(Inline)]
        public static implicit operator R0(RegVec<R0> src)
            => src.r0;

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0>(R0 src)
            => new RegVec<R0>(src);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RegVec<R0,R1>
        where R0 : unmanaged, IReg
        where R1 : unmanaged, IReg
    {
        public R0 r0;

        public R1 r1;

        [MethodImpl(Inline)]
        public RegVec(R0 r0, R1 r1)
        {
            this.r0 = r0;
            this.r1 = r1;
        }

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0>(RegVec<R0,R1> src)
            => new RegVec<R0>(src.r0);

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0,R1>((R0 r0, R1 r1) src)
            => new RegVec<R0,R1>(src.r0, src.r1);

        [MethodImpl(Inline)]
        public static implicit operator (R0 r0, R1 r1)(RegVec<R0,R1> src)
            => (src.r0, src.r1);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RegVec<R0,R1,R2>
        where R0 : unmanaged, IReg
        where R1 : unmanaged, IReg
        where R2 : unmanaged, IReg
    {
        public R0 r0;

        public R1 r1;

        public R2 r2;

        [MethodImpl(Inline)]
        public RegVec(R0 r0, R1 r1, R2 r2)
        {
            this.r0 = r0;
            this.r1 = r1;
            this.r2 = r2;
        }

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0>(RegVec<R0,R1,R2> src)
            => new RegVec<R0>(src.r0);

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0,R1>(RegVec<R0,R1,R2> src)
            => new RegVec<R0,R1>(src.r0, src.r1);

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0,R1,R2>((R0 r0, R1 r1, R2 r2) src)
            => new RegVec<R0,R1,R2>(src.r0, src.r1, src.r2);

        [MethodImpl(Inline)]
        public static implicit operator (R0 r0, R1 r1, R2 r2)(RegVec<R0,R1,R2> src)
            => (src.r0, src.r1, src.r2);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RegVec<R0,R1,R2,R3>
        where R0 : unmanaged, IReg
        where R1 : unmanaged, IReg
        where R2 : unmanaged, IReg
        where R3 : unmanaged, IReg
    {

        public R0 r0;

        public R1 r1;

        public R2 r2;

        public R3 r3;

        [MethodImpl(Inline)]
        public RegVec(R0 r0, R1 r1, R2 r2, R3 r3)
        {
            this.r0 = r0;
            this.r1 = r1;
            this.r2 = r2;
            this.r3 = r3;
        }

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0>(RegVec<R0,R1,R2,R3> src)
            => new RegVec<R0>(src.r0);

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0,R1>(RegVec<R0,R1,R2,R3> src)
            => new RegVec<R0,R1>(src.r0, src.r1);

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0,R1,R3>(RegVec<R0,R1,R2,R3> src)
            => new RegVec<R0,R1,R3>(src.r0, src.r1,src.r3);

        [MethodImpl(Inline)]
        public static implicit operator RegVec<R0,R1,R2,R3>((R0 r0, R1 r1, R2 r2, R3 r3) src)
            => new RegVec<R0,R1,R2,R3>(src.r0, src.r1, src.r2, src.r3);

        [MethodImpl(Inline)]
        public static implicit operator (R0 r0, R1 r1, R2 r2, R3 r3)(RegVec<R0,R1,R2,R3> src)
            => (src.r0, src.r1, src.r2, src.r3);
    }
}