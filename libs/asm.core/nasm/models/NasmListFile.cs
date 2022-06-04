//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct NasmListFile : IFile
    {
        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public NasmListFile(FS.FilePath target)
        {
            Path = target;
        }

        [MethodImpl(Inline)]
        public static implicit operator NasmListFile(FS.FilePath src)
            => new NasmListFile(src);
    }
}