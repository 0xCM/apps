//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;

    using static Root;
    using static minicore;

    public sealed class TextEmitter : TextWriter, ITextWriter
    {
        public static TextWriter cover(TextWriter src)
            => new TextEmitter(src,false);

        public static TextWriter own(TextWriter src)
            => new TextEmitter(src,true);

        readonly TextWriter Target;

        readonly bool Owns;

        TextEmitter(TextWriter dst, bool owns)
        {
            Target = dst;
            Owns = owns;
        }

        void IDisposable.Dispose()
        {
            if(Owns)
                Target.Dispose();
        }

        public override Encoding Encoding
            => Target.Encoding;

        public override IFormatProvider FormatProvider
            => Target.FormatProvider;

        public override string NewLine
            => Target.NewLine;

        public override void Close()
            => Target.Close();

        public override void Flush()
            => Target.Flush();

        public override void Write(bool value)
            => Target.Write(value);

        public override void Write(char value)
            => Target.Write(value);

        public override void Write(char[]? buffer)
            => Target.Write(buffer);

        public override void Write(char[] buffer, int index, int count)
            => Target.Write(buffer, index, count);

        public override void Write(decimal value)
            => Target.Write(value);

        public override void Write(double value)
            => Target.Write(value);

        public override void Write(int value)
            => Target.Write(value);

        public override void Write(long value)
            => Target.Write(value);

        public override void Write(object? value)
            => Target.Write(value);

        public override void Write(ReadOnlySpan<char> buffer)
            => Target.Write(buffer);

        public override void Write(float value)
            => Target.Write(value);

        public override void Write(string? value)
            => Target.Write(value);

        public override void Write(string format, object? arg0)
            => Target.Write(format, arg0);

        public override void Write(string format, object? arg0, object? arg1)
            => Target.Write(format, arg0, arg1);

        public override void Write(string format, object? arg0, object? arg1, object? arg2)
            => Target.Write(format, arg0, arg1, arg2);

        public override void Write(string format, params object?[] arg)
            => Target.Write(format, arg);

        public override void Write(StringBuilder? value)
            => Target.Write(value);

        public void Write(ITextBuffer src, bool reset = true)
            => Target.Write(src.Emit(reset));

        public override void Write(uint value)
            => Target.Write(value);

        public override void Write(ulong value)
            => Target.Write(value);

        public override Task WriteAsync(char value)
            => Target.WriteAsync(value);

        public void AppendLine()
            => Target.WriteLine();

        public void Append(ReadOnlySpan<char> src)
            => Target.Write(src);

        public void Append(char[] src)
            => Target.Write(src);

        public void AppendFormat(string pattern, params object[] args)
            => Target.Write(string.Format(pattern, args));

        public void Append(char c)
            => Target.Write(c);

        public void AppendLine(string src)
            => Target.WriteLine(src);

        public void AppendLine<T>(T src)
            => Target.WriteLine(src?.ToString() ?? RP.Null);

        public void AppendLineFormat(string pattern, params object[] src)
            => Target.WriteLine(string.Format(pattern, src));

        public void IndentLine<T>(uint margin, T src)
            => Target.WriteLine(string.Format("{0}{1}", new string(Chars.Space, (int)margin), src));

        public void IndentLineFormat(uint margin, string pattern, params object[] args)
            => IndentLine(margin, string.Format(pattern, args));

        public void AppendItem<T>(T src)
            => Target.Write(src?.ToString() ?? RP.Null);

        public void Delimit(string delimiter, params object[] src)
        {
            var count = src.Length;
            var terms = @readonly(src);
            var sep = string.Format("{0} ", delimiter);
            for(var i=0; i<src.Length; i++)
                Target.Write(string.Format("{0}{1}", sep, skip(terms,i)));
        }

        public void AppendPadded<T,W>(T value, W width, string delimiter = EmptyString)
        {
            if(nonempty(delimiter))
                Target.Write(delimiter);
            Target.Write(string.Format(RP.pad(-i16(width)), value));
        }

        public void Delimit<T>(T content, char delimiter, int pad)
        {
            Target.Write(RP.rspace(delimiter));
            Target.Write($"{content}".PadRight((int)pad));
        }

        public void Delimit<F,T>(F label, T content, int pad = 0, char delimiter = '|')
        {
            Target.Write(RP.rspace(delimiter));
            Target.Write(string.Format(RP.pad(pad), label));
            Target.Write(content?.ToString() ?? RP.Null);
        }

        public void Append(string src)
            => Target.Write(src);
    }
}