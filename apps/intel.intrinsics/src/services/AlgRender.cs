//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static IntrinsicsDoc;

    partial class IntelIntrinsicSvc
    {
        public class AlgRender
        {
            public static string format(IntrinsicDef src)
            {
                var dst = text.emitter();
                overview(src, dst);
                dst.AppendLine(src.Sig());
                body(src, dst);
                return dst.Emit();
            }

            static void body(IntrinsicDef src, ITextEmitter dst)
            {
                dst.AppendLine("{");
                emit(src.operation, dst);
                dst.AppendLine("}");
            }

            static void emit(Operation src, ITextEmitter dst)
            {
                if(src.IsNonEmpty)
                    iter(src.Content, x => dst.AppendLine("  " + x.Content));
            }

            static void overview(IntrinsicDef src, ITextEmitter dst)
            {
                dst.AppendLine(string.Format("# Intrinsic: {0}", src.Sig()));

                if(nonempty(src.tech))
                    dst.AppendLineFormat("# Tech: {0}", src.tech);

                if(src.CPUID.IsNonEmpty)
                    dst.AppendLineFormat("# CpuId: {0}", src.CPUID);

                if(src.category.IsNonEmpty)
                    dst.AppendLineFormat("# Category: {0}", src.category);

                iter(src.instructions, x => {
                    dst.AppendLineFormat("# Instruction: {0}", x);
                    dst.AppendLineFormat("# IForm: {0}", x.xed);
                });

                dst.AppendLineFormat("# Description: {0}", src.description);
            }
         }
    }
}