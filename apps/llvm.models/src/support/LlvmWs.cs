//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct LlvmAtoms
    {
        public const string build = nameof(build);

        public const string bin = nameof(bin);

        public const string lib = nameof(lib);
    }

    public sealed class LlvmWs : Workspace<LlvmWs>, ILlvmWorkspace
    {
        [MethodImpl(Inline)]
        public static ILlvmWorkspace create(FS.FolderPath root)
            => new LlvmWs(root);

        [MethodImpl(Inline)]
        LlvmWs(FS.FolderPath root)
            : base(root)
        {
            BuildRoot = root + FS.folder(LlvmAtoms.build);
        }

        public FS.FolderPath BuildRoot {get;}
    }
}