//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    public readonly struct SdmFormDescriptor
    {
        public static Index<SdmFormDescriptor> unmodify(ReadOnlySpan<SdmFormDescriptor> src)
        {
            var count = src.Length;
            var buffer = alloc<SdmFormDescriptor>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref skip(src,i);
                ref var dst = ref seek(buffer,i);
                if(AsmSigs.modified(form.Sig))
                    dst = new SdmFormDescriptor(SdmForm.define(AsmSigs.unmodify(form.Sig), form.OpCode), form.OcDetail);
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

        public readonly SdmForm Form;

        internal readonly SdmOpCodeDetail OcDetail;

        public readonly AsmBitModeKind Mode;

        public readonly TextBlock Description;

        [MethodImpl(Inline)]
        public SdmFormDescriptor(SdmForm form, SdmOpCodeDetail oc)
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

        public SdmOpCode OpCode
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
        public SdmFormDescriptor WithName(in text47 name)
            => new SdmFormDescriptor(Form.WithName(name), OcDetail);
    }
}