//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/range")]
        Outcome CheckRange(CmdArgs args)
        {
            var dst = text.buffer();
            Render(new BitRange(0, 2),dst);
            Write(dst.Emit());
            Render(new BitRange(3, 5),dst);
            Write(dst.Emit());
            Render(new BitRange(6, 7),dst);
            Write(dst.Emit());


            // Write(a.Format());
            // var b = new BitRange(3, 5);
            // Write(b.Format());
            // var c = new BitRange(6, 7);
            // Write(c.Format());

            return true;
        }

        void Render(BitRange src, ITextBuffer dst)
        {
            var values = span<byte>(256);
            var count = src.Values(values,true);
            dst.Append(src.Format());
            dst.Append(Chars.LBrace);
            for(var i=0;i<count; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Comma);
                dst.Append(skip(values,i).ToString());
            }
            dst.Append(Chars.RBrace);

        }

    }
}