//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmFormDescriptor
    {
        public readonly Hex32 Id;

        readonly AsmForm Form;

        internal readonly SdmOpCodeDetail OcDetail;

        [MethodImpl(Inline)]
        public AsmFormDescriptor(AsmForm form, SdmOpCodeDetail oc)
        {
            Id = form.Id;
            Form = form;
            OcDetail = oc;
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

        public string Description
            => OcDetail.Description.Format().Trim();

    }
}