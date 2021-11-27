//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public struct ApiCodePack
    {
        public Index<ApiCodeBlock> Blocks {get;}

        public Index<CliSig> CliSigs {get;}

        public Index<AsmSourceBlock> AsmSources {get;}
    }
}