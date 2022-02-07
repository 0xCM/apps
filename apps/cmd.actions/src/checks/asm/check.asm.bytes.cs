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
            var expr = EmptyString;
            hex.Size = and(al, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(al), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(cl, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(cl), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(dl, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(dl), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(ah, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(ah), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(ch, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(ch), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(dh, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(dh), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();

            hex.Size = and(bh, bl, dst);
            expr = string.Format("{0} {1}, {2}", AsmMnemonicNames.and, nameof(bh), nameof(bl));
            Write(string.Format("{0} | {1} | {2}", expr, hex.Format(), hex.BitString));
            dst.Clear();


            Write(string.Format("{0} | {1} | {2} | {3}", ah.Index, ch.Index, dh.Index, bh.Index));
            return true;
        }
    }
}