//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;
    using static XedRegId;
    using static XedModels.EASZ;
    using static XedModels.SMode;

    partial struct XedModels
    {
        [MethodImpl(Inline), Op]
        public static bool rex(in OpState src, out RexPrefix dst)
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
        public static bool scale(in OpState src, uint4 dst)
        {
            if(src.scale != 0)
            {
                dst = src.scale;
                return true;
            }
            {
                dst = default;
                return false;
            }
        }

        [MethodImpl(Inline), Op]
        public static bool modrm(in OpState src, out ModRm dst)
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

        public static ConstLookup<FieldKind,TypeSpec> OpKindTypes()
        {
            var fields = typeof(OpState).PublicInstanceFields();
            var count = fields.Length;
            var dst = dict<FieldKind,TypeSpec>();
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                var tag = field.Tag<OperandKindAttribute>();
                if(tag)
                {
                    dst.TryAdd(tag.Value.Kind, TypeSyntax.infer(field.FieldType));
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