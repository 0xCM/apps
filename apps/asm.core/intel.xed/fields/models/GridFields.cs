//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct GridFields
        {
            public readonly Dim2<ushort> Dim;

            public readonly Index<GridField> Data;

            [MethodImpl(Inline)]
            public GridFields(ushort rows, byte cols, Index<GridField> src)
            {
                Dim = (rows,cols);
                Data = src;
            }

            public string Format()
            {
                var dst = text.buffer();
                var k=0;
                for(var i=0; i<Dim.I; i++)
                {
                    for(var j=0; j<Dim.J; j++, k++)
                    {
                        dst.AppendFormat("{0:D2} {1:D2} {2,-24}", i, j, Data[k]);
                        if(j != Dim.J - 1)
                            dst.Append(" | ");

                    }
                    dst.AppendLine();
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}