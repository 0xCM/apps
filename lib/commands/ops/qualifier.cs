//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [MethodImpl(Inline), Factory]
        public static ArgQualifier qualifier(AsciCode src)
            => new ArgQualifier(src);

        [MethodImpl(Inline), Factory]
        public static ArgQualifier qualifier(char src)
            => new ArgQualifier((AsciCode)src);
    }
}