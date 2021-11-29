//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Expr;
    using static core;
    using static CsPatterns;

    public class Generators : AppService<Generators>
    {
        public StringLiteralEmitter StringLiterals()
            => Z0.StringLiteralEmitter.create(Wf);

        public EnumGen CsEnum()
            => new EnumGen();

        public void GenLiteralProvider(Identifier ns, Identifier name, ReadOnlySpan<Literal<string>> literals, FS.FilePath dst)
        {
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            margin += 4;
            buffer.IndentLine(margin, PublicReadonlyStruct(name));
            buffer.IndentLine(margin, Open());
            margin +=4;
            for(var i=0; i<literals.Length; i++)
            {
                ref readonly var literal = ref skip(literals,i);
                buffer.IndentLineFormat(margin, "public const string {0} = {1};", text.capitalize(literal.Name.Format()), text.enquote(literal.Value.Value));
            }
            margin -=4;
            buffer.IndentLine(margin, Close());
            margin -=4;
            buffer.IndentLine(margin, Close());

            var emitting = EmittingFile(dst);
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());

            EmittedFile(emitting, literals.Length);
        }

        public void GenSymFactories(Identifier ns, Identifier name, ReadOnlySpan<Type> enums, FS.FilePath dst)
        {
            var flow = Wf.EmittingFile(dst);
            var buffer = text.buffer();
            var margin = 0u;
            buffer.IndentLine(margin, CsPatterns.NamespaceDecl(ns));
            buffer.IndentLine(margin, Open());
            var count = GenSymFactories(margin + 4, name, enums, buffer);
            buffer.IndentLine(margin, Close());
            using var writer = dst.Writer();
            writer.WriteLine(buffer.Emit());
            Wf.EmittedFile(flow,count);
        }

        public uint GenSymFactories(uint margin, Identifier name, ReadOnlySpan<Type> enums, ITextBuffer dst)
        {
            dst.IndentLine(margin, PublicReadonlyStruct(name));
            dst.IndentLine(margin, Open());
            margin +=4;
            var counter = 0u;
            for(var i=0; i<enums.Length; i++)
            {
                ref readonly var type = ref skip(enums,i);
                var adapted = ClrEnumAdapter.adapt(type);
                counter += GenSymFactories(margin, adapted, dst);
            }
            margin -=4;
            dst.IndentLine(margin, Close());
            return counter;
        }

        public uint GenSymFactories(uint margin, ClrEnumAdapter src, ITextBuffer dst)
        {
            var counter = 0u;
            var members = src.Members;
            for(var j=0; j<members.Length; j++)
            {
                ref readonly var member = ref skip(members,j);
                var name = member.Name;
                var tag = member.Definition.Tag<SymbolAttribute>();
                var symbol = text.ifempty(tag.MapValueOrDefault(t => t.Symbol, name),name);
                var func = PublicOneLineFunc(@string, name, Empty(), RP.enquote(symbol));
                dst.IndentLine(margin, func);
                dst.AppendLine();
                counter++;
            }
            return counter;
        }
    }
}