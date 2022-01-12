//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;


    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemoryString<T> : IMemoryString<T>
        where T : unmanaged
    {
        public MemoryAddress Address {get;}

        public int Length {get;}

        [MethodImpl(Inline)]
        public MemoryString(MemoryAddress address, int length)
        {
            Address = address;
            Length = length;
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => (uint)Length*size<T>();
        }

        public ReadOnlySpan<T> Cells
        {
            [MethodImpl(Inline)]
            get => cover<T>(Address, (uint)Length);
        }

        public ReadOnlySpan<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => cover<byte>(Address, Size);
        }

        public string Format(IStringFormatter formatter)
            => formatter.Format(Bytes);
    }
}