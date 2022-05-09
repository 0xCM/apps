//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CsEmitter : ISeqEmitter<string>
    {
        public static string pad(uint width)
            => new string(Chars.Space, (int)width);

        public static string indent<T>(uint offset, T src)
            => string.Format("{0}{1}", pad(offset), src);

        public static string IndentFormat(uint offset, string pattern, params object[] args)
            => indent(offset, string.Format(pattern, args));

        const string summary = nameof(summary);

        List<string> Dst;

        public CsEmitter()
        {
            Dst = new();
        }

        public void Clear()
        {
            Dst.Clear();
        }

        public string AppendLineComment<T>(uint offset, T src)
        {
            var comment = IndentFormat(offset, "// {0}", src);
            Dst.Add(comment);
            return comment;
        }

        public void AppendSummaryComment(uint offset, params object[] lines)
        {
            Dst.Add(IndentFormat(offset, "/// <{0}>", summary));
            for(var i=0; i<lines.Length; i++)
                Dst.Add(IndentFormat(offset, "/// {0}", skip(lines,i)));
            Dst.Add(IndentFormat(offset, "/// </{0}>", summary));
        }

        public ReadOnlySpan<string> Emit()
            => Dst.ViewDeposited();
    }
}