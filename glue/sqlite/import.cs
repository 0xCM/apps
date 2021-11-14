//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct Sqlite
    {
        partial struct Commands
        {
            public static Command import(FS.FilePath src)
                => string.Format(".import {0} {1}", src.Format(PathSeparator.FS), identifier(null, src.FileName));

            public static Index<Command> import(FS.Files src)
            {
                var count = src.Length;
                var buffer = alloc<Command>(count);
                if(count != 0)
                {
                    ref var dst = ref first(buffer);
                    var view = src.View;
                    for(var i=0; i<count; i++)
                        seek(dst,i) = import(skip(view,i));
                }
                return buffer;
            }
        }
    }
}