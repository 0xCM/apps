//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class AppSettings : AppService<AppSettings>
    {
        public static string format<T>(in T src)
        {
            var fields = typeof(T).PublicInstanceFields();
            var count = fields.Length;
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendLineFormat("{0}:{1}",field.Name, field.GetValue(src));
            }
            return dst.Emit();
        }

        public Settings Load(ReadOnlySpan<TextLine> src)
            => Settings.parse(src);

        public Outcome Load<T>(FS.FilePath src, out T dst)
            where T : new()
                => Settings.single(src, out dst);

        public Outcome Save<T>(T src, FS.FilePath dst)
            where T : new()
        {
            using var writer = dst.Writer();
            writer.WriteLine(format(src));
            return true;
        }
    }
}