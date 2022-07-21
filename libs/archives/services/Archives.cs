//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Archives : AppService<Archives>
    {
        public static ScriptProcess robocopy(FS.FolderPath src, FS.FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            var cmd = Scripts.cmd(spec);
            return ScriptProcess.create(cmd);
        }

        public static IDbArchive archive(FS.FolderPath root)
            => new DbArchive(root);
    }
}