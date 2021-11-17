//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class FixedWidthType<T> : DataType<T>
        where T : FixedWidthType<T>, new()
    {
        public BitWidth StorageWidth {get;}

        public BitWidth ContentWidth {get;}

        public override bool IsFixedWidth => true;

        protected FixedWidthType(BitWidth sw, BitWidth cw)
        {
            StorageWidth = sw;
            ContentWidth = cw;
        }
    }
}