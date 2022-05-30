//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [MethodImpl(Inline), Op]
        public static CmdModifier modifier(string value)
            => value;
    }
}