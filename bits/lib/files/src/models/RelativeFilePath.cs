//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;


    partial struct FS
    {
        public readonly struct RelativeFilePath : IFsEntry<RelativeFilePath>
        {
            public RelativePath Location {get;}


            [MethodImpl(Inline)]
            public RelativeFilePath(RelativePath location)
            {
                Location = location;
            }

            public FileName File
                => file(Path.GetFileName(Location.Format()));

            public PathPart Name
                => Location.Format(PathSeparator.FS);

            public string Format(PathSeparator sep)
                => Name.Format(sep);

            public string Format()
                => Format(PathSeparator.FS);

            public override string ToString()
                => Format();
        }
    }
}