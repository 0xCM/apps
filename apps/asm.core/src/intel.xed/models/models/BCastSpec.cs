//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : all-state.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct XedModels
    {
        public readonly struct BCastSpec
        {
            [MethodImpl(Inline)]
            public static BCastSpec define(uint5 id, BCastClass @class, text15 symbol, byte src, byte dst)
                => new BCastSpec(id,@class,symbol, src, dst);

            public uint5 Id {get;}

            public BCastClass Class {get;}

            public Ratio<byte> Ratio {get;}

            public text15 Symbol {get;}

            [MethodImpl(Inline)]
            public BCastSpec(uint5 id, BCastClass @class, text15 symbol, byte src, byte dst)
            {
                Id = id;
                Class = @class;
                Symbol = symbol;
                Ratio = (src,dst);
            }

            public static BCastSpec Empty => default;
        }
    }
}