//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct JccInfo<K>
        where K : unmanaged
    {
        public readonly K Kind;

        public readonly text7 Name;

        public readonly NativeSize Size;

        [MethodImpl(Inline)]
        public JccInfo(K kind, text7 name, NativeSize size)
        {
            Name = name;
            Size = size;
            Kind = kind;
        }

        public byte Encoding
        {
            [MethodImpl(Inline)]
            get => u8(Kind);
        }
    }
}