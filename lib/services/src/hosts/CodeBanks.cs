//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.IO;

    using System.Runtime.CompilerServices;

    using static core;

    using static Root;

    public class CodeBanks : AppService<CodeBanks>
    {

    }

    public abstract class CodeBank<B> : AppService<B>
        where B : CodeBank<B>,new()
    {
        Index<B> _Blocks;

        ReadOnlySpan<B> Blocks
        {
            [MethodImpl(Inline)]
            get => _Blocks.View;
        }

        protected CodeBank()
        {

        }

        [MethodImpl(Inline)]
        public ref B Block(uint index)
            => ref _Blocks[index];

        protected abstract Index<B> Load();
    }
}
