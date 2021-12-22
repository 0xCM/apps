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
    using static XedModels.SAMode;

    using T = XedModels.DataType;
    using W = DataWidth;

    [ApiHost]
    public readonly partial struct XedModels
    {
        internal const string xed = nameof(xed);

        public static AttributeKind[] attributes(string src)
        {
            var parts = src.SplitClean(Chars.Colon).ToReadOnlySpan();
            var count = parts.Length;
            if(count == 0)
                return default;

            var counter = 0u;
            var dst = span<AttributeKind>(count);
            for(var i=0; i<count; i++)
            {
                ref var target = ref seek(dst,i);
                var result = DataParser.eparse(skip(parts,i), out target);
                if(result)
                {
                    if(target != 0)
                        counter++;
                }
                else
                    return default;
            }
            return slice(dst,0,counter).ToArray();
        }

        public static Outcome parse(TextLine src, out XedFormImport dst)
        {
            const char Delimiter = Chars.Pipe;

            dst = default;
            var result = Tables.cells(src, Delimiter, XedFormImport.FieldCount, out var cells);
            if(result.Fail)
                return result;
            var j=0;

            result = DataParser.parse(skip(cells,j++), out dst.Index);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out IFormType ft);
            if(result.Fail)
                return result;
            else
                dst.Form = ft;

            result = DataParser.eparse(skip(cells,j++), out dst.Class);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Category);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.IsaKind);
            if(result.Fail)
                return result;

            result = DataParser.eparse(skip(cells,j++), out dst.Extension);
            if(result.Fail)
                return result;

            dst.Attributes = attributes(skip(cells,j++)).Delimit(fence:Fencing.Embraced);

            return result;
        }

        public static Outcome parse(in XedFormSource src, ushort seq, out XedFormImport dst)
        {
            var result = Outcome.Success;
            dst.Index = seq;
            result = DataParser.eparse(src.Class, out dst.Class);
            result = DataParser.eparse(src.Extension, out dst.Extension);
            result = DataParser.eparse(src.Category, out dst.Category);
            result = DataParser.eparse(src.Form, out IFormType ft);
            dst.Form = ft;
            result = DataParser.eparse(src.IsaSet, out dst.IsaKind);
            dst.Attributes = attributes(src.Attributes);
            return true;
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
        public static DataWidth width(DataType src)
            => src switch {
                T.I1 => W.W1,
                T.I8 => W.W8,
                T.I16 => W.W16,
                T.I32 => W.W32,
                T.I64 => W.W64,
                T.U8 => W.W8,
                T.U16 => W.W16,
                T.U32 => W.W32,
                T.U64 => W.W64,
                T.U128 => W.W128,
                T.U256 => W.W256,
                T.F32 => W.W32,
                T.F64 => W.W64,
                T.F80 => W.W80,
                T.B80 => W.W80,
                _ => 0
            };

        [Op]
        public static RegId ArAX(EASZ easz)
            => easz switch
            {
                easz16 => AX,
                easz32 => EAX,
                easz64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArBX(EASZ easz)
            => easz switch
            {
                easz16 => BX,
                easz32 => EBX,
                easz64 => RAX,
                _ => 0
            };

        [Op]
        public static RegId ArCX(EASZ easz)
            => easz switch
            {
                easz16 => CX,
                easz32 => ECX,
                easz64 => RCX,
                _ => 0
            };

        [Op]
        public static RegId ArDX(EASZ easz)
            => easz switch
            {
                easz16 => DX,
                easz32 => EDX,
                easz64 => RDX,
                _ => 0
            };

        [Op]
        public static RegId ArSI(EASZ easz)
            => easz switch
            {
                easz16 => SI,
                easz32 => ESI,
                easz64 => RSI,
                _ => 0
            };

        [Op]
        public static RegId ArDI(EASZ easz)
            => easz switch
            {
                easz16 => DI,
                easz32 => EDI,
                easz64 => RDI,
                _ => 0
            };

        [Op]
        public static RegId ArSP(EASZ easz)
            => easz switch
            {
                easz16 => SP,
                easz32 => ESP,
                easz64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId ArBP(EASZ easz)
            => easz switch
            {
                easz16 => BP,
                easz32 => EBP,
                easz64 => RBP,
                _ => 0
            };

        [Op]
        public static RegId SrSP(SAMode easz)
            => easz switch
            {
                smode16 => SP,
                smode32 => ESP,
                smode64 => RSP,
                _ => 0
            };

        [Op]
        public static RegId SrBP(SAMode easz)
            => easz switch
            {
                smode16 => BP,
                smode32 => EBP,
                smode64 => RBP,
                _ => 0
            };
    }
}