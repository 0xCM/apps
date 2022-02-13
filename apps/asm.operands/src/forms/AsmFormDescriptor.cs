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

        public readonly SdmOpCodeDetail Description;

        [MethodImpl(Inline)]
        public AsmFormDescriptor(AsmForm form, SdmOpCodeDetail oc)
        {
            Id = form.Id;
            Form = form;
            Description = oc;
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