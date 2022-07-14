//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Settings
    {
        [MethodImpl(Inline)]
        public static string format<K,V>(K key, V value)
            => string.Format(RP.Setting, key, value);

        public static string format(Index<Setting> src, char sep)
        {
            var dst = text.buffer();
            iter(src, x => dst.AppendLine(x.Format(sep)));
            return dst.Emit();
        }

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

        public static void render(Settings src, ITextEmitter dst)
        {
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i]);
        }
    }
}