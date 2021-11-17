//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    public abstract class IntegerType<T> : ScalarType<T>
        where T : IntegerType<T>, new()
    {
        protected IntegerType(BitWidth storage, BitWidth content, bool signed)
            : base(storage,content)
        {
            Signed = signed;
        }

        public bool Signed {get;}
    }
}