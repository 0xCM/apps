//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static WsAtoms;
    using static core;

    partial class Tooling
    {
        public static IToolWs configure(IToolWs ws)
        {
            var subdirs = ws.Root.SubDirs();
            var counter = 0u;
            var dst = ws.Inventory();
            var configs = list<ToolConfig>();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var src =  dir + FS.folder(logs) + FS.file(config, FS.Log);
                    if(src.Exists)
                    {
                        var result = parse(src.ReadText(), out ToolConfig c);
                        if(result)
                            configs.Add(c);
                    }
                }
            }
            return ws.Configure(configs.ToArray());
        }
    }
}