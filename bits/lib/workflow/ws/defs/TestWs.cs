//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class TestWs : Workspace<TestWs>
    {
        [MethodImpl(Inline)]
        public static TestWs create(FS.FolderPath root)
            => new TestWs(root);

        [MethodImpl(Inline)]
        public TestWs(FS.FolderPath root)
            : base(root)
        {
        }
    }
}
