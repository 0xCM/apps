//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static CallRel32 call(Rip rip, Disp32 disp)
            => new CallRel32(rip, AsmRel32.target(rip,disp));
    }
}