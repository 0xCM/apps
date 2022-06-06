//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CsModels
    {
        public struct ShimSpec
        {
            public Identifier Name;

            public FS.FilePath ToolPath;

            public FS.FilePath TargetPath;

            [MethodImpl(Inline)]
            public ShimSpec(string name, FS.FilePath src, FS.FilePath dst)
            {
                Name = name;
                ToolPath = src;
                TargetPath = dst;
            }
        }
    }
}