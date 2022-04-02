//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static XedRules;
    using static XedModels;
    using static XedPatterns;

    partial class XedDocs
    {
        public class InstDoc
        {
            public readonly Index<InstDocPart> Parts;

            public InstDoc(InstDocPart[] src)
            {
                Parts = src;
            }

            public InstDoc(uint count)
            {
                Parts = core.alloc<InstDocPart>(count);
            }

            public ref InstDocPart this[int i]
            {
                [MethodImpl(Inline)]
                get => ref Parts[i];
            }

            public ref InstDocPart this[uint i]
            {
                [MethodImpl(Inline)]
                get => ref Parts[i];
            }

            public string Format()
            {
                var count = Parts.Count;
                var @class = EmptyString;
                var opcode = XedOpCode.Empty;
                var dst = text.buffer();
                dst.AppendLine("# Patterns");
                dst.AppendLine();
                var doc  = this;
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref doc[i];
                    if(part.Classifier != @class)
                    {
                        @class = part.Classifier;
                        dst.AppendLineFormat("## {0}", @class);
                        dst.AppendLine();
                    }

                    if(part.OpCode != opcode)
                    {
                        opcode = part.OpCode;
                        dst.AppendLineFormat("### {0} {1}", string.Format("{0} {1}", part.OcMap, opcode.Value), part.InstForm);
                        dst.AppendLine();
                    }

                    dst.AppendFormat("#### {0}", part.Classifier.ToLower());
                    for(var k=0; k<part.OpNames.Count; k++)
                    {
                        if(k!=0)
                            dst.Append(Chars.Comma);

                        dst.Append(Chars.Space);
                        dst.Append(part.OpNames[k].Indicator.Format());
                    }

                    dst.AppendLine();
                    dst.AppendFormat("{0}({1})", @class, part.Fields.Format());

                    if(part.Layout.IsNonEmpty)
                        dst.AppendFormat(" -> [{0}]", part.Layout);
                    if(part.Constraints.IsNonEmpty)
                        dst.AppendFormat(" <{0}>", part.Constraints);
                    dst.AppendLine();

                    ref readonly var ops = ref part.Ops;
                    for(var k=0; k<ops.Count; k++)
                    {
                        ref readonly var op = ref ops[k];
                        dst.AppendLineFormat("{0} {1}", op.Index, op.Format());
                    }
                    dst.AppendLine();
                }

                return dst.Emit();
            }
        }
    }
}