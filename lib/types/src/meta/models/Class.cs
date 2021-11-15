//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Types
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Class
    {
        public uint Ordinal {get;}

        public Label ClassName {get;}

        public Label KindName {get;}

        public Label Symbol {get;}

        public ulong Value {get;}

        [MethodImpl(Inline)]
        public Class(uint ordinal, Label @class, Label kind, Label symbol, ulong value)
        {
            Ordinal = ordinal;
            ClassName = @class;
            KindName = kind;
            Symbol = symbol;
            Value = value;
        }
    }
}