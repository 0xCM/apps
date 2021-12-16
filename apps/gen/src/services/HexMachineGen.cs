//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;

    using static Root;

    public class HexMachineGen : CodeGenerator
    {
        byte MinHandler;

        byte MaxHandler;

        string Namespace;

        protected override string[] StaticUsings {get;}
            = new string[]{
                "Root",
                "HexCodes"
            };

        public void Generate(byte min, byte max, StreamWriter dst)
        {
            MinHandler = min;
            MaxHandler = max;
            Namespace = nameof(Z0);
            dst.WriteLine(Generate());
        }

        public void Generate(byte min, byte max, FS.FolderPath dst)
        {
            var path = dst + FS.file($"HexMachine{Identifier(min)}", FS.Cs);
            using var writer = path.Writer();
            Generate(min, max, writer);
        }

        string Identifier(byte src)
            => text.concat("X", src.FormatHex(zpad:true, specifier:false, uppercase:true));

        string TargetTypeName
            => text.concat("HexMachine",Identifier(MinHandler));

        void OpenTypeDeclaration(int i, TextWriter dst)
        {
            dst.WriteLine(level(i, bracket(nameof(ApiHost))));
            dst.WriteLine(level(i, text.concat($"public struct {TargetTypeName}")));
            dst.WriteLine(level(i, Chars.LBrace));
        }

        void DeclareFields(int i, TextWriter dst)
        {
            dst.WriteLine(level(i,"bit Processed;"));
            dst.WriteLine();
        }

        public override string Generate()
        {

            var current = MinHandler;
            var buffer = text.build();

            using var dst = new StringWriter(buffer);
            EmitFileHeader(dst);
            OpenFileNamespace(dst);
            EmitUsingStatements(dst, TypeLevel);
            OpenTypeDeclaration(TypeLevel,dst);
            DeclareFields(MemberLevel,dst);

            while(current++ < MaxHandler)
                EmitHandler(MemberLevel,current, dst);

            CloseTypeDeclaration(dst, TypeLevel);
            CloseFileNamespace(dst);

            return buffer.ToString();
        }

        void EmitHandler(int i, byte handler, TextWriter dst)
        {
            dst.WriteLine(level(i, "[MethodImpl(Inline), Op]"));
            dst.WriteLine(level(i, $"public void Process({Identifier(handler)} x, Span<byte> dst)"));
            dst.WriteLine(level(i, Chars.LBrace));
            dst.WriteLine();
            dst.WriteLine(level(i, Chars.RBrace));
            dst.WriteLine();
        }
    }
}