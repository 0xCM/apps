//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    public readonly struct AsmFormDescriptor
    {
        public static Index<AsmFormDescriptor> unmodify(ReadOnlySpan<AsmFormDescriptor> src)
        {
            var count = src.Length;
            var buffer = alloc<AsmFormDescriptor>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(AsmSigs.modified(form.Sig))
                    dst = new AsmFormDescriptor(AsmForm.define(AsmSigs.unmodify(form.Sig), form.OpCode), form.OcDetail);
                else
                    dst = form;
            }
            return buffer;
        }

        static AsmBitModeKind mode(in SdmOpCodeDetail src)
        {
            var mode = AsmBitModeKind.None;
            if(src.Mode32.Format().Trim() == "Valid")
                mode |= AsmBitModeKind.Mode32;
            if(src.Mode64.Format().Trim() == "Valid")
                mode |= AsmBitModeKind.Mode64;
            return mode;
        }

        public readonly Hex32 Id;

        public readonly AsmForm Form;

        internal readonly SdmOpCodeDetail OcDetail;

        public readonly AsmBitModeKind Mode;

        public readonly TextBlock Description;

        [MethodImpl(Inline)]
        public AsmFormDescriptor(AsmForm form, SdmOpCodeDetail oc)
        {
            Id = form.Id;
            Form = form;
            OcDetail = oc;
            Mode = mode(oc);
            Description = oc.Description.Format().Trim();
        }

        public text47 Name
        {
            [MethodImpl(Inline)]
            get => Form.Name;
        }

        public AsmSig Sig
        {
            [MethodImpl(Inline)]
            get => Form.Sig;
        }

        public AsmOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => Form.OpCode;
        }

        public AsmMnemonic Mnemonic
        {
            [MethodImpl(Inline)]
            get => Form.Mnemonic;
        }

        [MethodImpl(Inline)]
        public AsmFormDescriptor WithName(in text47 name)
            => new AsmFormDescriptor(Form.WithName(name), OcDetail);
    }
}