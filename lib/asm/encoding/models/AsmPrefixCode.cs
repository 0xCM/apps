//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a prefix encoding
    /// [Kind[24,27] | Encoding]
    /// </summary>
    public struct AsmPrefixCode
    {
        public AsmPrefixKind Kind {get;}

        uint _Value;

        [MethodImpl(Inline)]
        public AsmPrefixCode(AsmPrefixKind kind, uint value)
        {
            Kind = kind;
            _Value = value;
        }

        [MethodImpl(Inline)]
        public uint Value()
            => _Value;
    }
}