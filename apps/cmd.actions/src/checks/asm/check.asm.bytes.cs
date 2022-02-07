//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static Asm.AsmBytes;
    using static Asm.AsmRegOps;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/bytes")]
        Outcome CheckAsmBytes(CmdArgs args)
        {
            var hex = AsmHexCode.Empty;
            var dst = AsmHexWriter.create(hex.Bytes);
            hex.Size = and(al, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(cl, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(dl, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(ah, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(ch, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(dh, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(bh, bl, dst);
            Write(string.Format("{0} | {1}", hex.Format(), hex.BitString));
            dst.Clear();


            Write(string.Format("{0} | {1} | {2} | {3}", ah, ch, dh, bh));
            return true;
        }
    }
}