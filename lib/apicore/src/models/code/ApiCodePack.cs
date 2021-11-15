//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    public struct ApiCodePack
    {
        public Index<ApiCodeBlock> Blocks {get;}

        public Index<CliSig> CliSigs {get;}

        public Index<AsmSourceBlock> AsmSources {get;}
    }
}