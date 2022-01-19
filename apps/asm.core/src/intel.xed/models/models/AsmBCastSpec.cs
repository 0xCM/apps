//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmBCastSpec
    {
        [MethodImpl(Inline)]
        public static AsmBCastSpec define(uint5 id, AsmBCastClass @class, text15 symbol, byte src, byte dst)
            => new AsmBCastSpec(id,@class,symbol, src, dst);

        public uint5 Id {get;}

        public AsmBCastClass Class {get;}

        public Ratio<byte> Ratio {get;}

        public text15 Symbol {get;}

        [MethodImpl(Inline)]
        public AsmBCastSpec(uint5 id, AsmBCastClass @class, text15 symbol, byte src, byte dst)
        {
            Id = id;
            Class = @class;
            Symbol = symbol;
            Ratio = (src,dst);
        }

        public static AsmBCastSpec Empty => default;
    }
}