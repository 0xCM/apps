//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;

    using LK = ClrLiteralKind;
    using AK = ClrAccessKind;
    using MK = ClrModifierKind;
    using EK = ClrEnumKind;

    [ApiHost, LiteralProvider]
    public readonly struct CsKeywords
    {
        public const string Const = "const";

        public const string Char = "char";

        public const string Enum = "enum";

        public const string Struct = "struct";

        public const string Case = "case";

        public const string Fixed = "fixed";

        public const string Static = "static";

        public const string I8 = "sbyte";

        public const string I16 = "short";

        public const string I32 = "int";

        public const string I64 = "long";

        public const string F32 = "float";

        public const string F64 = "double";

        public const string F128 = "decimal";

        public const string String = "string";

        public const string Bool = "bool";

        public const string U8 = "byte";

        public const string U16 = "ushort";

        public const string U32 = "uint";

        public const string U64 = "ulong";

        public const string Public = "public";

        public const string Private = "private";

        public const string Protected = "protected";

        public const string Internal = "internal";

        public const string ProtectedInternal = "protected internal";

        public const string ReadOnly = "readonly";

        [Op]
        public static Label keyword(AK kind)
            => kind switch{
                AK.Public => Public,
                AK.Private => Private,
                AK.ProtectedInternal => ProtectedInternal,
                AK.Protected => Protected,
                AK.Internal => Internal,
                _ => Label.Empty
            };

        [Op]
        public static Index<Label> keywords(MK kind)
        {
            var dst = core.list<Label>();
            if((MK.Const & kind) != 0)
                dst.Add(Const);
            if((MK.ReadOnly & kind) != 0)
                dst.Add(ReadOnly);
            if((MK.Static & kind) != 0)
                dst.Add(Static);

            return dst.ToArray();
        }

        [Op]
        public static Label keyword(ClrEnumKind src)
            => src switch {
                EK.U8 => U8,
                EK.U16 => U16,
                EK.U32 => U32,
                EK.U64 => U64,
                EK.I8 => I8,
                EK.I16 => I16,
                EK.I32 => I32,
                EK.I64 => I64,
                _ => EmptyString
            };

        [Op]
        public static Label keyword(LK kind)
            => kind switch
            {
                LK.C16 => Char,
                LK.F128 => F128,
                LK.F32 => F32,
                LK.F64 => F64,
                LK.I8 => I8,
                LK.I16 => I16,
                LK.I32 => I32,
                LK.I64 => I64,
                LK.String => String,
                LK.U1 => Bool,
                LK.U16 => U16,
                LK.U32 => U32,
                LK.U64 => U64,
                LK.U8 => U8,
                _ => Label.Empty
            };

        /// <summary>
        /// For a system-defined type, returns the C#-specific keyword for the type if it has one;
        /// otherwise, returns an empty string
        /// </summary>
        /// <param name="src">The type to test</param>
        [Op]
        public static string keyword(Type src)
        {
            if(src.IsSByte())
                return I8;
            else if(src.IsByte())
                return U8;
            else if(src.IsUInt16())
                return U16;
            else if(src.IsInt16())
                return "short";
            else if(src.IsInt32())
                return "int";
            else if(src.IsUInt32())
                return "uint";
            else if(src.IsInt64())
                return "long";
            else if(src.IsUInt64())
                return "ulong";
            else if(src.IsSingle())
                return "float";
            else if(src.IsDouble())
                return "double";
            else if(src.IsDecimal())
                return "decimal";
            else if(src.IsBool())
                return "bool";
            else if(src.IsChar())
                return "char";
            else if(src.IsString())
                return "string";
            else if(src.IsVoid())
                return "void";
            else if(src.IsDynamic())
                return "dynamic";
            else if(src.IsObject())
                return "object";
            else
                return EmptyString;
        }
    }
}