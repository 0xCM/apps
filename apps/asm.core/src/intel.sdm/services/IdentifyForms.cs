//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        AsmFormDescriptors IdentifyForms(ReadOnlySpan<AsmFormDescriptor> forms)
        {
            var count = forms.Length;
            var lookup = dict<string,AsmFormDescriptor>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var form = ref skip(forms,i);
                var sig = form.Sig;
                var opcode = form.OpCode;
                var name = AsmSigs.identify(sig);
                var rex = AsmOpCodes.rex(opcode);
                var vex = AsmOpCodes.vex(opcode);
                var evex = AsmOpCodes.evex(opcode);
                if(lookup.TryGetValue(name, out var prior))
                {
                    if(rex && AsmOpCodes.rex(prior.OpCode))
                    {
                        if(AsmOpCodes.diff(prior.OpCode, opcode, out var token))
                        {
                            if(token.Kind == AsmOcTokenKind.Hex8)
                                name = string.Format("{0}_x{1}", name, token);
                            else
                                name = string.Format("{0}_{1}", name, token);
                        }
                    }

                    else if(rex)
                        name = string.Format("{0}_{1}", name, "rex");
                    else if(vex)
                        name = string.Format("{0}_{1}", name, "vex");
                    else if(evex)
                        name = string.Format("{0}_{1}", name, "evex");
                    else
                    {
                        if(AsmOpCodes.diff(prior.OpCode, opcode, out var token))
                        {
                            if(token.Kind == AsmOcTokenKind.Hex8)
                                name = string.Format("{0}_x{1}", name, token);
                            else
                                name = string.Format("{0}_{1}", name, token);
                        }
                        else
                            name = EmptyString;
                    }
                }

                if(text.nonempty(name))
                {
                    lookup.TryAdd(name,form.WithName(name));
                }
            }

            return lookup;
        }
    }
}