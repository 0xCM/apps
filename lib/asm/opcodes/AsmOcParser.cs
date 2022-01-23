//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class AsmOcParser
    {
        AsmOcDatasets Datasets;

        public AsmOcParser()
        {
            Datasets = AsmOcDatasets.load();
        }

        [Parser]
        public static Outcome parse(string src, out AsmOcSpec dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src),Chars.Space));
            var count = (byte)min(parts.Length, 15);
            dst = AsmOcSpec.Empty;
            dst.TokenCount = count;
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref skip(parts,i);
                if(octoken(expr, out var token))
                {
                    dst[i] = token;
                }
                else
                {
                    result = (false, string.Format("A token matching the expression '{0}' was not found", expr));
                    break;
                }
            }
            return result;
        }

        static bool octoken(string src, out AsmOcToken dst)
            => _Datasets.TokensByExpression.Find(src, out dst);

        public bool Token(string src, out AsmOcToken dst)
            => Datasets.TokensByExpression.Find(src, out dst);

        public Outcome Parse(string src, out AsmOcSpec dst)
        {
            var result = Outcome.Success;
            var parts = text.trim(text.split(text.despace(src),Chars.Space));
            var count = (byte)min(parts.Length, 15);
            dst = AsmOcSpec.Empty;
            dst.TokenCount = count;
            for(var i=0; i<count; i++)
            {
                ref readonly var expr = ref skip(parts,i);
                if(Token(expr, out var token))
                {
                    dst[i] = token;
                }
                else
                {
                    result = (false, string.Format("A token matching the expression '{0}' was not found", expr));
                    break;
                }
            }
            return result;
        }

        static AsmOcParser()
        {
            _Datasets = AsmOcDatasets.load();
        }

        static AsmOcDatasets _Datasets;
    }
}