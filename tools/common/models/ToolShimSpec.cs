//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct ToolShimSpec
    {
        public Identifier Name;

        public FS.FilePath ToolPath;

        public FS.FilePath TargetPath;

        [MethodImpl(Inline)]
        public ToolShimSpec(string name, FS.FilePath src, FS.FilePath dst)
        {
            Name = name;
            ToolPath = src;
            TargetPath = dst;
        }
    }
}