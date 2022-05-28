//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct RuntimeLiteralValue<T>
        where T : IEquatable<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public RuntimeLiteralValue(T src)
        {
            Data = src;
        }

        public string Format()
            => Literals.format(this);

        public override string ToString()
            => Format();
    }
}