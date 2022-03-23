//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    using I = XedModels.OpAspectIndex;

    partial class XedDisasm
    {
        public struct DisasmOpSpec
        {
            public static DisasmOpSpec from(in DisasmOpDetail src)
            {
                var spec = new DisasmOpSpec(src.OpName);
                var kind = OpAspectKind.None;
                var opkind = XedRules.opkind(src.OpName);
                ref readonly var opinfo = ref src.OpInfo;
                ref readonly var width = ref src.OpWidth;

                spec[I.Index] = opinfo.Index;
                kind |= OpAspectKind.Index;

                if(src.Action != 0)
                {
                    spec[I.Action] = src.Action;
                    kind |= OpAspectKind.Action;
                }

                if(opinfo.Visiblity.IsNonEmpty)
                {
                    spec[I.Visibilty] = opinfo.Visiblity;
                    kind |= OpAspectKind.Visibilty;
                }

                if(width.IsNonEmpty)
                {
                    spec[I.Width] = width.Code;
                    kind |= OpAspectKind.Width;
                }

                if(width.CellType.IsNonEmpty)
                {
                    spec[I.EType] = width.CellType;
                    kind |= OpAspectKind.EType;
                }

                if(opinfo.OpType != 0)
                {
                    spec[I.Type] = opinfo.OpType;
                    kind |= OpAspectKind.Type;
                }

                if(opinfo.Selector.IsNonEmpty)
                {
                    if(XedParsers.parse(opinfo.Selector, out XedRegId reg))
                    {
                        spec[I.Reg] = reg;
                        kind |= OpAspectKind.Reg;
                    }
                    else if(XedParsers.parse(opinfo.Selector, out NontermKind dst))
                    {
                        spec[I.NT] = dst;
                        kind |= OpAspectKind.NT;
                    }
                }

                spec.AspectKind = kind;

                return spec;
            }

            ByteBlock32 Data;

            [MethodImpl(Inline)]
            public DisasmOpSpec(OpName opname)
            {
                var data = ByteBlock32.Empty;
                data[0] = (byte)opname;
                Data = data;
            }

            ref OpAspectKind AspectKind
            {
                [MethodImpl(Inline)]
                get => ref @as<OpAspectKind>(Data[1]);
            }

            ref OpAspect this[OpAspectIndex i]
            {
                [MethodImpl(Inline)]
                get => ref @as<OpAspect>(seek(Data[3],(byte)i));
            }

            public OpKind OpKind
            {
                [MethodImpl(Inline)]
                get => opkind(OpName);
            }

            public ref readonly OpName OpName
            {
                [MethodImpl(Inline)]
                get => ref @as<OpName>(Data.First);
            }

            public ref readonly OpAspectKind Kinds
            {
                [MethodImpl(Inline)]
                get => ref @as<OpAspectKind>(Data[1]);
            }
        }
    }
}