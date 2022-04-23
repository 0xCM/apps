//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        void EmitIdentities(Index<PatternOpCode> src)
        {
            var dst = text.buffer();
            var ids = XedOpCodes.identify(src);
            var count = ids.Count;
            var @class = InstClass.Empty;
            var ocbyte = Hex8.Zero;
            var @lock = uint2.Zero;
            var r=z16;
            var s=z16;
            for(var i=z16; i<count;i++,r++,s++)
            {
                ref readonly var id = ref ids[i];
                if(id.Class != @class)
                {
                    r=0;
                    s=0;
                    @class = id.Class;

                }

                if(id.Byte != ocbyte)
                {
                    s=0;
                    ocbyte = id.Byte;
                }

                var _row = string.Format("{0,-18} | {1,-2} | {2,-2} | {3,-2}", id.Class, id.Byte, id.Lock, id.Mod.Glyph);
                var row = string.Format("{0,-6} | {1} | {2,-6} | {3,-6}", i, _row, r, s);
                if(i != count - 1)
                    dst.AppendLine(row);
                else
                    dst.Append(row);
            }

            FileEmit(dst.Emit(), count, XedPaths.Targets() + FS.file("xed.opcodes.identities", FS.Csv), TextEncodingKind.Asci);
        }
    }
}