//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static core;

    public sealed class CmdIndex : Dictionary<ulong,CmdExec>
    {
        public static CmdIndex create()
            => new CmdIndex();

        public CmdExec<K> Include<K>(K kind, CmdExec cmd)
            where K : unmanaged
        {

            this[bw64(kind)] = cmd;
            return (kind, cmd);
        }

        public CmdExec<K> Include<K>(CmdExec<K> cmd)
            where K : unmanaged
        {
            this[bw64(cmd.Kind)] = cmd;
            return cmd;
        }
    }
}