//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;


    using static NativeOpMods;
    using static core;

    [ApiHost]
    public readonly struct NativeSigs
    {
        [MethodImpl(Inline), Op]
        public static NativeSigSpec spec(string scope, string name, NativeType ret, params NativeOperandSpec[] ops)
            => new NativeSigSpec(scope, name, ret, ops);

        [MethodImpl(Inline), Op]
        public static NativeSigSpec spec(string name, NativeType ret, params NativeOperandSpec[] ops)
            => new NativeSigSpec(EmptyString, name, ret, ops);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec op(string name, NativeType type)
            => new NativeOperandSpec(name,type);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec op(string name, NativeType type, NativeOpMod mod)
            => new NativeOperandSpec(name, type, mod);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec ptr(string name, NativeType type)
            => op(name,type, Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @const(string name, NativeType type)
            => op(name,type, Const);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @constptr(string name, NativeType type)
            => op(name,type, Const | Pointer);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @ref(string name, NativeType type)
            => op(name,type, Ref);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @in(string name, NativeType type)
            => op(name,type, NativeOpMods.In);

        [MethodImpl(Inline), Op]
        public static NativeOperandSpec @out(string name, NativeType type)
            => op(name,type, NativeOpMods.Out);

        static sbyte patternidx(in NativeOpMod mod)
        {
            sbyte index = -1;
            if(mod.IsEmpty)
                index = 0;
            if(mod.IsConstPointer)
                index = 1;
            else if(mod.IsRefPointer)
                index = 2;
            else if(mod.IsOutPointer)
                index = 3;
            else if(mod.IsPointer)
                index = 4;
            else if(mod.IsOut)
                index = 5;
            else if(mod.IsIn)
                index = 6;
            else if(mod.IsConst)
                index = 7;
            return index;
        }

        public static string format(in NativeOperand src, SigFormatStyle style = default)
        {
            var mod = src.Mod;
            var index = patternidx(src.Mod);
            if(index < 0)
                return RP.Error;

            var pattern = EmptyString;
            switch(style)
            {
                case SigFormatStyle.Functional:
                    pattern = FunctionalFormats[index];
                break;
                case SigFormatStyle.C:
                case SigFormatStyle.CSharp:
                    pattern = CFormats[index];
                break;
            }

            if(text.empty(pattern))
                return RP.Error;

            return string.Format(pattern, src.Type, src.Name);
        }

        public static string format(in NativeOperandSpec src, SigFormatStyle style = default)
        {
            var mod = src.Mod;
            var index = patternidx(src.Mod);
            if(index < 0)
                return RP.Error;

            var pattern = EmptyString;
            switch(style)
            {
                case SigFormatStyle.Functional:
                    pattern = FunctionalFormats[index];
                break;
                case SigFormatStyle.C:
                case SigFormatStyle.CSharp:
                    pattern = CFormats[index];
                break;
            }

            if(text.empty(pattern))
                return RP.Error;

            return string.Format(pattern, src.Type, src.Name);
        }

        static string FormatFunctional(in NativeSigSpec src)
        {
            var dst = text.buffer();
            if(empty(src.Scope))
                dst.Append(src.Name);
            else
                dst.AppendFormat("{0}::{1}:", src.Scope, src.Name);

            var operands = src.Operands;
            var opcount = operands.Count;
            for(var i=0; i<opcount; i++)
            {
                ref readonly var op = ref operands[i];
                if(i == 0)
                    dst.Append(op.Format(SigFormatStyle.Functional));
                else
                    dst.AppendFormat(" -> {0}", op.Format(SigFormatStyle.Functional));
            }

            dst.AppendFormat(" -> {0}", src.ReturnType.Format());
            return dst.Emit();
        }


        static string FormatFunctional(in NativeSig src)
        {
            var dst = text.buffer();
            dst.AppendFormat("{0}::{1}:", src.Scope, src.Name);

            ref readonly var opcount = ref src.OperandCount;
            for(var i=0; i<opcount; i++)
            {
                ref readonly var op = ref src[i];
                if(i == 0)
                    dst.Append(op.Format(SigFormatStyle.Functional));
                else
                    dst.AppendFormat(" -> {0}", op.Format(SigFormatStyle.Functional));
            }

            dst.AppendFormat(" -> {0}", src.Return.Type.Format());
            return dst.Emit();
        }

        static string FormatC(in NativeSig src)
        {
            var dst = text.buffer();
            dst.AppendFormat("{0} {1}(", src.Return.Type, src.Name);

            ref readonly var opcount = ref src.OperandCount;
            for(var i=0; i<opcount; i++)
            {
                ref readonly var op = ref src[i];
                if(i==0)
                    dst.Append(op.Format(SigFormatStyle.C));
                else
                    dst.AppendFormat(", {0}", op.Format(SigFormatStyle.C));
            }

            dst.Append(");");
            return dst.Emit();
        }

        static string FormatC(in NativeSigSpec src)
        {
            var dst = text.buffer();
            dst.AppendFormat("{0} {1}(", src.ReturnType, src.Name);

            var operands = src.Operands;
            var opcount = operands.Count;
            for(var i=0; i<opcount; i++)
            {
                ref readonly var op = ref operands[i];
                if(i==0)
                    dst.Append(op.Format(SigFormatStyle.C));
                else
                    dst.AppendFormat(", {0}", op.Format(SigFormatStyle.C));
            }

            dst.Append(");");
            return dst.Emit();
        }

        public static string format(in NativeSigSpec src, SigFormatStyle style = default)
        {
            switch(style)
            {
                case SigFormatStyle.Functional:
                    return FormatFunctional(src);
                case SigFormatStyle.C:
                case SigFormatStyle.CSharp:
                    return FormatC(src);
                default:
                    return RP.Error;
            }
        }

        public static string format(in NativeSig src, SigFormatStyle style = default)
        {
            switch(style)
            {
                case SigFormatStyle.Functional:
                    return FormatFunctional(src);
                case SigFormatStyle.C:
                case SigFormatStyle.CSharp:
                    return FormatC(src);
                default:
                    return RP.Error;
            }
        }


        static Index<string> FunctionalFormats = new string[]{
            "{1}:{0}",          // default
            "{1}:const {0}*",  // const ptr
            "{1}:ref {0}*",     // ref ptr
            "{1}:out {0}*",     // out ptr
            "{1}:{0}*",         // ptr
            "{1}:out {0}",      // out
            "{1}:in {0}",       // in
            "{1}:const {0}",   // const
            };


        static Index<string> CFormats = new string[]{
            "{0} {1}",          // default
            "const {0}* {1}",   // const ptr
            "ref {0}* {1}",     // ref ptr
            "out {0}* {1}",     // out ptr
            "{0}* {1}",         // ptr
            "out {0} {1}",      // out
            "in {0} {1}",       // in
            "const {0} {1}",    // const
            };
    }
}