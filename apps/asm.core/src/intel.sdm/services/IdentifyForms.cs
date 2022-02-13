//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        ConstLookup<Identifier,AsmForm> IdentifyForms(ReadOnlySpan<AsmForm> forms)
        {
            var count = forms.Length;
            var lookup = dict<Identifier,AsmForm>();
            for(var i=0u; i<count; i++)
            {
                ref readonly var form = ref skip(forms,i);
                ref readonly var sig = ref form.Sig;
                ref readonly var opcode = ref form.OpCode;
                var name = AsmSigs.identify(sig);
                var rex = AsmOpCodes.rex(opcode);
                var vex = AsmOpCodes.vex(opcode);
                var evex = AsmOpCodes.evex(opcode);
                if(lookup.TryGetValue(name, out var prior))
                {
                    if(rex)
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

                lookup.TryAdd(name,form);
            }

            return lookup;
        }

        ConstLookup<Identifier,AsmFormDescriptor> IdentifyForms(ReadOnlySpan<AsmFormDescriptor> forms)
        {
            var count = forms.Length;
            var lookup = dict<Identifier,AsmFormDescriptor>();
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
                    if(rex)
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

                if(name.IsNonEmpty)
                    lookup.TryAdd(name,form);
            }

            return lookup;
        }

    }
}