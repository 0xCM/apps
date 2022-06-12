//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmQuery : WfSvc<LlvmQuery>
    {
        new LlvmPaths Paths => Service(Wf.LlvmPaths);

        public void Emit(FS.Files src, string name)
            => FileEmit(name, @readonly(src.View.Map(x => x.ToUri())));

        public uint FileEmit<T>(string name, ReadOnlySpan<T> src)
            => FileEmit(name, string.Empty, src);

        public void FileEmit(string src, string name, FS.FileExt ext)
            => FileEmit(src, 0, Paths.QueryOut().Path(FS.file(name, ext)));

        public uint FileEmit<T>(string name, string args, ReadOnlySpan<T> src)
        {
            var count = (uint)src.Length;
            var file = FS.file(text.replace(name, Chars.FSlash, Chars.Dot) + tag(args), FS.Txt);
            var dst = Paths.QueryOut(file);
            var emitting = EmittingFile(dst);
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
                writer.WriteLine(skip(src,i));
            EmittedFile(emitting,count);
            return count;
        }

        static string tag(string args)
            => text.empty(args) ? string.Empty : "-" + args;

        public void TableEmit<T>(string name, ReadOnlySpan<T> src)
            where T : struct
                => TableEmit(src, Paths.DbTable(name));
    }
}