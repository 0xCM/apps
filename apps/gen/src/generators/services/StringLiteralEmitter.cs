//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static core;

    public class StringLiteralEmitter : AppService<StringLiteralEmitter>
    {
        public void Emit(string name, ReadOnlySpan<char> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.Write(delcaration(name));
            begin(writer);
            write(writer,src);
            end(writer);

            EmittedFile(emitting, 1);
        }

        static void begin(StreamWriter writer)
            => writer.Write('\"');

        static void end(StreamWriter writer)
            => writer.WriteLine("\";");

        static string delcaration(string name)
            => string.Format("public const string {0} = ", name);

        static void write(StreamWriter writer, ReadOnlySpan<char> src)
        {
            var i=0;
            var count = src.Length;
            while(i++<count)
                write(writer,skip(src,i));
        }

        static void write(StreamWriter writer, char c)
        {
            if(c == 0)
            {
                writer.Write('\\');
                writer.Write('0');
            }
            else
                writer.Write((char)c);
        }

        public void Emit(string name, ReadOnlySpan<string> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.Write(delcaration(name));
            var count = src.Length;
            begin(writer);
            for(var i=0; i<count; i++)
            {
                var s = span(skip(src,i));
                for(var j=0; j<s.Length; j++)
                    writer.Write(skip(s,j));
            }
            end(writer);

            EmittedFile(emitting, count);
        }
    }
}