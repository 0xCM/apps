//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CsKeywords;
    using XF = ExprPatterns;
    using LK = ClrLiteralKind;
    using AK = ClrAccessKind;
    using MK = ClrModifierKind;
    using EK = ClrEnumKind;
    using IK = ClrIntegerKind;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static Label CsKeyword(this ClrEnumKind kind)
            => CsData.keyword(kind);

        [MethodImpl(Inline), Op]
        public static char ToChar(this SymNotKind src)
            => (char)src;

        [MethodImpl(Inline), Op]
        public static string Format(this SymNotKind src)
            => ((char)src).ToString();

        [Op]
        public static Label CsKeyword(this ClrLiteralKind src)
            => CsData.keyword(src);

        [Op]
        public static Label CsKeyword(this ClrAccessKind src)
            => CsData.keyword(src);

        [Op]
        public static Index<Label> CsKeywords(this ClrModifierKind src)
           => CsData.keywords(src);
    }

    public readonly struct CsData
    {
        static readonly Index<string> Data = new string[77]{"abstract","as","base","bool","break","byte","case","catch","char","checked","class","const","continue","decimal","default","delegate","do","double","else","enum","event","explicit","extern","false","finally","fixed","float","for","foreach","goto","if","implicit","in","int","interface","internal","is","lock","long","namespace","new","null","object","operator","out","override","params","private","protected","public","readonly","ref","return","sbyte","sealed","short","sizeof","stackalloc","static","string","struct","switch","this","throw","true","try","typeof","uint","ulong","unchecked","unsafe","ushort","using","virtual","void","volatile","while",};

        public static ReadOnlySpan<string> View => Data;

        static readonly ConstLookup<string,string> Lookup = Data.Select(x => (x, "@" + x)).ToDictionary();

        public static bool test(string src)
            => Lookup.ContainsKey(src);

        public static Identifier identifier(string src)
        {
            if(Lookup.Find(src, out var value))
            {
                return value;
            }
            else
                return src;
        }

        [Op]
        public static Label keyword(EK src)
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
        public static Label keyword(IK src)
            => src switch {
                IK.U8 => U8,
                IK.U16 => U16,
                IK.U32 => U32,
                IK.U64 => U64,
                IK.I8 => I8,
                IK.I16 => I16,
                IK.I32 => I32,
                IK.I64 => I64,
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

    [ApiHost]
    public readonly struct Terms
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Atom<K> atom<K>(K value)
            => new Atom<K>(value);

        [Op, Closures(Closure)]
        public static Atoms<K> concat<K>(Atoms<K> a, Atoms<K> b)
        {
            var ka = a.Count;
            var kb = b.Count;
            var k=0u;
            var length = a.Count + b.Count;
            var dst = alloc<K>(length);
            for(var i=0; i<ka; i++)
                seek(dst,k++) = a[i];
            for(var i=0; i<kb; i++)
                seek(dst,k++) = b[i];
            return default;
        }

        [MethodImpl(Inline), Op]
        public static ExprVar var(VarSymbol name)
            => new ExprVar(name);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NamedTerm<T> term<T>(Name name, T value, params ITerm[] terms)
            => new NamedTerm<T>(name,value,terms);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ResolvedVar<T> resolve<T>(IVar var, T value)
            => value;

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ResolvedVar<T> resolve<T>(IVarSymbol var, T value)
            => value;

        internal static string format(in Var src, bool bind = true)
            => bind ? src.Resolve().Format() : string.Format(XF.UntypedVar, src);

        internal static string format<T>(in Var<T> src, bool bind = true)
            => bind ? src.Value.Format() : string.Format(XF.TypedVar, src);

        internal static string format<K>(Atoms<K> src)
        {
            var dst = text.buffer();
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                if(i != 0)
                    dst.Append(" | ");
                dst.Append(src[i].Format());
            }
            return dst.Emit();
        }

        [Formatter]
        internal static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        [Op]
        internal static string format(VarContextKind vck, VarSymbol src)
            => string.Format(RP.pattern(vck), src.Name);
    }
}