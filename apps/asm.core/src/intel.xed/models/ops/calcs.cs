//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;
    using static XedModels.RegId;
    using static XedModels.EASZ;
    using static XedModels.SMode;

    partial struct XedModels
    {
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
        public static RegId ArAX(EASZ easz)
            => easz switch
            {
                EaMode16 => AX,
                EaMode32 => EAX,
                EaMode64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArBX(EASZ easz)
            => easz switch
            {
                EaMode16 => BX,
                EaMode32 => EBX,
                EaMode64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArCX(EASZ easz)
            => easz switch
            {
                EaMode16 => CX,
                EaMode32 => ECX,
                EaMode64 => RCX,
                _ => 0
            };

        [Op]
        public static RegId ArDX(EASZ easz)
            => easz switch
            {
                EaMode16 => DX,
                EaMode32 => EDX,
                EaMode64 => RDX,
                _ => 0
            };

        [Op]
        public static RegId ArSI(EASZ easz)
            => easz switch
            {
                EaMode16 => SI,
                EaMode32 => ESI,
                EaMode64 => RSI,
                _ => 0
            };

        [Op]
        public static RegId ArDI(EASZ easz)
            => easz switch
            {
                EaMode16 => DI,
                EaMode32 => EDI,
                EaMode64 => RDI,
                _ => 0
            };

        [Op]
        public static RegId ArSP(EASZ easz)
            => easz switch
            {
                EaMode16 => SP,
                EaMode32 => ESP,
                EaMode64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId ArBP(EASZ easz)
            => easz switch
            {
                EaMode16 => BP,
                EaMode32 => EBP,
                EaMode64 => RBP,
                _ => 0
            };

        [Op]
        public static RegId SrSP(SMode easz)
            => easz switch
            {
                SMode16 => SP,
                SMode32 => ESP,
                SMode64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId SrBP(SMode easz)
            => easz switch
            {
                SMode16 => BP,
                SMode32 => EBP,
                SMode64 => RBP,
                _ => 0
            };
    }
}