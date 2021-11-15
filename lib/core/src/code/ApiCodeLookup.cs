//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    public class ApiCodeLookup : Dictionary<OpUri,ApiCodeBlock>
    {
        public static ApiCodeLookup Empty => new ApiCodeLookup();
    }
}