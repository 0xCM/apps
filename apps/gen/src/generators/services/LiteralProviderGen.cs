//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static CsPatterns;

    public class LiteralProviderGen : AppService<LiteralProviderGen>
    {
        public void Emit(Identifier ns, Identifier name, ReadOnlySpan<Literal<string>> literals, FS.FilePath dst)
        {
            var buffer = text.buffer();
            var margin = 0u;
            var typename = typeof(string).Name.ToLower();
            var count = literals.Length;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            margin += 4;
            buffer.IndentLine(margin, "[LiteralProvider]");
            buffer.IndentLine(margin, PublicReadonlyStruct(name));
            buffer.IndentLine(margin, Open());
            margin +=4;
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref skip(literals,i);
                buffer.IndentLineFormat(margin, "public const {0} {1} = {2};", typename, text.capitalize(literal.Name), text.enquote(literal.Value.Value));
            }
            margin -=4;
            buffer.IndentLine(margin, Close());
            margin -=4;
            buffer.IndentLine(margin, Close());

            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());

            EmittedFile(emitting, count);
        }
    }
}