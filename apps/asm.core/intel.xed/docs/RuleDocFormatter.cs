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
            public static RuleDocFormatter create(KeyedCells src)
                => new RuleDocFormatter(src);

            readonly KeyedCells Data;

            XedPaths XedPaths;

            public RuleDocFormatter(KeyedCells src)
            {
                Data = src;
                XedPaths = XedPaths.Service;
            }

            void Render(RuleSig sig, Index<KeyedCell> src, ITextEmitter dst)
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

                    if(key.RowIndex != rix)
                    {
                        dst.AppendLine();
                        rix = key.RowIndex;
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