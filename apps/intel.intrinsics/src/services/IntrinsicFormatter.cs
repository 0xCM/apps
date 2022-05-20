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
        public class IntrinsicFormatter
        {
            public string FormatAlgorithm(IntrinsicDef src)
            {
                var dst = text.buffer();
                overview(src, dst);
                dst.AppendLine(sig(src));
                body(src, dst);
                return dst.Emit();
            }

            static void body(IntrinsicDef src, ITextBuffer dst)
            {
                dst.AppendLine("{");
                render(src.operation, dst);
                dst.AppendLine("}");
            }

            static void render(Operation src, ITextBuffer dst)
            {
                if(src.Content != null)
                    iter(src.Content, x => dst.AppendLine("  " + x.Content));
            }

            static void overview(IntrinsicDef src, ITextBuffer dst)
            {
                dst.AppendLine(string.Format("# Intrinsic: {0}", sig(src)));

                var classes = list<string>(3);
                if(nonempty(src.tech))
                    classes.Add(src.tech);
                if(src.CPUID.Count != 0)
                    classes.Add(string.Join(Chars.Comma, src.CPUID));
                if(src.category.IsNonEmpty)
                    classes.Add(src.category.Content);
                if(classes.Count != 0)
                    dst.AppendLineFormat("# Classification: {0}", string.Join(", ", classes));

                render(src.instructions, dst);
                dst.AppendLineFormat("# Description: {0}", src.description);
            }

            static string format(Instruction src)
                => string.Format("# Instruction: {0} {1}\r\n", src.name, src.form) + string.Format("# Iform: {0}", src.xed);

            static void render(Instructions src, ITextBuffer dst)
                => iter(src, x => dst.AppendLine(format(x)));
        }
    }
}