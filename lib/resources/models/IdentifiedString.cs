//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public struct IdentifiedString
    {
        public uint Seq;

        public Identifier Name;

        public string Value;

        [MethodImpl(Inline)]
        public IdentifiedString(uint seq, Identifier name, string value)
        {
            Seq = seq;
            Name = name;
            Value = value;
        }
    }
}