//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static core;

    partial class AsmCmdProvider
    {
        [CmdOp("seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = SeqProducts.mul(a,b);
            Write(SeqProducts.format(c));

            return true;
        }

        [CmdOp("asm/sigs/rules")]
        Outcome EmitOpTerminals(CmdArgs args)
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

            var path = ProjectDb.Subdir("sdm") + FS.file("sdm.sigs.decomps", FS.ext("map"));
            var emitting = EmittingFile(path);
            path.Overwrite(dst.Emit());
            EmittedFile(emitting,1);

            return true;
        }

   }
}