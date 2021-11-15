//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Collections.Generic;

    partial struct XedModels
    {
        public class IsaKinds : HashSet<IsaKind>
        {
            public static IsaKinds Empty => new();
        }
    }
}