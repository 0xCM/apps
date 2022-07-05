//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class Literals
    {
        public static string format(in RuntimeLiteral src)
            => string.Format("{0,-16} | {1,-16} | {2,-12} | {3}", src.Type, src.Name, src.Kind, value(src));

        public static string format<T>(in RuntimeLiteralValue<T> src)
            where T : IEquatable<T>
        {
            var data = src.Data.ToString();
            var content = data switch
            {
                RpOps.WinEol => "<weol>",
                RpOps.LinuxEol => "<leol>",
                RpOps.AsciNull => "<ascinull>",
                _ => data
            };
            return RpOps.ticks(content);
        }

        public static string format<T>(LiteralSeq<T> src)
            where T : IEquatable<T>, IComparable<T>
        {
            var dst = text.buffer();
            var w = core.width<T>();
            var count = src.Count;
            var offset = 0u;
            dst.AppendLine(string.Format("LiteralSeq<{0}> {1} = new ({1}, new {0}[{2}]", typeof(T).Name, src.Name, src.Count));
            dst.AppendLine("{");
            offset +=4;
            for(var i=0; i<count; i++)
                dst.IndentLine(offset, src[i].Format());
            offset -=4;
            dst.IndentLine(offset, "})");
            return dst.Emit();
        }
    }
}