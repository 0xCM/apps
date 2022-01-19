//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;

    using static Root;

    public sealed class FlowScriptBuilder<C>
        where C : struct, IFileFlowCmd
    {
        public static FlowScriptBuilder<C> create() => new FlowScriptBuilder<C>();

        static Index<FieldInfo> Fields;

        public CmdScript BuildCmdScript(C src)
        {
            var fvals = src.FieldValues(Fields);
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
                            dst.AppendFormat(" {0}", expr);
                    }
                }
                else if(type == typeof(FS.FolderPath))
                {
                    var x = value as FS.FolderPath?;
                    if(x.HasValue)
                        dst.AppendFormat(" {0}", x.Value.Format(PathSeparator.BS,true));
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

        FlowScriptBuilder()
        {

        }

        static FlowScriptBuilder()
        {
            Fields = typeof(C).DeclaredInstanceFields();
        }
    }
}