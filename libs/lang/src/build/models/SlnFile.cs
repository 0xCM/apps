//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsBuild
    {
        /// <summary>
        /// Represents a path to a file that defines a solution
        /// </summary>
        public readonly struct SlnFile : IFsEntry<SlnFile>
        {
            public readonly FS.FilePath Path {get;}

            public FS.PathPart Name
            {
                [MethodImpl(Inline)]
                get => Path.Name;
            }

            [MethodImpl(Inline)]
            public SlnFile(FS.FilePath src)
                => Path = src;

            [MethodImpl(Inline)]
            public string Format()
                => Path.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator SlnFile(FS.FilePath src)
                => new SlnFile(src);

            [MethodImpl(Inline)]
            public static implicit operator FS.FilePath(SlnFile src)
                => src.Path;
        }
    }
}