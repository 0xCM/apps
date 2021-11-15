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

    partial struct Cmd
    {
        [MethodImpl(Inline), Op]
        public static string format(CmdOptionSpec src)
            => src.IsEmpty ? EmptyString : string.Format("{0,-32}:{1}", src.Name, src.Description);

        [Op]
        public static string format(in CmdScript src)
        {
            var dst = text.buffer();
            render(src, dst);
            return dst.Emit();
        }

        [Op]
        public static void render(CmdScript src, ITextBuffer dst)
        {
            var count = src.Length;
            var parts = src.View;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(parts,i).Format());
        }

        [Op]
        public static void render(ToolCmdArgs src, ITextBuffer dst)
        {
            var count = src.Count;
            for(var i=0u; i<count; i++)
            {
                dst.Append(format(src[i]));
                if(i != count - 1)
                    dst.Append(Space);
            }
        }

        /// <summary>
        /// Renders a specified option as text
        /// </summary>
        /// <param name="src">The data source</param>
        [Op]
        public static string format(in ToolCmdArg src)
            => string.Format(RP.Assign, src.Name, src.Value);

        /// <summary>
        /// Renders a specified option as text
        /// </summary>
        /// <param name="src">The data source</param>
        /// <typeparam name="T">The option value type</typeparam>
        [Op, Closures(Closure)]
        public static string format<T>(in ToolCmdArg<T> src)
            => string.Format(RP.Assign, src.Name, src.Value);

        [Op]
        public static string format(in ScriptExpr src)
            => format(src.Pattern, src.Variables.Storage);

        [Op]
        public static string format<K>(in ScriptExpr<K> src)
            where K : unmanaged
            => format(src.Pattern, src.Variables.Storage);

        [Op]
        public static ScriptExpr format(in ScriptPattern pattern, params CmdVar[] args)
            => string.Format(pattern.Content, args.Select(a => a.Format()));

        [Op, Closures(Closure)]
        public static ScriptExpr format<K>(in ScriptPattern<K> pattern, params CmdVar[] args)
            where K : unmanaged
                => string.Format(pattern.Content, args.Select(a => a.Format()));

        [Op, Closures(Closure)]
        public static ScriptExpr format<K>(in ScriptPattern pattern, params CmdVar<K>[] args)
            where K : unmanaged
                => string.Format(pattern.Content, args.Select(a => a.Format()));

        public static string format<K,T>(in ToolCmdArgs<K,T> src)
            where K : unmanaged
        {
            var dst = TextTools.buffer();
            var view = src.View;
            var count = view.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(skip(src,i).Format());
            return dst.Emit();
        }

        [Op]
        public static string format(in CmdFlagSpec src)
            => string.Format("{1,-34} {2}", src.Name, src.Description);

        public static string format(ArgPrefix src)
        {
            var len = src.Length;
            if(len == 0)
                return EmptyString;
            else if(len == 1)
            {
                Span<char> content = stackalloc char[1]{(char)src.C0};
                return new string(content);
            }
            else
            {
                Span<char> content = stackalloc char[2]{(char)src.C0, (char)src.C1};
                return new string(content);
            }
        }

        public static string format<T>(ICmd<T> src)
            where T : struct, ICmd<T>
        {
            var buffer = TextTools.buffer();
            buffer.AppendFormat("{0}{1}", src.CmdId, Chars.LParen);

            var fields = ClrFields.instance(typeof(T));
            if(fields.Length != 0)
                render(__makeref(src), fields, buffer);

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        [Op]
        static void render(TypedReference src, ReadOnlySpan<ClrFieldAdapter> fields, ITextBuffer dst)
        {
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,i);
                dst.AppendFormat(RP.Assign, field.Name, field.GetValueDirect(src));
                if(i != count - 1)
                    dst.Append(", ");
            }
        }

        [Op]
        public static string format(CmdVarValue src)
            => src.Content ?? EmptyString;

        [Op]
        public static void render(CmdTypeInfo src, ITextBuffer dst)
        {
            dst.Append(src.SourceType.Name);
            var fields = src.Fields.View;;
            var count = fields.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fields,count);
                dst.Append(string.Format(" | {0}:{1}", field.Name, field.FieldType.Name));
            }
        }

        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = TextTools.buffer();
            buffer.AppendFormat("{0}{1}", src.CmdId.Format(), Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                buffer.AppendFormat(RP.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }
    }
}