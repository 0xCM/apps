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

                if(state.MEM0.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.MEM0, state.MEM0));

                if(state.MEM1.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.MEM1, state.MEM1));

                if(state.AGEN.IsNonEmpty)
                    _ops.Add(new RuleOperand(N.AGEN, state.AGEN));

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