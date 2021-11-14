//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static SdmModels;

    using SQ = SymbolicQuery;

    public readonly struct SdmOpCodes
    {
        [Op]
        public static string format(in SdmOpCode src)
        {
            const string OcPattern0 = "opcode({0}) = {1}";
            const string OcPattern1 = "opcode({0}, {1}) = {2}";
            var ops = operands(src);
            if(ops.Length == 0)
                return string.Format(OcPattern0, src.Mnemonic, src.Expr);
            else
                return string.Format(OcPattern1, src.Mnemonic, text.join(", ", ops), src.Expr);
        }

        public static Index<SdmOpCode> summarize(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<SdmOpCode>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                opcode(skip(src,i), out seek(dst,i));
            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static ref SdmOpCode opcode(in SdmOpCodeDetail src, out SdmOpCode dst)
        {
            dst.OpCodeKey = src.OpCodeKey;
            dst.Mnemonic = src.Mnemonic;
            operands(src, out dst.Operands);
            dst.Expr = src.OpCode;
            return ref dst;
        }

        [MethodImpl(Inline), Op]
        public static bool operands(in SdmOpCodeDetail src, out CharBlock64 dst)
        {
            var result = false;
            dst = CharBlock64.Null;
            var sig = src.Sig.String;
            var i = SQ.index(sig, Chars.Space);
            if(i >=0)
            {
                dst = SQ.right(sig,i).Trim();
                result = true;
            }
            return result;
        }

        public static ReadOnlySpan<string> operands(in SdmOpCode src)
            => text.split(src.Operands.Format(), Chars.Comma).Select(op => op.Trim());

        [Op]
        public static Index<AsmForm> forms(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmForm>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
            {
                ref readonly var record = ref skip(src,i);
                ref var oc = ref opcode(record, out _);
                ref var current = ref seek(dst,i);
                current = asm.form(
                    asm.sig(oc.Mnemonic.Format(), operands(oc)),
                    asm.opcode(oc.OpCodeKey, oc.Expr)
                    );
            }
            return buffer;
        }

        public static Index<TableColumn> columns(ReadOnlySpan<string> src)
            => Tables.columns<SdmColumnKind>(src);

    }
}