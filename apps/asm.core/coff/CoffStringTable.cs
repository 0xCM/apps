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

    public ref struct CoffStringTable
    {
        readonly ReadOnlySpan<byte> Data;

        [MethodImpl(Inline)]
        public CoffStringTable(ReadOnlySpan<byte> src)
        {
            Data = src;
        }

        public ref readonly uint Size
        {
            [MethodImpl(Inline)]
            get => ref first(recover<uint>(slice(Data,0,4)));
        }

        public ReadOnlySpan<AsciCode> Content
        {
            [MethodImpl(Inline)]
            get => recover<AsciCode>(Data);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<AsciCode> Entry(Address32 offset)
        {
            var src = slice(Data,(uint)offset);
            var max = Content.Length;
            var length = 0u;
            var i=0u;
            while(i < max && (sbyte)skip(src,i++) > 0)
                length++;
            return recover<AsciCode>(slice(src,0,length));
        }

        public string Text(in CoffSymbol sym)
        {
            ref readonly var name = ref sym.Name;
            var value = sym.Value;
            var kind = name.NameKind;
            var address = kind == CoffNameKind.String ? Address32.Zero : name.Address;
            var _symtext = EmptyString;
            if(value < Hex16.Max)
            {
                if(address.IsNonZero)
                    _symtext = Entry(name.Address).Format();
                else
                {
                    if(kind == CoffNameKind.String)
                        _symtext = name.String.Format();
                }
            }
            //var symtext = value > Hex16.Max ? EmptyString : (kind == CoffNameKind.String ? name.String.Format() : Entry(name.Address).Format());
            return _symtext;
        }
    }
}