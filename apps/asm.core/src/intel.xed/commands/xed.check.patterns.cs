//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedRules;
    using static XedModels;
    using static XedRender;
    using static core;

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static bits<T> load<T>(T src)
            where T : unmanaged
                => src;

        [MethodImpl(Inline)]
        public static bits<T> load<T>(byte n, T src)
            where T : unmanaged
                => (n,src);

        [CmdOp("xed/check/bits")]
        Outcome CheckBits(CmdArgs args)
        {
            Span<char> buffer = stackalloc char[84];
            ulong input = 0xF0CCAADD33;
            uint n = 24;
            ulong match = 0b1010_1010_1101_1101_0011_0011;
            var output = BitRender.render4x4(Chars.Underscore, n,input,buffer);
            Write(string.Format("{0} | {1}",  "1010_1010_1101_1101_0011_0011", text.format(output)));

            return true;
        }

        [CmdOp("xed/check/patterns")]
        Outcome CheckPatterns(CmdArgs args)
        {
            var result = Outcome.Success;
            var ipatterns = Xed.Rules.CalcInstPatterns();
            var count = ipatterns.Count;
            var dst = AppDb.XedPath("xed.patterns.checks", FileKind.Txt);
            var ocparser = XedOpCodeParser.create();
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                var ipattern = ipatterns[i];
                ref readonly var id = ref ipattern.PatternId;
                ref readonly var instid = ref ipattern.InstId;
                ref readonly var @class = ref ipattern.Class;
                ref readonly var form = ref ipattern.Form;
                ref readonly var ext = ref ipattern.Extension;
                ref readonly var isa = ref ipattern.Isa;
                ref readonly var category = ref ipattern.Category;
                ref readonly var attribs = ref ipattern.InstAttribs;
                ref readonly var flags = ref ipattern.InstFlags;
                ref readonly var def = ref ipattern.InstDef;
                ref readonly var spec = ref ipattern.PatternSpec;
                ref readonly var body = ref ipattern.Body;
                ref readonly var raw = ref ipattern.RawBody;
                ref readonly var ops = ref ipattern.OpSpecs;
                writer.WriteLine(RP.PageBreak80);
                writer.WriteLine(@class);
                writer.WriteLine(raw);
                writer.WriteLine(body.Format());
                writer.WriteLine();
            }
            EmittedFile(emitting,count);
            return result;
        }

        public static string _format(in InstPatternBody src)
        {
            var dst = text.buffer();
            _render(src, dst);
            return dst.Emit();
        }


        public static void _render(in InstPatternBody src, ITextBuffer dst)
        {
            for(var i=0; i<src.PartCount; i++)
            {
                if(i!=0)
                    dst.Append(Chars.Space);

                ref readonly var part = ref src[i];
                if(InstDefs.vexclass(part, out var vc))
                    dst.Append(format(vc));
                else if(InstDefs.vexkind(part, out var vk))
                    dst.Append(format(vk));
                else if(InstDefs.map(part, out var map))
                {
                    var vex = InstDefs.vex(src);
                    if(vex != null && vex.Value != 0)
                    {
                        switch(vex.Value)
                        {
                            //case VexClass.VV0:
                            case VexClass.VV1:
                                dst.AppendFormat("{0}", format((VexMapKind)map));
                                break;
                            case VexClass.EVV:
                                dst.AppendFormat("{0}", format((EvexMapKind)map));
                                break;
                            case VexClass.XOPV:
                                dst.AppendFormat("{0}", format((XopMapKind)map));
                                break;
                        }
                    }
                    else
                        dst.Append(format((LegacyMapKind)part.AsAssign().Value.Data));
                }
                else
                    dst.Append(format(part));
            }
        }
    }
}