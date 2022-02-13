//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmFormDescriptor
    {
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

        readonly AsmForm Form;

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
    }
}