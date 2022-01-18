//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using llvm;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    partial class XTend
    {
        public static Dictionary<string,FieldValue> FieldValues(this ICmd src)
            => ClrFields.values(src);
    }

    partial class ProjectCmdProvider
    {
        CmdScript GenScript(in IFileFlowCmd src)
        {

            var fvals = src.FieldValues();
            var count = fvals.Count;
            var dst = text.buffer();
            dst.Append(src.Actor.Name);
            foreach(var fval in fvals)
            {
                var field = fval.Value.Field;
                var value = fval.Value.Value;
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
                        {
                            dst.AppendFormat(" {0}", expr);
                        }
                    }
                }
                else
                {
                    if(missing.Exists && object.Equals(value, missing.Value))
                        continue;

                    if(type == typeof(FS.FilePath))
                    {
                        var path = (FS.FilePath)value;
                        if(expr == "<src>" || expr == "<dst>" || text.empty(expr))
                        {
                            dst.AppendFormat(" {0}", path.Format(PathSeparator.BS,true));
                        }
                        else
                        {
                            dst.AppendFormat(" {0}", string.Format(expr, path.Format(PathSeparator.BS, true)));
                        }
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

        Index<CmdLine> GenCmdLines()
        {
            var dst = core.bag<CmdLine>();
            var project = Project();
            var src = project.SrcFiles("att/64", false);
            var count = src.Length;
            var outdir = project.Out("att/64").Create();
            var scriptdir = project.Out("att/64.scripts");

            CmdLine Gen(FS.FilePath path)
            {
                var cmd = McCmd.Empty;
                cmd.Source = path;
                cmd.Target = outdir + path.FileName.ChangeExtension(FS.Asm);
                cmd.FileType = "asm";
                cmd.Triple = "x86_64-pc-windows-msvc";
                cmd.MCpu = "cascadelake";
                cmd.OutputAsmVariant = 1;
                cmd.PrintImmHex = 1;

                var script = GenScript(cmd);
                var spath =  scriptdir + path.FileName.ChangeExtension(FS.Cmd);
                using var writer = spath.AsciWriter();
                var formatted = script.Format();
                writer.WriteLine(formatted);
                return new CmdLine(spath.Format(PathSeparator.BS));
            }

            iter(src, path => dst.Add(Gen(path)), true);
            return dst.Array();
        }


        [CmdOp("mc/cleanse")]
        Outcome McTest(CmdArgs args)
        {
            const string ErrorMarker = "error:";
            const string WarningMarker = "warning:";

            var result = Outcome.Success;
            var cmdname = "cleanse";
            var cmdsrc = "att/64";
            var srckind = FileKind.S;
            var project = Project();
            var src = project.SrcFiles(cmdsrc, srckind, false);
            var count = src.Length;
            project.Out().Delete();
            var outdir = project.Out(cmdsrc).Create();
            var runlog = project.Out() + FS.file(cmdname, FS.Log);
            var scriptdir = project.Out(string.Format("{0}.scripts", cmdsrc));
            var running = Running();
            var flowlog = project.Out() + FS.file(string.Format("{0}.flows",cmdname), FS.Log);
            var eflows = EmittingFile(flowlog);
            var counter = 0u;
            using var flows = flowlog.AsciWriter();

            void OnStatus(in string msg)
            {
                Write(msg, FlairKind.Status);
            }

            void OnError(in string msg)
            {
                if(text.contains(msg, ErrorMarker))
                {
                    Write(msg, FlairKind.Error);
                }
                else if(text.contains(msg, WarningMarker))
                {
                    Write(msg, FlairKind.Warning);
                }
            }


            void ExecCmd(CmdLine src)
            {
                OmniScript.Run(src, CmdVars.Empty, runlog, OnStatus, OnError, out var output);
                var responses = CmdResponse.parse(output.Where(x => !x.Contains(WarningMarker) && !x.Contains(ErrorMarker)));
                counter += (uint)responses.Length;
                iter(responses, r => flows.WriteLine(r.Format()));
            }

            iter(GenCmdLines(),ExecCmd);

            EmittedFile(eflows, counter);
            Ran(running);

            return result;
        }
    }
}