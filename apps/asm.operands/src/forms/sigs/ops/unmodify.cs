//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static AsmSigTokens;
    using static core;

    partial class AsmSigs
    {
        public static AsmSig unmodify(in AsmSig src)
        {
            var ops = new AsmSigOps();
            for(byte i=0; i<src.OpCount; i++)
                ops[i] = src[i].WithoutModifier();
            return new AsmSig(src.Mnemonic, ops);
        }


        public static Index<AsmSig> unmodify(ReadOnlySpan<AsmSig> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmSig>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var sig = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(AsmSigs.modified(sig))
                    dst = unmodify(sig);
                else
                    dst = sig;
            }
            return buffer;
        }

        public static Index<AsmForm> unmodify(ReadOnlySpan<AsmForm> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmForm>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(AsmSigs.modified(form.Sig))
                    dst = AsmForm.define(unmodify(form.Sig), form.OpCode);
                else
                    dst = form;
            }
            return buffer;
        }

        public static Index<AsmFormDescriptor> unmodify(ReadOnlySpan<AsmFormDescriptor> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmFormDescriptor>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(AsmSigs.modified(form.Sig))
                    dst = new AsmFormDescriptor(AsmForm.define(unmodify(form.Sig), form.OpCode), form.OcDetail);
                else
                    dst = form;
            }
            return buffer;
        }
    }
}