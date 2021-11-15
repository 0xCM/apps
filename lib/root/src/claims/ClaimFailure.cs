//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Describes a claim failure
    /// </summary>
    public readonly struct ClaimFailure
    {
        public ClaimKind Claim {get;}

        public TextBlock Description {get;}

        [MethodImpl(Inline)]
        public ClaimFailure(ClaimKind kind, TextBlock description)
        {
            Claim = kind;
            Description = description;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Description.Format();

        public override string ToString()
            => Format();
    }
}