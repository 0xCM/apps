//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [FlowCmdBuilder]
    public abstract class CmdFlows<H,C,F> : WfSvc<H>, IFlowCommands<C,F>
        where C : struct, IFileFlowCmd<C>
        where F : IFileFlowType<F>, new()
        where H : CmdFlows<H,C,F>, new()
    {
        public F Flow {get;} = new F();

        public CmdScript BuildCmdScript(C src)
        {
            var fvals = ClrFields.values(src,Fields);
            var count = fvals.Length;
            var dst = text.buffer();
            dst.Append(src.Actor.Name);
            foreach(var fval in fvals)
            {
                var field = fval.Field;
                var value = fval.Value;
                if(value is null)
                    continue;

                var type = field.FieldType;
                var tag = field.Tag<CmdArgAttribute>();
                if(tag.IsNone())
                    continue;

                var tagval = tag.Require();
                var missing = tagval.Missing;
                var expr = tagval.Expression ?? EmptyString;

                if(type == typeof(string))
                {
                    var x = value as string;
                    if(text.nonempty(x))
                    {
                        if(text.nonempty(expr))
                            dst.AppendFormat( " {0}", string.Format(expr,x));
                        else
                            dst.Append(x);
                    }
                }
                else if(type == typeof(bit))
                {
                    var x = value as bit?;
                    if(x.HasValue)
                    {
                        if(x.Value == 1 && text.nonempty(expr))
                            dst.AppendFormat(" {0}", expr);
                    }
                }
                else if(type == typeof(FS.FolderPath))
                {
                    var x = value as FS.FolderPath?;
                    if(x.HasValue)
                        dst.AppendFormat(" {0}", x.Value.Format(PathSeparator.BS, true));
                }
                else
                {
                    if(missing.Exists && object.Equals(value, missing.Value))
                        continue;

                    if(type == typeof(FS.FilePath))
                    {
                        var path = (FS.FilePath)value;
                        if(expr == "<src>" || expr == "<dst>" || text.empty(expr))
                            dst.AppendFormat(" {0}", path.Format(PathSeparator.BS, true));
                        else
                            dst.AppendFormat(" {0}", string.Format(expr, path.Format(PathSeparator.BS, true)));
                    }
                    else if(text.nonempty(expr))
                        dst.AppendFormat(" {0}", string.Format(expr,value));
                    else
                        dst.Append(string.Format(" {0}", value.ToString()));
                }
            }

            var spec = dst.Emit();
            dst.AppendLine("@echo off");
            dst.AppendLine(string.Format("set Spec={0}", spec));
            dst.AppendLine(string.Format("call %Spec%"));
            dst.AppendLine("if errorlevel 1 goto:eof");
            dst.AppendLine(string.Format("echo {0}:[{1} -- {2}]", src.Actor.Name, src.Source, src.Target));
            return new CmdScript(dst.Emit());
        }

        public Index<CmdLine> BuildCmdLines(IProjectWs project, string scope, string cmdname)
        {
            var ext = Flow.SourceKind.Ext();
            var files = project.SrcFiles(recurse:false).Where(f => f.Is(ext));
            var buffer = core.bag<CmdLine>();
            CmdLine Gen(FS.FilePath file)
            {
                var cmd= BuildCmd(project, scope, file);
                var script = BuildCmdScript(cmd);
                var scriptdir = project.Out(string.Format("{0}.scripts", scope));
                var spath =  scriptdir + FS.file(string.Format("{0}.{1}", file.FileName, cmdname), FS.Cmd);
                using var writer = spath.AsciWriter();
                var formatted = script.Format();
                writer.WriteLine(formatted);
                return new CmdLine(spath.Format(PathSeparator.BS));
            }

            iter(files, file => buffer.Add(Gen(file)), true);

            return buffer.Array();
        }

        const string ErrorMarker = "error:";

        const string WarningMarker = "warning:";

        public abstract C BuildCmd(IProjectWs project, string scope, FS.FilePath src);

        protected virtual void OnExecStatus(in string msg)
        {
            Write(msg, FlairKind.Status);
        }

        protected virtual void OnExecError(in string msg)
        {
            if(text.contains(msg, ErrorMarker))
                Write(msg, FlairKind.Error);
            else if(text.contains(msg, WarningMarker))
                Write(msg, FlairKind.Warning);
        }

        public void Execute(IProjectWs project, CmdDescriptor descriptor, bool clean = false)
        {
            if(clean)
                project.Out().Delete();

            var runlog = project.Out() + FS.file(descriptor.Name, FS.Log);
            var running = Running();
            var counter = 0u;

            using var flows = WsLog.open(project, string.Format("{0}.flows", descriptor.Name), FileKind.Log, clean);
            var eflows = EmittingFile(flows.Path);

            void ExecCmd(CmdLine src)
            {
                Scripters.run(src, CmdVars.Empty, runlog, OnExecStatus, OnExecError, out var output);
                var responses = CmdResponse.parse(output.Where(x => !x.Contains(WarningMarker) && !x.Contains(ErrorMarker)));
                counter += (uint)responses.Length;
                iter(responses, r => flows.AppendLine(r.Format()));
            }

            iter(BuildCmdLines(project, descriptor.Scope, descriptor.Name), ExecCmd);

            EmittedFile(eflows, counter);
            Ran(running);
        }

        protected FS.FilePath GetTargetPath(IProjectWs project, string scope, FS.FilePath src)
            => project.Out(scope).Create() + src.FileName.ChangeExtension(Flow.TargetExt);

        static CmdFlows()
        {
            Fields = typeof(C).DeclaredInstanceFields();
        }

        static Index<FieldInfo> Fields;
    }
}