//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;

    partial class ApiCmdProvider
    {
        [CmdOp("check/classifiers")]
        Outcome CheckClassifiers(CmdArgs args)
        {
            var classifier = Classifiers.classifier<AsmSigTokens.GpRmToken,byte>();
            var count = classifier.ClassCount;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref classifier[i];
                //ref readonly var c = ref skip(classes,i);
                Write(string.Format("{0,-4} | {1,-16} | {2,-16} | {3, -16} | {4}", c.Ordinal, c.ClassName, c.Identifier, c.Symbol, c.Value));
            }

            return true;
        }

        [CmdOp("api/emit/enum-list")]
        Outcome EmitApiEnums(CmdArgs args)
        {
            var src = EmitApiEnumList();
            return true;
        }

        FS.FilePath EmitApiEnumList()
        {
            var dst = AppDb.ApiEnumListPath();
            var src = ApiRuntimeCatalog.Components.Where(x => !x.FullName.Contains("codegen.")).Storage.Enums().Where(x => x.ContainsGenericParameters == false && nonempty(x.Namespace));
            var emitting = EmittingFile(dst);
            var count = src.Length;
            using var writer = dst.Utf8Writer();
            for(var i=0; i<count; i++)
            {
                ref readonly var type = ref skip(src,i);
                writer.WriteLine(type.AssemblyQualifiedName);
            }
            EmittedFile(emitting,count);
            return dst;
        }
    }
}