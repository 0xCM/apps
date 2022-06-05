//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class AsmCoreCmd
    {
        void Objects(WsContext context, in FileRef src, FS.FilePath dst)
        {
            var emitter = text.emitter();
            var code = dict<MemoryRange,BinaryCode>();
            var obj = Coff.LoadObj(src);
            var sections = Coff.CalcObjSections(context, src);
            var offset = 0u;
            var name = src.Path.FileName.WithoutExtension.Format().Replace(Chars.Dot, Chars.Underscore).Replace(Chars.Dash,Chars.Underscore);
            emitter.IndentLine(offset, "namespace Z0");
            emitter.IndentLine(offset, Chars.LBrace);
            offset += 4;
            emitter.IndentLineFormat(offset, "public readonly struct {0}", name);
            emitter.IndentLine(offset, Chars.LBrace);
            offset += 4;
            for(var j=0; j<sections.Count; j++)
            {
                ref readonly var section = ref sections[j];
                if(section.SectionKind == CoffSectionKind.Text)
                {
                    var range = new MemoryRange(section.RawDataAddress, section.RawDataSize);
                    code[range] = obj.Data;
                    var data = obj.Bytes(range);
                    var gen = string.Format("public static ReadOnlySpan<byte> {0} = new byte[{1}]", "ObjectData", (uint)section.RawDataSize);
                    var hex = data.FormatHex(Chars.Comma, true);
                    var statement = gen + "{" + hex + "};";
                    emitter.IndentLine(offset, statement);
                    emitter.AppendLine();
                }
            }
        }

    }
}