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
    using static CsPatterns;

    using T = AsmGenTarget;

    partial class AsmModelGen
    {
        void EmitMonicEnum(ReadOnlySpan<string> monics, FS.FilePath dst)
        {
            var flow = EmittingFile(dst);
            var buffer = text.buffer();
            EmitMonicEnumLiterals(monics,0,buffer);
            using var writer = dst.Writer();
            writer.Write(CgRules.FileHeader());
            writer.Write(buffer.Emit());
            EmittedFile(flow, monics.Length);
        }

        public static void EmitMonicEnumLiterals(ReadOnlySpan<string> monics, uint margin, ITextBuffer buffer)
        {
            buffer.AppendLine(NamespaceDecl());
            buffer.AppendLine(Open);
            margin += 4;
            buffer.IndentLine(margin, EnumDecl(TargetIdentifier(T.MonicCodeEnum), @ushort));
            buffer.IndentLine(margin, Open);
            margin += 4;

            var count = monics.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var monic = ref skip(monics,i);
                buffer.IndentLine(margin, string.Format(MonicSymbolPattern, monic.ToLower()));
                buffer.IndentLine(margin, string.Format(ItemAssignPattern, monic, i));
                buffer.AppendLine();
            }
            margin -= 4;
            buffer.IndentLine(margin, Close);

            margin -= 4;
            buffer.IndentLine(margin, Close);
        }
    }
}