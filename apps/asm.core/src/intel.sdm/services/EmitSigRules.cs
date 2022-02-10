//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public Outcome EmitSigOps()
        {
            const string RP = "{0,-6} | {1,-16} | {2,-6} | {3,-48} | {4}";
            var result = Outcome.Success;
            var details = LoadImportedOpcodes();
            var count = details.Count;
            var dst = ProjectDb.Subdir("sdm") + FS.file("sdm.sigs.operands", FS.Csv);
            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(string.Format(RP, "SigId", "Mnemonic", "OpSeq", "Sig","OpCode"));

            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var detail = ref details[i];

                result = AsmSigs.parse(detail.Sig, out var sig);
                if(result.Fail)
                    break;

                result = AsmOpCodes.parse(detail.OpCode, out var opcode);
                if(result.Fail)
                    break;

                writer.WriteLine(string.Format(RP, i, sig.Mnemonic, EmptyString, sig, opcode));
                counter++;

                for(byte j=0; j<sig.OpCount; j++, counter++)
                    writer.WriteLine(string.Format(RP, i, sig.Mnemonic, j, sig[j], opcode));
            }

            if(result)
                EmittedFile(emitting,counter);

            return result;
        }

        Outcome EmitSigRules()
        {
            var kinds = AsmSigs.opkinds();
            var dst = text.buffer();
            var mods = Symbols.index<AsmModifierKind>();
            for(var i=0; i<kinds.Length; i++)
            {
                ref readonly var kind = ref skip(kinds,i);
                var ops = AsmSigs.operands(kind);
                for(var j=0; j<ops.Length; j++)
                {
                    ref readonly var op = ref skip(ops,j);
                    var input = op.Format();

                    var q = text.index(input, Chars.LBrace);
                    var modpart = EmptyString;
                    if(q > 0)
                    {
                        q = text.index(input, Chars.Space);
                        modpart = text.trim(text.right(input, q));
                        if(mods.MapExpr(modpart, out var sym))
                            dst.AppendLine(string.Format("{0} -> {1}_{2}", input, text.left(input,q), sym.Kind));
                    }

                    var k = text.index(input, Chars.FSlash);
                    if(k>0)
                    {
                        dst.AppendFormat("{0} -> <", input);
                        var parts = text.trim(text.split(input,Chars.FSlash));
                        for(var m=0; m<parts.Length; m++)
                        {
                            if(m > 0)
                                dst.Append(" | ");

                            ref readonly var part = ref skip(parts,m);

                            if(text.nonempty(modpart))
                                dst.AppendFormat("{0}_{1}", part, modpart);
                            else
                                dst.Append(part);
                        }
                        dst.Append(Chars.Gt);
                        dst.AppendLine();
                    }

                }
            }

            var path = ProjectDb.Subdir("sdm") + FS.file("sdm.sigs.rules", FS.ext("map"));
            var emitting = EmittingFile(path);
            path.Overwrite(dst.Emit());
            EmittedFile(emitting,1);
            return true;
        }
    }
}