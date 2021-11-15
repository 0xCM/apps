//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection.Metadata;

    using static Root;

    partial class PeReader
    {
        [MethodImpl(Inline), Op]
        public ref MethodBodyBlock ReadMethodBody(MethodDefinition src, ref MethodBodyBlock dst)
        {
            dst = PE.GetMethodBody(src.RelativeVirtualAddress);
            return ref dst;
        }
    }
}