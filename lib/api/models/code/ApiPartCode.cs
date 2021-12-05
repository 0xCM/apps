//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiPartCode
    {
        /// <summary>
        /// The owning part
        /// </summary>
        public readonly PartId Part;

        /// <summary>
        /// The code in the set
        /// </summary>
        public Index<ApiHostBlocks> HostCode {get;}

        [MethodImpl(Inline)]
        public ApiPartCode(PartId part, ApiHostBlocks[] src)
        {
            Part = part;
            HostCode = src;
        }

        public Span<ApiHostBlocks> Edit
        {
            [MethodImpl(Inline)]
            get => HostCode.Edit;
        }

        public ReadOnlySpan<ApiHostBlocks> View
        {
            [MethodImpl(Inline)]
            get => HostCode.View;
        }
    }
}