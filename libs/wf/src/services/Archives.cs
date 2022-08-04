//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Archives : WfSvc<Archives>
    {
        public static IDbArchive Service() => _Service;

        static IDbArchive _Service = archive(FS.dir(AppSettings.Service().Find(SettingNames.DbRoot)));

        public static CmdProcess robocopy(FS.FolderPath src, FS.FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            var cmd = Cmd.cmd(spec);
            return Cmd.process(cmd);
        }

        public static IDbArchive archive(FS.FolderPath root)
            => new DbArchive(root);
    }
}