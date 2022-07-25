//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Arrays;
    using static Spans;

    public class ToolCmd
    {
        const NumericKind Closure = UnsignedInts;

        public static async Task<int> exec(ToolCmdSpec cmd, ToolCmdContext context, Action<string> status, Action<string> error)
        {
            var info = new ProcessStartInfo
            {
                FileName = cmd.Tool.Format(),
                Arguments = cmd.Format(),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true
            };

            var process = new Process {StartInfo = info};

            if (!context.WorkingDir.IsNonEmpty)
                process.StartInfo.WorkingDirectory = context.WorkingDir.Name;

            iter(context.EnvVars, v => process.StartInfo.Environment.Add(v.Name, v.Value));
            process.OutputDataReceived += (s,d) => status(d.Data ?? EmptyString);
            process.ErrorDataReceived += (s,d) => error(d.Data ?? EmptyString);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            return await wait(process);

            static async Task<int> wait(Process process)
            {
                return await Task.Run(() => {
                    process.WaitForExit();
                    return Task.FromResult(process.ExitCode);
                });
            }
        }

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(IToolWs ws, Actor tool, params string[] src)
            => new ToolCmdLine(tool, CmdScripts.cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(IToolWs ws, Actor tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, CmdScripts.cmdline(src));

        [MethodImpl(Inline), Op]
        public static ToolScript script(IToolWs ws, Actor tool, ScriptId script, CmdVars vars)
            => new ToolScript(ws, tool, script, vars);

        [Op, Closures(UInt64k)]
        public static ToolCmdSpec spec<T>(Actor tool, in T spec)
            where T : struct
        {
            var t = typeof(T);
            var fields = Clr.fields(t);
            var count = fields.Length;
            var reflected = sys.alloc<ClrFieldValue>(count);
            ClrFields.values(spec, fields, reflected);
            var buffer = sys.alloc<ToolCmdArg>(count);
            var target = span(buffer);
            var source = @readonly(reflected);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(source,i);
                seek(target,i) = new ToolCmdArg(fv.Field.Name, fv.Value?.ToString() ?? EmptyString);
            }
            return new ToolCmdSpec(tool, CmdTypes.identify(t), buffer);
        }

        public static string format<K,T>(in ToolCmdArgs<K,T> src)
            where K : unmanaged
        {
            var dst = text.buffer();
            var view = src.View;
            var count = view.Length;
            for(var i=0; i<count; i++)
                dst.AppendLine(src[i].Format());
            return dst.Emit();
        }

        [Op]
        public static void render(ToolCmdArgs src, ITextBuffer dst)
        {
            var count = src.Count;
            for(var i=0u; i<count; i++)
            {
                dst.Append(src[i].Format());
                if(i != count - 1)
                    dst.Append(Space);
            }
        }

        public static string format(IToolCmd src)
        {
            var count = src.Args.Count;
            var buffer = text.buffer();
            buffer.AppendFormat("{0}{1}", src.CmdName.Format(), Chars.LParen);
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src.Args[i];
                buffer.AppendFormat(RpOps.Assign, arg.Name, arg.Value);
                if(i != count - 1)
                    buffer.Append(", ");
            }

            buffer.Append(Chars.RParen);
            return buffer.Emit();
        }

        public static ToolCmdArgs args<T>(T src)
            where T : struct, IToolCmd
        {
            var fields = typeof(T).DeclaredInstanceFields();
            return fields.Select(f => new ToolCmdArg(f.Name, f.GetValue(src)?.ToString() ?? EmptyString));
        }

        [Op]
        public static bool arg(ToolCmdArgs src, string name, out ToolCmdArg dst)
        {
            var count = src.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var arg = ref src[i];
                if(string.Equals(arg.Name, name, NoCase))
                {
                    dst=arg;
                    return true;
                }
            }
            dst = ToolCmdArg.Empty;
            return false;
        }

        [MethodImpl(Inline), Op]
        public static CmdFlag disable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.Off);

        [MethodImpl(Inline), Op]
        public static CmdFlag enable(CmdFlagSpec flag)
            => new CmdFlag(flag.Name, bit.On);
    }
}