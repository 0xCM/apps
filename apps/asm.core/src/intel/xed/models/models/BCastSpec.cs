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
            public BCastClass Class {get;}

            public Ratio<byte> Ratio {get;}

            [MethodImpl(Inline)]
            public BCastSpec(BCastClass @class, byte src, byte dst)
            {
                Class = @class;
                Ratio = (src,dst);
            }
        }
    }
}