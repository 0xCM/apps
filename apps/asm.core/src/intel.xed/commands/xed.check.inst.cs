//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedParsers;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/check/inst")]
        Outcome CheckInstDefs(CmdArgs args)
        {
            var src = Xed.Rules.CalcInstDefs();
            foreach(var def in src)
            {
                foreach(var pattern in def.PatternSpecs)
                {
                    var expr = RuleMacros.expand(text.despace(pattern.RawBody.Text));
                    var parts = text.split(expr,Chars.Space);
                    var buffer = text.buffer();
                    foreach(var part in parts)
                    {
                        buffer.Append(Chars.Space);

                        if(IsAssign(part))
                        {

                            if(parse(part, out FieldAssign a))
                            {
                                // if(empty(a.Format()))
                                // {
                                //     var xyz = part.Split(Chars.Eq);
                                //     parse(xyz[0], out FieldKind f);
                                //     var v0 = xyz[1];
                                //     XedFields.parse(f, v0, out var v1);
                                //     buffer.AppendFormat("{0}={1}", XedRender.format(f), v1);
                                // }
                                // else
                                var fmt = a.Format();
                                if(text.empty(fmt))
                                {
                                    return (false, $"Empty: {a.Field}={a.Value}");
                                }
                                buffer.Append(a.Format());
                            }
                            else
                            {
                                Warn(AppMsg.ParseFailure.Format(nameof(FieldAssign), part));
                            }

                        }
                        else
                        {
                            buffer.Append(part);
                        }
                    }
                    var expr2 = buffer.Emit().Trim();
                    Write(string.Format("Source: {0}", expr));
                    Write(string.Format("Target: {0}", expr2));
                    XedParsers.parse(RuleMacros.expand(expr), out InstPatternBody body);
                    foreach(var x in body)
                    {

                    }
                    //Write(string.Format("Parsed: {0}", pattern.Body.Delimit(Chars.Space)));

                }
            }

            return true;
        }

        void CheckInstDefs2()
        {
            var parsers = XedParsers.Service;
            var dst = AppDb.Log("xed.inst.body", FileKind.Txt);
            using var writer = dst.AsciWriter();
            var emitting = EmittingFile(dst);
            var result = Outcome.Success;
            var opcodes = Xed.Rules.LoadPatternInfo();
            var count = opcodes.Count;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var opcode = ref opcodes[i];
                ref readonly var source = ref opcode.Body;
                writer.AppendLineFormat("Source -> {0}", source);
                result = parsers.Parse(source, out InstPatternBody body);
                if(result.Fail)
                    break;

                XedRender.render(body,buffer);
                var target = buffer.Emit();
                writer.AppendLineFormat("Target <- {0}", target);
                writer.AppendLine();

                if(source != target)
                    Warn("'{0}' != '{1}'", source, target);
            }

            EmittedFile(emitting, count);
        }
    }
}