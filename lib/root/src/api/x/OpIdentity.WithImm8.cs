//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    partial class XApi
    {
        /// <summary>
        /// Attaches an immediate suffix to an identity, removing an existing immediate suffix if necessary
        /// </summary>
        /// <param name="src">The source identity</param>
        /// <param name="immval">The immediate value to attach</param>
        [Op]
        public static OpIdentity WithImm8(this OpIdentity src, byte immval)
            => ApiUri.opid(string.Concat(src.WithoutImm8().IdentityText, ApiUri.Imm8Suffix(immval)));
    }
}
