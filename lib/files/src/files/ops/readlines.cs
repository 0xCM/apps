//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using static Root;
    using static core;


    partial struct FS
    {
        [Op]
        public static Index<TextLine> readlines(FilePath src)
        {
            if(!src.Exists)
                return array<TextLine>();

            var data = @readonly(File.ReadAllLines(src.Name));

            var count = data.Length;
            if(count == 0)
                return array<TextLine>();

            var buffer = alloc<TextLine>(count);
            ref var dst = ref first(buffer);
            for(var i=0u; i<count; i++)
                seek(dst,i) = text.line(i, skip(data,i));
            return buffer;
        }

        public static Index<TextLine> readlines(FS.FilePath src, TextEncodingKind encoding)
        {
            using var reader = src.Reader(encoding);
            var buffer = list<TextLine>();
            var content = reader.ReadLine();
            var number = 1u;
            while(content != null)
            {
                buffer.Add(text.line(number++, content));
                content = reader.ReadLine();
            }

            return buffer.ToArray();
        }

        public static Index<string> readtext(FS.FilePath src, TextEncodingKind encoding)
        {
            using var reader = src.Reader(encoding);
            var buffer = list<string>();
            var content = reader.ReadLine();
            var number = 1u;
            while(content != null)
            {
                buffer.Add(content);
                content = reader.ReadLine();
            }

            return buffer.ToArray();
        }
    }
}