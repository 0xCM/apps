//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct Cmd
    {
        [MethodImpl(Inline), Op]
        public static CmdFlag disable(in CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.Off);
    }
}