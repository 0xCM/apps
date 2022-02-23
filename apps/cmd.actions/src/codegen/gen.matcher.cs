//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using Asm;

    partial class CodeGenProvider
    {
        [CmdOp("gen/token-specs")]
        Outcome GenTokenSpecs(CmdArgs args)
        {
            var result = Outcome.Success;
            var src = Symbols.concat(Symbols.index<AsmOcTokens.VexToken>());
            var name = "VexTokens";
            var dst = ProjectDb.Logs("gen") + FS.file(name, FS.Cs);
            var svc = Wf.CodeGen().StringLiterals();
            using var writer = dst.Writer();
            writer.WriteLine(string.Format("public readonly struct {0}", name));
            writer.WriteLine("{");
            svc.Emit("Data", src, writer);
            writer.WriteLine("}");
            return result;
        }

        [CmdOp("gen/matcher")]
        Outcome Matcher(CmdArgs args)
        {
            var forms = Sdm.LoadSigs();
            var matcher = StringMatcher.build(forms.Select(x => x.Format()));
            TableEmit(matcher.MatchRows, CharMatchRow.RenderWidths, ProjectDb.SettingsTable<CharMatchRow>());

            var groups = matcher.GroupRows;
            TableEmit(groups, CharGroupMembers.RenderWidths, ProjectDb.SettingsTable<CharGroupMembers>());

            var count = groups.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var g = ref skip(groups,i);
                var members = matcher.MemberRows(g);
                ref readonly var element = ref first(members);
                var length = element.TargetLength;
                var pos = element.Pos;
                for(var j=0; j<members.Length; j++)
                {
                    ref readonly var member = ref skip(members,j);
                    Require.equal(member.TargetLength, length);
                    Require.equal(member.Pos, pos);
                }
            }

            return true;
        }
    }
}