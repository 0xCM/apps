//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class SettingIndex
    {
        [MethodImpl(Inline)]
        public static string format<K,V>(K key, V value)
            => string.Format(RP.Setting, key, value);


        public static void render(SettingIndex src, ITextEmitter dst)
        {
            for(var i=0; i<src.Count; i++)
                dst.AppendLine(src[i]);
        }
    }
}