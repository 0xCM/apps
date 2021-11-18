//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct DataTypeKind
    {
        ulong Value {get;}

        [MethodImpl(Inline)]
        internal DataTypeKind(ulong value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Value.FormatHex();

        public override string ToString()
            => Format();
    }
}