//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;
    using static Root;
    using static core;
    using static XedRegId;
    using static XedModels.EASZ;
    using static XedModels.SMode;

    partial struct XedModels
    {
        public static ImmOp imm(in OperandState state, in AsmHexCode code)
        {
            var dst = ImmOp.Empty;
            if(state.imm0)
            {
                var size = NativeSize.code(state.imm_width);
                var signed = state.imm0signed;
                var pos = state.pos_imm;

                switch(size)
                {
                    case NativeSizeCode.W8:
                        dst = ImmOp.define(size,signed, code[pos]);
                    break;
                    case NativeSizeCode.W16:
                        dst = ImmOp.define(size, signed,slice(code.Bytes,pos, 2).TakeUInt16());
                    break;
                    case NativeSizeCode.W32:
                        dst = ImmOp.define(size, signed, slice(code.Bytes,pos, 4).TakeUInt32());
                    break;
                    case NativeSizeCode.W64:
                        dst = ImmOp.define(size, signed, slice(code.Bytes,pos, 8).TakeUInt64());
                    break;
                }
            }
            return dst;
        }

        [Op]
        public static long disp(in OperandState state, in AsmHexCode code)
        {
            var val = Disp.Zero;
            var _val = 0L;
            if(state.disp_width != 0)
            {
                var width = state.disp_width;
                var length = width/8;
                var offset = state.pos_disp;
                switch(length)
                {
                    case 1:
                        val = new Disp((sbyte)code[offset], width);
                        _val = (sbyte)code[offset];
                    break;
                    case 2:
                        val = new Disp(slice(code.Bytes, offset, length).TakeInt16(), width);
                        _val = slice(code.Bytes, offset, length).TakeInt16();
                    break;
                    case 4:
                        val = new Disp(slice(code.Bytes, offset, length).TakeInt32(), width);
                        _val = slice(code.Bytes, offset, length).TakeInt32();
                    break;
                    case 8:
                        val = new Disp(slice(code.Bytes, offset, length).TakeInt64(), width);
                        _val = slice(code.Bytes, offset, length).TakeInt64();
                    break;
                }
            }

            return _val;
        }

        [MethodImpl(Inline), Op]
        public static bool rex(in OperandState src, out RexPrefix dst)
        {
            if(src.rex)
            {
                dst = RexPrefix.init();
                dst.W = src.rexw;
                dst.R = src.rexr;
                dst.X = src.rexx;
                dst.B= src.rexb;
                return true;
            }
            else
            {
                dst = RexPrefix.Empty;
                return false;
            }
        }

        [MethodImpl(Inline), Op]
        public static bool sib(in OperandState src, out Sib dst)
        {
            if(src.has_sib)
            {
                dst = Sib.init();
                dst.Base = src.sibbase;
                dst.Index = src.sibindex;
                dst.Scale = src.sibscale;
                return true;
            }
            else
            {
                dst = Sib.Empty;
                return false;
            }
        }

        [MethodImpl(Inline), Op]
        public static bool modrm(in OperandState src, out ModRm dst)
        {
            if(src.has_modrm)
            {
                dst = ModRm.init();
                dst.Mod(src.mod);
                dst.Reg(src.reg);
                dst.Rm(src.rm);
                return true;
            }
            else
            {
                dst = ModRm.Empty;
                return false;
            }
        }

        public static uint widths(EASZ src)
            => src switch
            {
                EASZ.EASZ16 => 16,
                EASZ.EASZ32 => 32,
                EASZ.EASZ64 => 64,
                EASZ.EASZNot16 => 32 | (64 << 8),
                _ => 0,
            };

        public static uint modes(EOSZ src)
            => src switch
            {
                EOSZ.EOSZ8 => 0,
                EOSZ.EOSZ16 => 1,
                EOSZ.EOSZ32 => 2,
                EOSZ.EOSZ64 => 3,
                EOSZ.EOSZNot16 => 0 | (2 << 8) | (3 << 16),
                EOSZ.EOSZNot64 => 0 | (1 << 8) | (2 << 16),
                _ => 0,
            };

        public static uint widths(EOSZ src)
            => src switch
            {
                EOSZ.EOSZ8 => 8,
                EOSZ.EOSZ16 => 16,
                EOSZ.EOSZ32 => 32,
                EOSZ.EOSZ64 => 64,
                EOSZ.EOSZNot16 => 8 | (32 << 8) | (64 << 16),
                EOSZ.EOSZNot64 => 8 | (16 << 8) | (32 << 16),
                _ => 0,
            };

        public static BCastSpec spec(BCastKind kind)
        {
            var dst = BCastSpec.Empty;
            var id = (uint5)(byte)kind;
            switch(kind)
            {
                case BCastKind.BCast_1TO16_8:
                    dst = BCastSpec.define(id, BCastClass.BCast8, Symbols.expr(BCast8Kind.BCast_1TO16_8).Format(), 1, 16);
                break;

                case BCastKind.BCast_1TO32_8:
                    dst = BCastSpec.define(id, BCastClass.BCast8, Symbols.expr(BCast8Kind.BCast_1TO32_8).Format(), 1, 32);
                break;

                case BCastKind.BCast_1TO64_8:
                    dst = BCastSpec.define(id, BCastClass.BCast8, Symbols.expr(BCast8Kind.BCast_1TO64_8).Format(), 1, 64);
                break;

                case BCastKind.BCast_1TO2_8:
                    dst = BCastSpec.define(id, BCastClass.BCast8, Symbols.expr(BCast8Kind.BCast_1TO2_8).Format(), 1, 8);
                break;

                case BCastKind.BCast_1TO4_8:
                    dst = BCastSpec.define(id, BCastClass.BCast8, Symbols.expr(BCast8Kind.BCast_1TO4_8).Format(), 1, 4);
                break;

                case BCastKind.BCast_1TO8_8:
                    dst = BCastSpec.define(id, BCastClass.BCast8, Symbols.expr(BCast8Kind.BCast_1TO8_8).Format(), 1, 8);
                break;

                case BCastKind.BCast_1TO8_16:
                    dst = BCastSpec.define(id, BCastClass.BCast16, Symbols.expr(BCast16Kind.BCast_1TO8_16).Format(), 1, 8);
                break;

                case BCastKind.BCast_1TO16_16:
                    dst = BCastSpec.define(id, BCastClass.BCast16, Symbols.expr(BCast16Kind.BCast_1TO16_16).Format(), 1, 16);
                break;

                case BCastKind.BCast_1TO32_16:
                    dst = BCastSpec.define(id, BCastClass.BCast16, Symbols.expr(BCast16Kind.BCast_1TO32_16).Format(), 1, 32);
                break;

                case BCastKind.BCast_1TO2_16:
                    dst = BCastSpec.define(id, BCastClass.BCast16, Symbols.expr(BCast16Kind.BCast_1TO2_16).Format(), 1, 2);
                break;

                case BCastKind.BCast_1TO4_16:
                    dst = BCastSpec.define(id, BCastClass.BCast16, Symbols.expr(BCast16Kind.BCast_1TO4_16).Format(), 1, 4);
                break;

                case BCastKind.BCast_1TO16_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, Symbols.expr(BCast32Kind.BCast_1TO16_32).Format(), 1, 16);
                break;

                case BCastKind.BCast_4TO16_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, Symbols.expr(BCast32Kind.BCast_4TO16_32).Format(), 4, 16);
                break;

                case BCastKind.BCast_1TO8_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, Symbols.expr(BCast32Kind.BCast_1TO8_32).Format(), 1, 8);
                break;

                case BCastKind.BCast_4TO8_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, Symbols.expr(BCast32Kind.BCast_4TO8_32).Format(), 4, 8);
                break;

                case BCastKind.BCast_2TO16_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, default, 2, 16);
                break;

                case BCastKind.BCast_8TO16_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, default, 8, 16);
                break;

                case BCastKind.BCast_1TO4_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, default, 1, 4);
                break;

                case BCastKind.BCast_2TO4_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, default, 2, 4);
                break;

                case BCastKind.BCast_2TO8_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, default, 2, 8);
                break;

                case BCastKind.BCast_1TO2_32:
                    dst = BCastSpec.define(id, BCastClass.BCast32, default, 1, 2);
                break;

                case BCastKind.BCast_1TO8_64:
                    dst = BCastSpec.define(id, BCastClass.BCast64, default, 1, 8);
                break;

                case BCastKind.BCast_4TO8_64:
                    dst = BCastSpec.define(id, BCastClass.BCast64, default, 4, 8);
                break;

                case BCastKind.BCast_2TO8_64:
                    dst = BCastSpec.define(id, BCastClass.BCast64, default, 2, 8);
                break;

                case BCastKind.BCast_1TO2_64:
                    dst = BCastSpec.define(id, BCastClass.BCast64, default, 1, 2);
                break;

                case BCastKind.BCast_1TO4_64:
                    dst = BCastSpec.define(id, BCastClass.BCast64, default, 1, 4);
                break;

                case BCastKind.BCast_2TO4_64:
                    dst = BCastSpec.define(id, BCastClass.BCast64, default, 2, 64);
                break;
            }

            return dst;
        }

        public static ConstLookup<OperandKind,TypeSpec> OpKindTypes()
        {
            var fields = typeof(OperandState).PublicInstanceFields();
            var count = fields.Length;
            var dst = dict<OperandKind,TypeSpec>();
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tag = field.Tag<OperandKindAttribute>();
                if(tag)
                {
                    var spec = TypeSyntax.infer(field.FieldType);
                    dst.TryAdd(tag.Value.Kind, spec);
                }
            }
            return dst;
        }

        /// <summary>
        /// Creates a <see cref='AttributeVector'/> from a <see cref='AttributeKind'> sequence
        /// </summary>
        /// <param name="src">The source attributes</param>
        [MethodImpl(Inline), Op]
        public static AttributeVector vector(ReadOnlySpan<AttributeKind> src)
        {
            var length = min(src.Length, 8);
            var data = 0ul;
            if(length != 0)
            {
                ref var dst = ref uint8(ref data);
                ref readonly var a = ref first(src);
                for(byte i=0; i<length; i++)
                    seek(dst,i) = (byte)skip(a,i);
            }
            return new AttributeVector(data);
        }

        [Op]
        public static XedRegId ArAX(EASZ easz)
            => easz switch
            {
                EASZ16 => AX,
                EASZ32 => EAX,
                EASZ64 => RAX,
                _ => 0
            };

        [Op]
        public static XedRegId ArBX(EASZ easz)
            => easz switch
            {
                EASZ16 => BX,
                EASZ32 => EBX,
                EASZ64 => RAX,
                _ => 0
            };

        [Op]
        public static XedRegId ArCX(EASZ easz)
            => easz switch
            {
                EASZ16 => CX,
                EASZ32 => ECX,
                EASZ64 => RCX,
                _ => 0
            };

        [Op]
        public static XedRegId ArDX(EASZ easz)
            => easz switch
            {
                EASZ16 => DX,
                EASZ32 => EDX,
                EASZ64 => RDX,
                _ => 0
            };

        [Op]
        public static XedRegId ArSI(EASZ easz)
            => easz switch
            {
                EASZ16 => SI,
                EASZ32 => ESI,
                EASZ64 => RSI,
                _ => 0
            };

        [Op]
        public static XedRegId ArDI(EASZ easz)
            => easz switch
            {
                EASZ16 => DI,
                EASZ32 => EDI,
                EASZ64 => RDI,
                _ => 0
            };

        [Op]
        public static XedRegId ArSP(EASZ easz)
            => easz switch
            {
                EASZ16 => SP,
                EASZ32 => ESP,
                EASZ64 => RSP,
                _ => 0
            };

        [Op]
        public static XedRegId ArBP(EASZ easz)
            => easz switch
            {
                EASZ16 => BP,
                EASZ32 => EBP,
                EASZ64 => RBP,
                _ => 0
            };

        [Op]
        public static XedRegId SrSP(SMode easz)
            => easz switch
            {
                SMode16 => SP,
                SMode32 => ESP,
                SMode64 => RSP,
                _ => 0
            };

        [Op]
        public static XedRegId SrBP(SMode easz)
            => easz switch
            {
                SMode16 => BP,
                SMode32 => EBP,
                SMode64 => RBP,
                _ => 0
            };
    }
}