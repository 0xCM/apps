//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedDocs
    {
        public class RuleDocFormatter
        {
            public static RuleDocFormatter create(RulCells src)
                => new RuleDocFormatter(src);

            readonly RulCells Data;

            XedPaths XedPaths;

            public RuleDocFormatter(RulCells src)
            {
                Data = src;
                XedPaths = XedPaths.Service;
            }

            void Render(RuleSig sig, Index<RuleCell> src, ITextEmitter dst)
            {
                dst.AppendLine(TableHeader(sig));
                dst.AppendLine();
                dst.AppendLineFormat("{0}(){{", sig.TableName);
                var rix = z16;
                var count = src.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var cell = ref src[i];
                    ref readonly var key = ref cell.Key;
                    if(i==0)
                        dst.Append("    ");

                    if(key.Row != rix)
                    {
                        dst.AppendLine();
                        rix = key.Row;
                        dst.Append("    ");
                    }
                    else
                    {
                        if(i != 0)
                            dst.Append(Chars.Space);
                    }

                    dst.Append(cell.Format());
                }

                dst.AppendLine();
                dst.AppendLine("}");
                dst.AppendLine();
            }

            public string Format()
            {
                var dst = text.buffer();
                var sigs = Data.Keys;
                for(var i=0; i<sigs.Length; i++)
                {
                    ref readonly var sig = ref skip(sigs,i);
                    Render(sig, Data[sig], dst);
                }
                return dst.Emit();
            }
        }
    }
}