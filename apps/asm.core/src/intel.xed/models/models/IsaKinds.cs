//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial struct XedModels
    {
        public class IsaKinds : HashSet<IsaKind>
        {
            public static IsaKinds Empty => new();
        }
    }
}