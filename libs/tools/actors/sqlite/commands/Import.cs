//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Sqlite
    {
        public struct Import
        {
            public static Command command(FS.FilePath src)
                => string.Format(".import {0} {1}", src.Format(PathSeparator.FS), identifier(null, src.FileName));

            public static Index<Command> commands(FS.Files src)
            {
                var count = src.Length;
                var buffer = alloc<Command>(count);
                if(count != 0)
                {
                    ref var dst = ref first(buffer);
                    var view = src.View;
                    for(var i=0; i<count; i++)
                        seek(dst,i) = command(skip(view,i));
                }
                return buffer;
            }

            public FS.FilePath Source;

            public TableId Target;

            [MethodImpl(Inline)]
            public Import(FS.FilePath src, TableId dst)
            {
                Source = src;
                Target = dst;
            }

            public string Format()
                => string.Format(".import {0} {1}", Source.Format(PathSeparator.FS), Target);

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator Command(Import src)
                => src.Format();
        }

    }
}