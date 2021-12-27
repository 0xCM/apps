//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Lang
{
    partial struct lang
    {
        internal static string format<K>(in Alphabet<K> src)
            where K : unmanaged
        {
            var dst = text.buffer();
            var count = src.MemberCount;
            dst.AppendFormat("{0}:{{", src.Name);
            for(var i=0; i<count; i++)
                dst.Append(src[i].ToString());
            dst.Append("}");
            return dst.Emit();
        }
    }
}