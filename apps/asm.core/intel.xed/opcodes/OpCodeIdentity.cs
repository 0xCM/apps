//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using FK = XedModels.OpCodeId.FieldKind;
    using FW = XedModels.OpCodeId.FieldWidth;

    partial class XedOpCodes
    {
        public class OpCodeIdentity
        {
            public static Index<OpCodeId> identify(Index<PatternOpCode> src)
            {
                var bitfield = BitfieldMechanics.dataset<FK,FW,uint>();
                var count = src.Count;
                var dst = alloc<OpCodeId>(count);
                for(var i=z16; i< count; i++)
                    seek(dst,i) = define(bitfield, src[i]);
                return dst.Sort();
            }

            public static OpCodeId define(BitfieldDataset<FK,uint> bitfield, PatternOpCode oc)
            {
                var data = math.or(
                    (uint)oc.InstClass << bitfield.Offset(FK.Class),
                    (uint)oc.PrimaryByte << bitfield.Offset(FK.Byte),
                    (uint)oc.Mod << bitfield.Offset(FK.Mod),
                    (uint)oc.Lock << bitfield.Offset(FK.Lock),
                    (uint)oc.RexW << bitfield.Offset(FK.Rex),
                    (uint)oc.Rep << bitfield.Offset(FK.Rep)
                    );

                return new OpCodeId(oc.PatternId, data);
            }

            public static BitfieldDataset<FK,uint> bitfield()
                => BitfieldMechanics.dataset<FK,FW,uint>();

            public static Func<OpCodeId,string> formatter()
                => formatter(bitfield());

            static Func<OpCodeId,string> formatter(BitfieldDataset<FK,uint> bitfield)
                => formatter(bitfield, bitfield.CellBuffer());

            static Func<OpCodeId,string> formatter(BitfieldDataset<FK,uint> bitfield, Index<BitfieldCell<uint>> cells)
            {
                return format;
                string format(OpCodeId id)
                {
                    bitfield.Cells(id, cells);
                    return cells.Delimit(Chars.Pipe).Format();
                }
            }
        }
    }
}