//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class WfReactor: CmdReactor<WfReactor,CmdExec,CmdResult>
    {
        static ConcurrentDictionary<string,Action> _Lookup = new ConcurrentDictionary<string, Action>();

        public static CmdResult<ListFilesCmd,FS.Files> exec(ListFilesCmd cmd)
        {
            var _list = DbFiles.search(cmd.SourceDir, cmd.Extensions, cmd.EmissionLimit);
            var outcome = DbFiles.emit(_list, cmd.FileUriMode, cmd.TargetPath);
            return outcome ? CmdResults.ok(cmd,_list) : CmdResults.fail(cmd, outcome.Message);
        }

        [Op]
        public static void assign(string name, Action handler)
        {
            if(!_Lookup.TryAdd(name, handler))
                @throw(string.Format("{0}:Unable to include {1}", "Cmd", name));
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

        protected override CmdResult Run(CmdExec cmd)
        {
            if(find(cmd, out var handler))
            {
                handler();
                return CmdResults.ok(cmd, string.Format("Executed <{0}> workflow", cmd.WorkflowName));
            }
            return CmdResults.fail(cmd, "Handler not found");
        }
    }
}