//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    public sealed class HexCharTest : PredicateOp<char>
    {
        public HexCharTest()
            : base(nameof(Hex.test))
        {

        }

        public override bool Invoke(char src)
            => Hex.test(src);
    }

    public abstract class HexCharConverter<T>
    {

    }

}