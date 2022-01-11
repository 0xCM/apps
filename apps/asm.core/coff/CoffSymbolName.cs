//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct CoffSymbolName
    {
        readonly ulong Data;

        [MethodImpl(Inline)]
        public CoffSymbolName(ulong data)
        {
            Data = data;
        }

        public bool IsAddress
        {
            [MethodImpl(Inline)]
            get => (uint)Data == 0;
        }

        public bool IsString
        {
            [MethodImpl(Inline)]
            get => !IsAddress;
        }

        public asci8 String
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public Address32 Address
        {
            [MethodImpl(Inline)]
            get => (uint)(Data >> 32);
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public string Format()
            => IsAddress ? Address.FormatTrimmed(prespec:true) : String;

        public override string ToString()
            => Format();

        public static CoffSymbolName Empty => default;
    }
}