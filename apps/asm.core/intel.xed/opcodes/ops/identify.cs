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

    using FK = XedModels.OpCodeId.FieldName;
    using FW = XedModels.OpCodeId.FieldWidth;

    partial class XedOpCodes
    {
        public static BitfieldDataset<FK,OpCodeId> bitfield()
            => BfDatasets.create<FK,FW,OpCodeId>();

        public static Index<OpCodeId> pack(BitfieldDataset<FK,OpCodeId> spec, ReadOnlySpan<InstOpCode> src, bool pll = true)
        {
            var dst = bag<OpCodeId>();
            iter(src,opcode => dst.Add(pack(spec,opcode)), pll);
            return dst.Index().Sort();
        }

        [MethodImpl(Inline)]
        public static OpCodeId pack(BitfieldDataset<FK,OpCodeId> spec, InstOpCode oc)
            => math.or(
                (uint)oc.InstClass << (int)spec.Offset(FK.Class),
                (uint)oc.PrimaryByte << (int)spec.Offset(FK.Hex8),
                (uint)oc.Mod << (int)spec.Offset(FK.Mod),
                (uint)oc.Lock << (int)spec.Offset(FK.Lock),
                (uint)oc.RexW << (int)spec.Offset(FK.Rex),
                (uint)oc.Rep << (int)spec.Offset(FK.Rep)
                );

        public static Func<OpCodeId,string> formatter(BitfieldDataset<FK,OpCodeId> spec)
            => src => string.Format("{0,-18} | 0x{1} | {2,-6} | {3,-6}",
                    spec.Extract<InstClass>(FK.Class, src),
                    spec.Extract<Hex8>(FK.Hex8, src),
                    spec.Extract<LockIndicator>(FK.Lock, src),
                    spec.Extract<BitIndicator>(FK.Rex, src)
                    );
    }
}