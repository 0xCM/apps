//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static CsPatterns;

    public class Generators : AppService<Generators>
    {
        public StringLiteralGen StringLiterals()
            => Z0.StringLiteralGen.create(Wf);

        public EnumGen CsEnum()
            => new EnumGen();

        public FS.FolderPath CodeGenDir(string scope)
            => Env.ZDev + FS.folder("generated/src") + FS.folder(scope);

        public FS.FilePath CodeGenPath(string scope, string id, FS.FileExt ext)
            => CodeGenDir(scope) + FS.file(id,ext);

        public LiteralProviderGen LiteralProvider()
            => LiteralProviderGen.create(Wf);

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