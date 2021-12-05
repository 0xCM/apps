//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a grouping construct for relating non-generic operations
    /// </summary>
    public readonly struct ApiGroupNG
    {
        /// <summary>
        /// The group identity
        /// </summary>
        public OpIdentity GroupId {get;}

        /// <summary>
        /// The delcaring host
        /// </summary>
        public IApiHost Host {get;}

        /// <summary>
        /// The grouped operations
        /// </summary>
        public Index<ApiMethodNG> Members {get;}

        [MethodImpl(Inline)]
        public ApiGroupNG(OpIdentity group, IApiHost host, IEnumerable<ApiMethodNG> members)
        {
            GroupId = group;
            Host = host;
            Members = members.ToArray();
        }

        public bool IsEmpty
            => Members.IsEmpty;

        public override string ToString()
            => GroupId;
    }
}