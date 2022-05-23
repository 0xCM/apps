//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    public class LlvmQuery : AppService<LlvmQuery>
    {
        LlvmPaths LlvmPaths => Service(Wf.LlvmPaths);

        AppServices AppSvc => Service(Wf.AppServices);

        public uint FileEmit<T>(string name, ReadOnlySpan<T> src)
            => EmitFile(name, string.Empty, src);

        public uint EmitFile<T>(string name, string args, ReadOnlySpan<T> src)
        {
            var count = (uint)src.Length;
            var file = FS.file(text.replace(name, Chars.FSlash, Chars.Dot) + tag(args), FS.Txt);
            var dst = LlvmPaths.QueryResult(file);
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
                => AppSvc.TableEmit(src, LlvmPaths.QueryTable<T>(FS.file(name, FS.Csv)));
    }
}