//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Settings
    {
        [Op]
        public static uint store(in Settings src, StreamWriter dst)
        {
            var settings = src.View;
            var count = (uint)settings.Length;
            if(count == 0)
                return count;

            for(var i = 0; i<count; i++)
            {
                ref readonly var setting = ref skip(settings,i);
                dst.WriteLine(string.Format(RpOps.Setting, setting.Name, setting.Value));
            }
            return count;
        }

        public static void store(ReadOnlySpan<Setting> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            Tables.emit(src,emitter);
            using var writer = dst.Writer(encoding);
            writer.Write(emitter.Emit());
        }

        public static void store<T>(ReadOnlySpan<Setting<T>> src, FS.FilePath dst, TextEncodingKind encoding = TextEncodingKind.Asci)
        {
            var emitter = text.emitter();
            Tables.emit(src,emitter);
            using var writer = dst.Writer(encoding);
            writer.Write(emitter.Emit());
        }
    }
}