//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct BfOrigin
    {
        public readonly dynamic Value;

        [MethodImpl(Inline)]
        public BfOrigin(dynamic src)
        {
            Value = src;
        }

        public string Format()
            => Value?.ToString();


        public override string ToString()
            => Format();
    }
}