//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        public static Outcome parse(ReadOnlySpan<Facet<string>> src, out DisasmState dst)
        {
            var parser = new DisasmFieldParser();
            dst = parser.Parse(src);
            return true;
        }

        public static Outcome parse(string src, out DisasmOpInfo dst)
        {
            dst = default;
            if(text.length(src) < 3)
                return (false,RP.Empty);

            var result = Outcome.Success;
            var data = span(src);

            var idx = text.trim(text.left(src,2));
            result = DataParser.parse(idx, out dst.Index);
            if(result.Fail)
                return (false,AppMsg.ParseFailure.Format(nameof(dst.Index), idx));

            var aspects = text.trim(text.right(src,2));
            var parts = text.split(aspects, Chars.FSlash);
            if(parts.Length != 6)
                return (false, string.Format("Unexpected number of operand aspects in {0}", aspects));

            var i=0;
            result = DataParser.eparse(skip(parts,i++), out dst.Kind);
            if(result.Fail)
                return (false, AppMsg.ParseFailure.Format(nameof(dst.Kind), skip(parts,i-1)));

            result = DataParser.eparse(skip(parts,i++), out dst.Action);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out dst.WidthCode);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(parts,i++), out VisibilityKind vis);
            if(result.Fail)
                return result;
            dst.Visiblity = (OpVisibility)vis;

            result = DataParser.eparse(skip(parts,i++), out dst.OpType);
            if(result.Fail)
                return result;

            dst.Selector = text.trim(skip(parts,i++));
            return result;
        }

        /*
        AND

        PATTERN   : 0x20 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM() nolock_prefix
        OPERANDS  : MEM0:rw:b REG0=GPR8_R():r

        PATTERN   : 0x20 MOD[0b11] MOD=3 REG[rrr] RM[nnn]
        OPERANDS  : REG0=GPR8_B():rw REG1=GPR8_R():r

        PATTERN   : 0x20 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM() lock_prefix
        OPERANDS  : MEM0:rw:b REG0=GPR8_R():r

        PATTERN   : 0x21 MOD[0b11] MOD=3 REG[rrr] RM[nnn]
        OPERANDS  : REG0=GPRv_B():rw REG1=GPRv_R():r

        PATTERN   : 0x21 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM() lock_prefix
        OPERANDS  : MEM0:rw:v REG0=GPRv_R():r

        PATTERN   : 0x22 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM()
        OPERANDS  : REG0=GPR8_R():rw MEM0:r:b

        PATTERN   : 0x23 MOD[mm] MOD!=3 REG[rrr] RM[nnn] MODRM()
        OPERANDS  : REG0=GPRv_R():rw MEM0:r:v

        PATTERN   : 0x24 SIMM8()
        OPERANDS  : REG0=XED_REG_AL:rw:IMPL IMM0:r:b:i8

        PATTERN   : 0x25 SIMMz()
        OPERANDS  : REG0=OrAX():rw:IMPL IMM0:r:z

        PATTERN   : 0x80 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() UIMM8() nolock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x80 MOD[0b11] MOD=3 REG[0b100] RM[nnn] UIMM8()
        OPERANDS  : REG0=GPR8_B():rw IMM0:r:b

        PATTERN   : 0x80 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() UIMM8() lock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x82 MOD[mm] MOD!=3 REG[0b100] RM[nnn] not64 MODRM() UIMM8() nolock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x82 MOD[0b11] MOD=3 REG[0b100] RM[nnn] not64 UIMM8()
        OPERANDS  : REG0=GPR8_B():rw IMM0:r:b

        PATTERN   : 0x82 MOD[mm] MOD!=3 REG[0b100] RM[nnn] not64 MODRM() UIMM8() lock_prefix
        OPERANDS  : MEM0:rw:b IMM0:r:b

        PATTERN   : 0x83 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() SIMM8() nolock_prefix
        OPERANDS  : MEM0:rw:v IMM0:r:b:i8

        PATTERN   : 0x83 MOD[0b11] MOD=3 REG[0b100] RM[nnn] SIMM8()
        OPERANDS  : REG0=GPRv_B():rw IMM0:r:b:i8

        PATTERN   : 0x83 MOD[mm] MOD!=3 REG[0b100] RM[nnn] MODRM() SIMM8() lock_prefix
        OPERANDS  : MEM0:rw:v IMM0:r:b:i8

        */

        internal class DisasmFieldParser
        {
            DisasmState State;

            List<FieldKind> _ParsedFields;

            List<Facet<string>> _UnknownFields;

            Dictionary<FieldKind, string> _Failures;

            public DisasmFieldParser()
            {
                State = DisasmState.Empty;
                _ParsedFields = new();
                _UnknownFields = new();
                _Failures = new();
            }

            void Clear()
            {
                State = DisasmState.Empty;
                _ParsedFields.Clear();
                _UnknownFields.Clear();
                _Failures.Clear();
            }

            public DisasmState Parse(ReadOnlySpan<Facet<string>> src)
            {
                Clear();
                var count = src.Length;
                var dispwidth = 0u;
                var relbranch = Disp.Empty;
                var dst = DisasmState.Empty;
                for(var i=0; i<count; i++)
                {
                    ref readonly var facet = ref skip(src,i);
                    var kind = FieldKind.INVALID;
                    if(XedParsers.parse(facet.Key, out kind))
                    {
                        var value = text.trim(facet.Value);
                        var result = XedDisasm.update(value, kind, ref State);
                        if(result.Fail)
                            _Failures[kind] = value;
                        else
                            _ParsedFields.Add(kind);
                    }
                    else
                        _UnknownFields.Add(facet);
                }

                dst.RuleState = State.RuleState;
                return dst;
            }
       }
    }
}