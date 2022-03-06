//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    using K = XedRules.FieldKind;
    using N = XedRules.RuleOpName;

    using Asm;

    partial class XedRules
    {
        public class RuleMachine
        {
            RuleState state;

            [MethodImpl(Inline)]
            public static RuleMachine create()
                => new RuleMachine();

            [MethodImpl(Inline)]
            public static RuleMachine create(in RuleState src)
                => new RuleMachine(src);

            RuleMachine()
            {

            }

            RuleMachine(in RuleState src)
            {
                state = src;
            }

            public void Update(in FieldAssign src)
            {
                var kind = src.Field;
                var result = Outcome.Success;
                switch(kind)
                {
                    case K.AMD3DNOW:
                        state.AMD3DNOW = (bit)src.Value;
                    break;

                    case K.ASZ:
                        state.ASZ = (bit)src.Value;
                    break;

                    case K.BASE0:
                        state.BASE0 = (XedRegId)src.Value;
                    break;

                    case K.BASE1:
                        state.BASE1 = (XedRegId)src.Value;
                    break;

                    case K.BCAST:
                        state.BCAST = (BCastKind)src.Value;
                    break;

                    case K.BCRC:
                        state.BCRC = (bit)src.Value;
                    break;

                    case K.RELBR:
                        state.RELBR = (Disp)src.Value;
                    break;

                    case K.BRDISP_WIDTH:
                        state.BRDISP_WIDTH = (byte)src.Value;
                    break;

                    case K.CET:
                        state.CET = (bit)src.Value;
                    break;

                    case K.CHIP:
                        state.CHIP = (ChipCode)src.Value;
                    break;

                    case K.CLDEMOTE:
                        state.CLDEMOTE = (bit)src.Value;
                    break;

                    case K.DEFAULT_SEG:
                        state.DEFAULT_SEG = (byte)src.Value;
                    break;

                    case K.DF32:
                        state.DF32 = (bit)src.Value;
                    break;

                    case K.DF64:
                        state.DF64 = (bit)src.Value;
                    break;

                    case K.DISP:
                        state.DISP = src.Value;
                    break;

                    case K.DISP_WIDTH:
                        state.DISP_WIDTH = (byte)src.Value;
                    break;

                    case K.DUMMY:
                        state.DUMMY = (bit)src.Value;
                    break;

                    case K.EASZ:
                        state.EASZ = (byte)src.Value;
                    break;

                    case K.ELEMENT_SIZE:
                        state.ELEMENT_SIZE = (ushort)src.Value;
                    break;

                    case K.ENCODER_PREFERRED:
                        state.ENCODER_PREFERRED = (bit)src.Value;
                    break;

                    case K.ENCODE_FORCE:
                        state.ENCODE_FORCE = (bit)src.Value;
                    break;

                    case K.EOSZ:
                        state.EOSZ = (byte)src.Value;
                    break;

                    case K.ESRC:
                        state.ESRC = (uint4)src.Value;
                    break;

                    case K.FIRST_F2F3:
                        state.FIRST_F2F3 = (byte)src.Value;
                    break;

                    case K.HAS_MODRM:
                        state.HAS_MODRM = (bit)src.Value;
                    break;

                    case K.HAS_SIB:
                        state.HAS_SIB = (bit)src.Value;
                    break;

                    case K.HINT:
                        state.HINT = (byte)src.Value;
                    break;

                    case K.ICLASS:
                        state.ICLASS = (IClass)src.Value;
                    break;

                    case K.ILD_F2:
                        state.ILD_F2 = (bit)src.Value;
                    break;

                    case K.ILD_F3:
                        state.ILD_F3 = (bit)src.Value;
                    break;

                    case K.ILD_SEG:
                        state.ILD_SEG = (byte)src.Value;
                    break;

                    case K.IMM0:
                        state.IMM0 = (bit)src.Value;
                    break;

                    case K.IMM0SIGNED:
                        state.IMM0SIGNED = (bit)src.Value;
                    break;

                    case K.IMM1:
                        state.IMM1 = (bit)src.Value;
                    break;

                    case K.IMM1_BYTES:
                        state.IMM1_BYTES = (byte)src.Value;
                    break;

                    case K.IMM_WIDTH:
                        state.IMM_WIDTH = (byte)src.Value;
                    break;

                    case K.INDEX:
                        state.INDEX = (XedRegId)src.Value;
                    break;

                    case K.LAST_F2F3:
                        state.LAST_F2F3 = (byte)src.Value;
                    break;

                    case K.LLRC:
                        state.LLRC = (byte)src.Value;
                    break;

                    case K.LOCK:
                        state.LOCK = (bit)src.Value;
                    break;

                    case K.LZCNT:
                        state.LZCNT = (bit)src.Value;
                    break;

                    case K.MAP:
                        state.MAP = (byte)src.Value;
                    break;

                    case K.MASK:
                        state.MASK = (byte)src.Value;
                    break;

                    case K.MAX_BYTES:
                        state.MAX_BYTES = (byte)src.Value;
                    break;

                    case K.MEM_WIDTH:
                        state.MEM_WIDTH = (ushort)src.Value;
                    break;

                    case K.MOD:
                        state.MOD = (byte)src.Value;
                    break;

                    case K.REG:
                        state.REG = (byte)src.Value;
                    break;

                    case K.MODRM_BYTE:
                        state.MODRM_BYTE = (byte)src.Value;
                    break;

                    case K.MODE:
                        state.MODE = (byte)src.Value;
                    break;

                    case K.MODEP5:
                        state.MODEP5 = (bit)src.Value;
                    break;

                    case K.MODEP55C:
                        state.MODEP55C = (bit)src.Value;
                    break;

                    case K.MODE_FIRST_PREFIX:
                        state.MODE_FIRST_PREFIX = (bit)src.Value;
                    break;

                    case K.MPXMODE:
                        state.MPXMODE = (bit)src.Value;
                    break;

                    case K.MUST_USE_EVEX:
                        state.MUST_USE_EVEX = (bit)src.Value;
                    break;

                    case K.NEEDREX:
                        state.NEEDREX = (bit)src.Value;
                    break;

                    case K.NEED_MEMDISP:
                        state.NEED_MEMDISP = (bit)src.Value;
                    break;

                    case K.NEED_SIB:
                        state.NEED_SIB = (bit)src.Value;
                    break;

                    case K.NELEM:
                        state.NELEM = (byte)src.Value;
                    break;

                    case K.NOMINAL_OPCODE:
                        state.NOMINAL_OPCODE = (byte)src.Value;
                    break;

                    case K.NOREX:
                        state.NOREX = (bit)src.Value;
                    break;

                    case K.NO_SCALE_DISP8:
                        state.NO_SCALE_DISP8 = (bit)src.Value;
                    break;

                    case K.NPREFIXES:
                        state.NPREFIXES = (byte)src.Value;
                    break;

                    case K.NREXES:
                        state.NREXES = (byte)src.Value;
                    break;

                    case K.NSEG_PREFIXES:
                        state.NSEG_PREFIXES = (byte)src.Value;
                    break;

                    case K.OSZ:
                        state.OSZ = (bit)src.Value;
                    break;

                    case K.OUT_OF_BYTES:
                        state.OUT_OF_BYTES = (bit)src.Value;
                    break;

                    case K.P4:
                        state.P4 = (bit)src.Value;
                    break;

                    case K.POS_DISP:
                        state.POS_DISP = (byte)src.Value;;
                    break;

                    case K.POS_IMM:
                        state.POS_IMM = (byte)src.Value;
                    break;

                    case K.POS_IMM1:
                        state.POS_IMM1 = (byte)src.Value;
                    break;

                    case K.POS_MODRM:
                        state.POS_MODRM = (byte)src.Value;
                    break;

                    case K.POS_NOMINAL_OPCODE:
                        state.POS_NOMINAL_OPCODE = (byte)src.Value;
                    break;

                    case K.POS_SIB:
                        state.POS_SIB = (byte)src.Value;
                    break;

                    case K.PREFIX66:
                        state.PREFIX66 = 1;
                    break;

                    case K.PTR:
                        state.PTR = 1;
                    break;

                    case K.REALMODE:
                        state.REALMODE = 1;
                    break;

                    case K.OUTREG:
                        state.OUTREG = (XedRegId)src.Value;
                    break;

                    case K.REG0:
                        state.REG0 = (XedRegId)src.Value;
                    break;

                    case K.REG1:
                        state.REG1 = (XedRegId)src.Value;
                    break;

                    case K.REG2:
                        state.REG2 = (XedRegId)src.Value;
                    break;

                    case K.REG3:
                        state.REG3 = (XedRegId)src.Value;
                    break;

                    case K.REG4:
                        state.REG4 = (XedRegId)src.Value;
                    break;

                    case K.REG5:
                        state.REG5 = (XedRegId)src.Value;
                    break;

                    case K.REG6:
                        state.REG6 = (XedRegId)src.Value;
                    break;

                    case K.REG7:
                        state.REG7 = (XedRegId)src.Value;
                    break;

                    case K.REG8:
                        state.REG8 = (XedRegId)src.Value;
                    break;

                    case K.REG9:
                        state.REG9 = (XedRegId)src.Value;
                    break;

                    case K.REP:
                        state.REP = (byte)src.Value;
                    break;

                    case K.REX:
                        state.REX = (bit)src.Value;
                    break;

                    case K.REXB:
                        state.REXB = (bit)src.Value;
                    break;

                    case K.REXR:
                        state.REXR = (bit)src.Value;
                    break;

                    case K.REXRR:
                        state.REXRR = (bit)src.Value;
                    break;

                    case K.REXW:
                        state.REXW = (bit)src.Value;
                    break;

                    case K.REXX:
                        state.REXX = (bit)src.Value;
                    break;

                    case K.RM:
                        state.RM = (byte)src.Value;
                    break;

                    case K.ROUNDC:
                        state.ROUNDC = (byte)src.Value;
                    break;

                    case K.SAE:
                        state.SAE = (bit)src.Value;
                    break;

                    case K.SCALE:
                        state.SCALE = (byte)src.Value;
                    break;

                    case K.SEG0:
                        state.SEG0 = (XedRegId)src.Value;
                    break;

                    case K.SEG1:
                        state.SEG1 = (XedRegId)src.Value;
                    break;

                    case K.SEG_OVD:
                        state.SEG_OVD = (byte)src.Value;
                    break;

                    case K.SIBBASE:
                        state.SIBBASE = (byte)src.Value;
                    break;

                    case K.SIBINDEX:
                        state.SIBINDEX = (byte)src.Value;
                    break;

                    case K.SIBSCALE:
                        state.SIBSCALE = (byte)src.Value;
                    break;

                    case K.SMODE:
                        state.SMODE = (byte)src.Value;
                        break;

                    case K.SRM:
                        state.SRM = (byte)src.Value;
                    break;

                    case K.TZCNT:
                        state.TZCNT = (bit)src.Value;
                    break;

                    case K.UBIT:
                        state.UBIT = (bit)src.Value;
                    break;

                    case K.UIMM0:
                        state.UIMM0 = src.Value;
                    break;

                    case K.UIMM1:
                        state.UIMM1 = (byte)src.Value;
                    break;

                    case K.USING_DEFAULT_SEGMENT0:
                        state.USING_DEFAULT_SEGMENT0 = (bit)src.Value;
                    break;

                    case K.USING_DEFAULT_SEGMENT1:
                        state.USING_DEFAULT_SEGMENT1 = (bit)src.Value;
                    break;

                    case K.VEXDEST210:
                        state.VEXDEST210 = (byte)src.Value;
                    break;

                    case K.VEXDEST3:
                        state.VEXDEST3 = (bit)src.Value;
                    break;

                    case K.VEXDEST4:
                        state.VEXDEST4 = (bit)src.Value;
                    break;

                    case K.VEXVALID:
                        state.VEXVALID = (byte)src.Value;
                    break;

                    case K.VEX_C4:
                        state.VEX_C4 = (bit)src.Value;
                    break;

                    case K.VEX_PREFIX:
                        state.VEX_PREFIX = (byte)src.Value;
                    break;

                    case K.VL:
                        state.VL = (byte)src.Value;
                    break;

                    case K.WBNOINVD:
                        state.WBNOINVD = (bit)src.Value;
                    break;

                    case K.ZEROING:
                        state.ZEROING = (bit)src.Value;
                    break;

                    case K.MEM0:
                        state.MEM0 = (bit)src.Value;
                    break;

                    case K.MEM1:
                        state.MEM1 = (bit)src.Value;
                    break;

                    case K.AGEN:
                        state.AGEN = (bit)src.Value;
                    break;
                }
            }

            [MethodImpl(Inline)]
            public ref readonly RuleState State()
                => ref state;

            [MethodImpl(Inline)]
            public RuleMachine Reset()
            {
                state = default;
                return this;
            }

            public EncodingOffsets Offsets()
            {
                var offsets = EncodingOffsets.init();
                offsets.OpCode = (sbyte)(state.POS_NOMINAL_OPCODE);
                if(state.HAS_MODRM)
                    offsets.ModRm = (sbyte)state.POS_MODRM;
                if(state.POS_SIB != 0)
                    offsets.Sib = (sbyte)state.POS_SIB;
                if(state.POS_DISP != 0)
                    offsets.Disp = (sbyte)state.POS_DISP;
                if(state.IMM0)
                    offsets.Imm0 = (sbyte)state.POS_IMM;
                return offsets;
            }

            public Index<K> Flags()
            {
                var flags = list<K>();
                if(state.NEED_MEMDISP)
                    flags.Add(K.NEED_MEMDISP);
                if(state.P4)
                    flags.Add(K.P4);
                if(state.USING_DEFAULT_SEGMENT0)
                    flags.Add(K.USING_DEFAULT_SEGMENT0);
                if(state.USING_DEFAULT_SEGMENT1)
                    flags.Add(K.USING_DEFAULT_SEGMENT1);
                if(state.LZCNT)
                    flags.Add(K.LZCNT);
                if(state.TZCNT)
                    flags.Add(K.TZCNT);
                if(state.DF32)
                    flags.Add(K.DF32);
                if(state.DF64)
                    flags.Add(K.DF64);
                if(state.MUST_USE_EVEX)
                    flags.Add(K.MUST_USE_EVEX);
                if(state.REXRR)
                    flags.Add(K.REXRR);
                return flags.ToArray();
            }

            public RuleOperands RuleOperands(in AsmHexCode code)
            {
                var _ops = list<RuleOperand>();
                if(state.DISP_WIDTH != 0)
                    _ops.Add(new RuleOperand(N.DISP, disp(state, code)));

                if(state.IMM0)
                    _ops.Add(new RuleOperand(N.IMM0, imm(state, code)));

                if(state.RELBR.IsNonZero)
                    _ops.Add(new RuleOperand(N.RELBR, state.RELBR));

                if(state.BASE0 != 0)
                    _ops.Add(new RuleOperand(N.BASE0, state.BASE0));

                if(state.BASE1 != 0)
                    _ops.Add(new RuleOperand(N.BASE1, state.BASE1));

                if(state.SCALE != 0)
                    _ops.Add(new RuleOperand(N.SCALE, state.SCALE));

                if(state.INDEX != 0)
                    _ops.Add(new RuleOperand(N.INDEX, state.INDEX));

                if(state.REG0 != 0)
                    _ops.Add(new RuleOperand(N.REG0, state.REG0));

                if(state.REG1 != 0)
                    _ops.Add(new RuleOperand(N.REG1, state.REG1));

                if(state.REG2 != 0)
                    _ops.Add(new RuleOperand(N.REG2, state.REG2));

                if(state.REG3 != 0)
                    _ops.Add(new RuleOperand(N.REG3, state.REG3));

                if(state.REG4 != 0)
                    _ops.Add(new RuleOperand(N.REG4, state.REG4));

                if(state.REG5 != 0)
                    _ops.Add(new RuleOperand(N.REG5, state.REG5));

                if(state.REG6 != 0)
                    _ops.Add(new RuleOperand(N.REG6, state.REG6));

                if(state.REG7 != 0)
                    _ops.Add(new RuleOperand(N.REG7, state.REG7));

                if(state.REG8 != 0)
                    _ops.Add(new RuleOperand(N.REG8, state.REG8));

                if(state.REG9 != 0)
                    _ops.Add(new RuleOperand(N.REG9, state.REG9));

                if(state.MEM0Val.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.MEM0, state.MEM0Val));

                if(state.MEM1Val.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.MEM1, state.MEM1Val));

                if(state.AGENVal.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.AGEN, state.AGENVal));

                return map(_ops, o => (o.Name, o)).ToDictionary();
            }

            public ConstLookup<FieldKind,object> Values()
            {
                var dst = dict<FieldKind,object>();
                var kinds = new FieldLookup();
                var fields = kinds.RightValues;
                foreach(var f in fields)
                    dst.Add(kinds[f], f.GetValue(state));
                return dst;
            }

            public static ConstLookup<FieldKind,FieldInfo> fields()
            {
                var fields = typeof(RuleState).PublicInstanceFields();
                var count = fields.Length;
                var dst = dict<FieldKind,FieldInfo>();
                for(var i=0; i<count; i++)
                {
                    ref readonly var field = ref skip(fields,i);
                    var tag = field.Tag<RuleOperandAttribute>();
                    if(tag)
                        dst.TryAdd(tag.Value.Kind, field);
                }
                return dst;
            }

            public static Index<RuleFieldSpec> specs()
            {
                var src = typeof(RuleState).PublicInstanceFields();
                var dst = alloc<RuleFieldSpec>(src.Length);
                for(var i=z16; i<src.Length; i++)
                {
                    ref readonly var field = ref skip(src,i);
                    ref var record = ref seek(dst,i);
                    record.Pos = i;
                    record.Name = field.Name;
                    record.Type = field.FieldType.IsEnum ? string.Format("enum<{0}>", field.FieldType.Name) : field.FieldType.DisplayName();
                    var tag = field.Tag<RuleOperandAttribute>();
                    if(tag)
                    {
                        record.Width = tag.Value.Width;
                        record.Kind = tag.Value.Kind;
                    }
                }
                return dst;
            }
        }
    }
}