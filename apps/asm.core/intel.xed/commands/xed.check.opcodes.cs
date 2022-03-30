//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedRender;
    using static XedModels;
    using static core;
    using static XedPatterns;

    using Asm;

    [Record(TableId)]
    public struct OpCodeCounts : IComparable<OpCodeCounts>
    {
        public const byte FieldCount = 8;

        public const string TableId = "xed.opcodes.counts";

        public uint Seq;

        public uint PatternId;

        public InstClass InstClass;

        public OpCodeKind OcKind;

        public AsmOcValue OcValue;

        public MachineMode Mode;

        public InstPatternBody PatternBody;

        public PatternSort Sort;

        public XedOpCode OpCode
        {
            [MethodImpl(Inline)]
            get => new XedOpCode(Mode, OcKind,OcValue);
        }

        public int CompareTo(OpCodeCounts src)
        {
            var result = InstClass.Classifier.CompareTo(src.InstClass.Classifier);
            if(result == 0)
            {
                result = OcValue.CompareTo(src.OcValue);
                if(result == 0)
                {
                    result = OcKind.CompareTo(src.OcKind);
                    if(result==0)
                    {
                        result = ((byte)Sort.Lockable).CompareTo((byte)src.Sort.Lockable);
                        if(result==0 && Sort.Lockable)
                        {
                            result = ((byte)Sort.LockValue).CompareTo((byte)src.Sort.LockValue);
                        }
                    }
                }
            }

            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,18,12,20,8,160,1};

    }
    partial class XedCmdProvider
    {
        [CmdOp("xed/check/opcodes")]
        Outcome CheckOpCodes(CmdArgs args)
        {
            var patterns = Xed.Rules.CalcInstPatterns();
            var patternLUa = patterns.Map(x => (x.PatternId, x)).ToDictionary();
            var patternLUb = patterns.Map(x => (x.PatternId, x.OcInst)).ToDictionary();
            var opcodes = XedPatterns.xedoc(patterns);
            var counter = 0u;
            var countLU = dict<OcInstClass,byte>();
            var buffer = alloc<OpCodeCounts>(patterns.Count);
            for(var i=0u; i<patterns.Count; i++)
            {
                ref var dst = ref buffer[i];
                ref var src = ref patterns[i];
                ref readonly var ocinst = ref src.OcInst;
                dst.PatternId = src.PatternId;
                dst.Mode = src.Mode;
                dst.InstClass = ocinst.InstClass;
                dst.OcKind = ocinst.OpCode.Kind;
                dst.OcValue = ocinst.OcValue;
                dst.PatternBody = src.Body;
                dst.Sort = src.Sort();
            }

            buffer.Sort();
            for(var i=0u; i<patterns.Count; i++)
                seek(buffer,i).Seq = i;

            TableEmit(@readonly(buffer), OpCodeCounts.RenderWidths, XedPaths.Table<OpCodeCounts>());

            return true;
        }

        static Identifier identify(in PatternOp src)
        {
            var bw = src.OpWidth.Bits;
            var indicator = EmptyString;
            var dst = EmptyString;
            if(src.IsSegReg)
            {
                indicator = "sr";
            }
            else if(src.IsReg)
            {
                indicator = bw != 0 ? "r" : "reg";
            }
            else if(src.IsMem)
            {
                indicator = bw != 0 ? "m" : "mem";
            }
            else if(src.IsPtr)
            {
                indicator = "ptr";
            }
            else
            {
                indicator = format(src.Kind);
            }

            if(bw != 0)
            {
                dst = string.Format("{0}{1}", indicator, bw);
            }
            else
                dst = indicator;

            return dst;
        }

        static Identifier identify(InstPattern src)
        {
            var dst = text.buffer();
            ref readonly var attribs = ref src.Attributes;
            var name = EmptyString;
            var locked = attribs.Locked;
            if(locked)
                name = text.remove(format(src.InstClass), "_LOCK").ToLower();
            else
                name = format(src.InstClass).ToLower();

            dst.Append(name);

            for(var i=0; i<src.OpCount; i++)
            {
                dst.Append(Chars.Underscore);
                ref readonly var op = ref src.Ops[i];
                dst.Append(identify(op));
            }

            if(locked)
                dst.Append("_locked");

            return dst.Emit();
        }

        [CmdOp("xed/check/modrm")]
        Outcome CheckModRm(CmdArgs args)
        {
            var spec = ModRmVar.init();
            Write(spec.Format());

            spec.Mod(0b10);
            var a0 = spec.Evaluate();
            Require.equal(a0.Mod(), (uint2)0b10);
            Write(spec.Format());

            spec.Reg(0b101);
            var a1 = spec.Evaluate();
            Require.equal(a1.Reg(), (uint3)0b101);
            Write(spec.Format());

            spec.Rm(0b011);
            var a2 = spec.Evaluate();
            Require.equal(a2.Rm(), (uint3)0b011);
            Write(spec.Format());

            return true;
        }
    }
}