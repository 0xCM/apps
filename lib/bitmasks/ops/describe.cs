//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class BitMasks
    {
        [MethodImpl(Inline), Op]
        public static BitMaskInfo describe(NumericLiteral src)
        {
            var dst = new BitMaskInfo();
            return map(src, ref dst);
        }

        [MethodImpl(Inline), Op]
        static ref BitMaskInfo map(in NumericLiteral src, ref BitMaskInfo dst)
        {
            dst.Name = src.Name;
            dst.DataType = TypeSyntax.infer(src.Data?.GetType() ?? typeof(void));
            dst.MaskData = BitMaskData.infer(src.Data);
            dst.Text = src.Text;
            dst.Base = src.Base;
            return ref dst;
        }
    }
}