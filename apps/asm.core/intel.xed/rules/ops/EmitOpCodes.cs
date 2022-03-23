//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedPatterns;

    partial class XedRules
    {
        Index<PatternOpCode> CalcPatternOpCodes(Index<InstPattern> src)
        {
            var count = src.Count;
            var buffer = alloc<PatternOpCode>(count);
            for(var i=0; i<count; i++)
                XedPatterns.poc(src[i], out seek(buffer,i));
            return buffer;
        }

        void EmitOpCodes(Index<InstPattern> src)
            => TableEmit(CalcPatternOpCodes(src).View, PatternOpCode.RenderWidths, XedPaths.Table<PatternOpCode>());

        void EmitInstFieldDefs(Index<InstPattern> src)
        {
            var buffer = list<InstFieldInfo>();
            for(var i=0; i<src.Count; i++)
            {
                ref readonly var pattern = ref src[i];
                ref readonly var body = ref pattern.Body;
                for(byte j=0; j<body.FieldCount; j++)
                {
                    ref readonly var field = ref body[j];
                    buffer.Add(XedPatterns.fieldinfo(pattern,field,j));
                }
            }

            TableEmit(buffer.ViewDeposited(), InstFieldInfo.RenderWidths, XedPaths.Table<InstFieldInfo>());
        }
    }
}