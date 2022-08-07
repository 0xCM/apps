//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class Archives
    {
        public static string identifier(FS.FolderPath src)
            => src.Format(PathSeparator.FS).Replace(Chars.FSlash, Chars.Dot).Replace(Chars.Colon, Chars.Dot).Replace("..", ".");

        public static IDbArchive archive(FS.FolderPath root)
            => new DbArchive(root);

        public static IDbArchive archive(Timestamp ts, IDbArchive dst)
            => dst.Scoped(ts.Format());

        public static FS.FileName timestamped(string name, FS.FileExt ext)
            => FS.file(string.Format("{0}.{1}", name, (Timestamp.now()).Format()),ext);

        [Op]
        public static FS.FilePath timestamped(FS.FilePath src)
        {
            var name = src.FileName.WithoutExtension;
            var ext = src.Ext;
            var stamped = FS.file(string.Format("{0}.{1}.{2}", name, Algs.timestamp(), ext));
            return src.FolderPath + stamped;
        }

        public static IDbArchive Service() => _Service;

        static IDbArchive _Service = archive(FS.dir(AppSettings.Service().Find(SettingNames.DbRoot)));

        public static CmdProcess robocopy(FS.FolderPath src, FS.FolderPath dst)
        {
            var spec = $"robocopy {src} {dst} /e";
            var cmd = Cmd.cmd(spec);
            return Cmd.process(cmd);
        }

        public static Outcome timestamp(FS.FolderPath src, out Timestamp dst)
        {
            dst = Timestamp.Zero;
            if(src.IsEmpty)
                return false;

            var fmt = src.Format(PathSeparator.FS);
            var idx = fmt.LastIndexOf(Chars.FSlash);
            if(idx == NotFound)
                return false;

            var outcome = Time.parse(fmt.RightOfIndex(idx), out var ts);
            if(outcome)
            {
                dst = ts;
                return true;
            }
            else
                return(false,outcome.Message);
        }
    }
}