//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmDataProvider
    {
        public Index<string> SelectConfiguredListNames()
        {
            var src = LlvmPaths.Settings("ListEmissions", FS.List);
            var lines = src.ReadLines();
            return lines.Select(x => x.Trim()).Where(x => nonempty(x));
        }
    }
}