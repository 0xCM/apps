//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.IO.Compression;

    using static Algs;

    public sealed record class Db : ApiSet<Db>
    {
        const string group = "db";

        static AppDb db => AppDb.Service;

        static IDbArchive root => db.DbRoot();

        static Type Host => typeof(Db);

        [Api]
        public static Task<ExecToken> start(ArchiveCmd cmd, WfEmit channel)
        {
            var uri = $"{app}://{group}/{cmd}";
            var running = channel.Running(uri);

            ExecToken run()
            {
                ZipFile.CreateFromDirectory(cmd.Source.Format(), cmd.Target.Format(), CompressionLevel.Fastest, true);
                return channel.Ran(running, uri); 
            }

            return @try(run, e => channel.Completed(running, Host, e));                                                    
        }

        [Api]
        public static Task<ExecToken> archive(FS.RelativePath src, string scope, string name, WfEmit channel)
        {
            var uri = $"{app}://{group}/archive?src={src}&scope={scope}&name={name}";
            var running = channel.Running(uri);

            ExecToken run()
            {
                var input = root.Scoped(src);
                var dst = db.Archive(scope).Path(name,FileKind.Zip);
                var flow = channel.EmittingFile(dst);
                ZipFile.CreateFromDirectory(src.Name, dst.Name, CompressionLevel.Fastest, true);
                var emitted = channel.EmittedBytes(flow,dst.Size);
                return channel.Ran(running, uri); 
            }

            return @try(run, e => channel.Completed(running, typeof(Db), e));                                                    
        }

        [Api]
        public static Task<ExecToken> purge(FS.FolderPath src, FS.RelativePath scope, WfEmit channel)
        {
            var uri = $"{app}://{group}/purge?src={src}&scope={scope}";
            var running = channel.Running(uri);
            var scoped = src + scope;
            var actor = "rmdir";
            var flags = "/s/q";
            var spec = Cmd.cmd($"{actor} {scoped.Format(PathSeparator.BS,true)} {flags}");
            return CmdScripts.start(spec,channel);           
        }
    }
}