//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;
    using static Arrays;
    using static Spans;

    [ApiHost]
    public class CmdScripts
    {
        const NumericKind Closure = UnsignedInts;

        [MethodImpl(Inline), Op]
        public static ToolScript script(FS.FilePath script, CmdVars vars)
            => new ToolScript(script, vars);

        public static CmdLine cmd(string spec)
            => string.Format($"cmd.exe /c {spec}");

        public static CmdLine pwsh(FS.FilePath src, string args)
            => string.Format("pwsh.exe {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine cmd(FS.FilePath src, string args)
            => string.Format("cmd.exe /c {0} {1}", src.Format(PathSeparator.BS), args);

        public static CmdLine pwsh(FS.FilePath src)
            => string.Format("pwsh.exe {0}", src.Format(PathSeparator.BS));

        public static CmdLine cmd(FS.FilePath src)
            => string.Format("cmd.exe /c {0}", src.Format(PathSeparator.BS));

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

        public static CmdLine cmdline(FS.FilePath path, ScriptKind kind, string args)
        {
            return kind switch{
                ScriptKind.Cmd => cmd(path, args),
                ScriptKind.Ps => pwsh(path, args),
                _ => Z0.CmdLine.Empty
            };
        }

        public static CmdLine cmdline(FS.FilePath path, ScriptKind kind)
        {
            return kind switch{
                ScriptKind.Cmd => cmd(path),
                ScriptKind.Ps => pwsh(path),
                _ => Z0.CmdLine.Empty
            };
        }

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(IToolWs ws, Actor tool, CmdModifier modifier, params string[] src)
            => new ToolCmdLine(tool, modifier, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static ToolCmdLine cmdline(IToolWs ws, Actor tool, params string[] src)
            => new ToolCmdLine(tool, new CmdLine(src));

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(ScriptTemplate src)
            => new CmdScriptExpr(src);

        [MethodImpl(Inline), Op]
        public static CmdScriptExpr expr(ScriptTemplate src, CmdVars vars)
            => new CmdScriptExpr(src, vars);

        public static CmdScriptExpr format(ScriptTemplate pattern, params CmdVar[] args)
            => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        public static CmdScriptExpr format<K>(ScriptTemplate pattern, params CmdVar<K>[] args)
            where K : unmanaged
                => string.Format(pattern.Pattern, args.Select(a => a.Format()));

        [MethodImpl(Inline), Op]
        public static ScriptTemplate pattern(string name, string content)
            => new ScriptTemplate(name, content);

        [MethodImpl(Inline), Op]
        public static CmdScript create(string id, CmdScriptExpr src)
            => new CmdScript(id, src);

        [MethodImpl(Inline), Op]
        public static CmdVar var(string name, object value)
            => new CmdVar(name, value);

        public static CmdVar<K> var<K>(string name, K kind, string value)
            where K : unmanaged
                => new CmdVar<K>(name,kind,value);

        public static CmdVar<K,T> var<K,T>(string name, K kind, T value)
            where K : unmanaged
                => new CmdVar<K,T>(name, kind, value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(uint index, T value)
            => (index,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static CmdArg<T> arg<T>(uint index, string name, T value)
            => new CmdArg<T>(index, name, value);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(string name, string value)
            => new CmdArg(name,value);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(string name)
            => new CmdArg(name);

        [MethodImpl(Inline), Op]
        public static CmdArg arg(uint index, string name, string value)
            => new CmdArg(index, name, value);

        [MethodImpl(Inline), Op]
        public static CmdScriptVar var(Name name)
            => new CmdScriptVar(name);

        [MethodImpl(Inline), Op]
        public static CmdVar var(Name name, string value)
            => new CmdVar(name, value);


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

        public static async Task<int> run(ToolCmdSpec cmd, CmdContext context, Action<string> status, Action<string> error)
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
    }
}