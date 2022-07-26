//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Archives : AppService<Archives>
    {
        public static IDbArchive Service() => _Service;

        static IDbArchive _Service = Archives.archive(FS.dir(AppSettings.Service().Find(SettingNames.DbRoot)));

        public static ScriptProcess robocopy(FS.FolderPath src, FS.FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            var cmd = CmdScripts.cmd(spec);
            return ScriptProcess.create(cmd);
        }

        public static IDbArchive archive(FS.FolderPath root)
            => new DbArchive(root);
    }
}