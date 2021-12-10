//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using static core;

    public class LlvmData : AppService<LlvmData>
    {
        public static string parent(in DefRelations src)
            => src.Ancestors != null && src.Ancestors.IsNonEmpty ? src.Ancestors.Name : EmptyString;

        public static ReadOnlySpan<string> ancestors(in DefRelations src)
        {
            return src.Ancestors != null && src.Ancestors.IsNonEmpty
                ?  (src.Ancestors.HasAncestor
                        ? Arrays.concat(new string[]{src.Ancestors.Name}, src.Ancestors.Ancestors.Storage)
                        : new string[]{src.Ancestors.Name}
                        )
                : default;
        }

        public LlvmDataProvider DataProvider
            => Service(Wf.LlvmDataProvider);

        public LlvmDataEmitter DataEmitter
            => Service(Wf.LlvmDataEmitter);

        public new LlvmPaths Paths
            => Service(Wf.LlvmPaths);

        public LlvmRepo Repo
            => Service(Wf.LlvmRepo);
    }
}