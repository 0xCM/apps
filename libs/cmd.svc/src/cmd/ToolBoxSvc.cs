//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Spans;

    public class ToolRegistry : Seq<ToolRegistry,ToolRegistration>
    {


    }

    public struct ToolRegistration
    {
        public Name ToolName;

        public Name ToolEnv;

        public AsciBlock128 Location;

        [MethodImpl(Inline)]
        public ToolRegistration(Name name, Name env)
        {
            ToolName = name;
            ToolEnv = env;
        }
    }

    public class ToolBoxSvc : WfSvc<ToolBoxSvc>
    {
        public IToolWs Home(Tool tool)
            => new ToolWs(ToolBase.Sources(tool.Name).Root);

        public IDbArchive ToolBase
            => AppDb.Toolbase();

        public static SettingLookup env(FS.FilePath src)
            => Settings.load(src,Chars.Eq);

        public static SettingLookup config(FS.FilePath src)
            => Settings.load(src,Chars.Colon);

        // public SettingLookup LoadEnv(Tool tool)
        // {
        //     var home = Home(tool);
        //     //var path = home.Home. FS.file("tools", FileKind.Env);
        //     return Settings.parse(path.ReadNumberedLines(), Chars.Colon);
        // }

    }
}