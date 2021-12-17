//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a reference to an immutable character sequence
    /// </summary>
    public unsafe readonly struct StringRef
    {
        readonly MemoryAddress Base;

        public uint Length {get;}

        [MethodImpl(Inline)]
        public StringRef(MemoryAddress @base, uint length)
        {
            Base = @base;
            Length = length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0 || Base == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0 || Base != 0;
        }

        public ref readonly char this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Base.Ref<char>(), index);
        }

        public ref readonly char this[long index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Base.Ref<char>(), index);
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Length*size<char>();
        }

        public ReadOnlySpan<char> View
        {
            [MethodImpl(Inline)]
            get => cover<char>(Base.Pointer<char>(), Length);
        }

        public string Format()
            => strings.format(this);


        public override string ToString()
            => Format();

        public static StringRef Empty
        {
            [MethodImpl(Inline)]
            get => new StringRef(0,0);
        }
    }
}