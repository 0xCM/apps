//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    sealed class AppCmd : AppCmdService<AppCmd>
    {
        [CmdOp("bitmasks/check")]
        void Hello()
        {
            var src = BitMask.masks(typeof(BitMaskLiterals));
            var formatter = Tables.formatter<BitMaskLiterals>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var mask = ref src[i];
                Write(formatter.Format(mask));
                Write(mask.Text);
            }
        }
    }
}