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

    using XF = ExprPatterns;

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

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Constant<T> constant<T>(T value)
            => new Constant<T>(value);

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

        public static string format<T>(Constant<T> src)
        {
            var pattern = EmptyString;
            if(typeof(T) == typeof(string))
                pattern = "\"{0}\"";
            else if(typeof(T) == typeof(char))
                pattern = "'{0}'";
            else if(typeof(T) == typeof(uint))
                pattern = "{0}u";
            else if(typeof(T) == typeof(ulong))
                pattern = "{0}ul";
            else if(typeof(T) == typeof(long))
                pattern = "{0}L";
            else
                pattern = "{0}";

            return string.Format(pattern, src.Value);
        }

        [Formatter]
        internal static string format(VarSymbol src)
            => format(VarContextKind.Workflow, src);

        [Op]
        internal static string format(VarContextKind vck, VarSymbol src)
            => string.Format(RP.pattern(vck), src.Name);


    }
}