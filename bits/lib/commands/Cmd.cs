//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Concurrent;

    using static Root;
    using static core;

    [ApiHost]
    public readonly partial struct Cmd
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static void assign(string name, Action handler)
        {
            if(!_Lookup.TryAdd(name, handler))
                @throw(string.Format("{0}:Unable to include {1}", nameof(Cmd), name));
        }

        public static CmdExec<K> assign<K>(K kind, Action handler)
            where K : unmanaged
        {
            CmdExec<K> cmd = (kind, new CmdExec(kind.ToString()));
            assign(cmd.Enclosed.WorkflowName, handler);
            return cmd;
        }

        public static bool find(CmdExec cmd, out Action handler)
            => _Lookup.TryGetValue(cmd.WorkflowName, out handler);

        [Op]
        public static bool find(Name name, out CmdExec cmd)
        {
            if(_Lookup.ContainsKey(name))
            {
                cmd = name;
                return true;
            }
            else
            {
                cmd = CmdExec.Empty;
                return false;
            }
        }

        public static bool find<K>(K kind, out CmdExec<K> cmd)
            where K : unmanaged
        {
            if(find(kind.ToString(), out var c))
            {
                cmd = (kind,c);
                return true;
            }
            else
            {
                cmd = (kind, CmdExec.Empty);
                return false;
            }
        }

        static ConcurrentDictionary<string,Action> _Lookup = new ConcurrentDictionary<string, Action>();
    }
}