//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static Sqlite;

    public readonly struct SqliteCommands
    {
        public struct Import
        {
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