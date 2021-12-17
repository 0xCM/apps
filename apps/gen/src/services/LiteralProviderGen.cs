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
        public void Emit<T>(Identifier ns, LiteralSeq<T> literals, FS.FilePath dst)
        {
            var buffer = text.buffer();
            var margin = 0u;
            var typename = typeof(T).Name.ToLower();
            var count = literals.Length;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            margin += 4;
            buffer.IndentLine(margin, "[LiteralProvider]");
            buffer.IndentLine(margin, PublicReadonlyStruct(literals.Name));
            buffer.IndentLine(margin, Open());
            margin +=4;
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref literals[i];
                var itemName = literal.Name;
                var itemValue = literal.Value.Format();
                if(CsKeywords.test(itemName))
                    itemName = CsKeywords.identifier(itemName);

                buffer.IndentLineFormat(margin, "public const {0} {1} = {2};", typename, itemName, itemValue);
            }
            margin -=4;
            buffer.IndentLine(margin, Close());
            margin -=4;
            buffer.IndentLine(margin, Close());

            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            writer.Write(buffer.Emit());

            EmittedFile(emitting, count);
        }
    }
}