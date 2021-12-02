//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct OperandVarName
    {
        readonly text31 Data;

        [MethodImpl(Inline)]
        public OperandVarName(string src)
        {
            Data = src;
        }

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator OperandVarName(string src)
            => new OperandVarName(src);
    }

}