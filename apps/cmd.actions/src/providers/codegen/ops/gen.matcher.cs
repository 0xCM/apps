//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Root;
    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/matcher")]
        Outcome Matcher(CmdArgs args)
        {
            var opcodes = Sdm.LoadImportedForms();
            var matcher = StringMatcher.build(opcodes.Select(x => x.OpCode.Format()));
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