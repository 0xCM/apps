//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct SdmModels
    {
        public readonly struct ModeSupport
        {
            public Mode64Support Mode64 {get;}

            public Mode32Support Mode32 {get;}

            [MethodImpl(Inline)]
            public ModeSupport(Mode64Support m64, Mode32Support m32)
            {
                Mode64 = m64;
                Mode32 = m32;
            }
        }
    }
}