//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        ApiServices ApiSvc => Service(Wf.ApiServices);

        ApiEmitters ApiEmitters => ApiSvc.Emitters;

        ApiComments ApiComments => ApiSvc.Comments;

        [CmdOp("api/emit")]
        Outcome ApiEmit(CmdArgs args)
        {
            ApiEmitters.Emit();
            return true;
        }

        [CmdOp("api/emit/comments")]
        void ApiEmitComments()
        {
            var ds = ApiComments.Calc();
            ref readonly var xmlsources = ref ds.XmlSources;
            iter(xmlsources, path => Write(path.ToUri()));

            ref readonly var csvtargets = ref ds.CsvRowLookup;
            iter(csvtargets.Keys, key => Write(key.ToUri().Format()));

            ref readonly var sources = ref ds.Sources;
            iter(sources, source => Write(source.ToUri()));

            // var types = new string[]{nameof(vpack),
            //     nameof(vmask),
            //     nameof(cpu),
            //     nameof(gcpu),
            //     nameof(BitMasks),
            //     nameof(BitMaskLiterals),
            // };

            // var types2 = new string[]{
            //     "z0.lib." + nameof(vpack),
            //     "z0.lib." + nameof(vmask),
            //     "z0.lib." + nameof(cpu),
            //     "z0.lib." + nameof(gcpu),
            //     "z0.lib." + nameof(BitMasks),
            //     "z0.lib." + nameof(BitMaskLiterals),
            // };

            //ApiComments.EmitMarkdownDocs(ds,types);
        }

        [CmdOp("api/emit/classes")]
        Outcome EmitApiClasses(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var count = classifier.ClassCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref classifier[i];
                Write(string.Format("{0,-4} | {1,-16} | {2,-16} | {3, -16} | {4}", c.Ordinal, c.ClassName, c.Identifier, c.Symbol, c.Value));
            }
            var dst = text.emitter();
            RenderApiClasses<AsmSigTokens.GpRmToken,byte>(dst);
            Write(dst.Emit());
            return true;
        }

        void RenderApiClasses<K,T>(ITextEmitter dst, bool header = true)
            where K : unmanaged, Enum
            where T : unmanaged
        {
            const string Format = "{0,-4} | {1,-16} | {2,-16} | {3, -16} | {4}";
            var k = Classifiers.classifier<K,T>();
            var count = k.ClassCount;
            if(header)
                dst.AppendLineFormat(Format,
                    nameof(ValueClass.Ordinal),
                    nameof(ValueClass.ClassName),
                    nameof(ValueClass.Identifier),
                    nameof(ValueClass.Symbol),
                    nameof(ValueClass.Value)
                    );
            iteri(count, i => dst.AppendLineFormat(Format, k[i].Ordinal, k[i].ClassName, k[i].Identifier, k[i].Symbol, k[i].Value));
        }
   }
}