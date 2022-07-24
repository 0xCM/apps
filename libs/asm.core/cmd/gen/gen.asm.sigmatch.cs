//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("gen/asm/sigmatch")]
        Outcome Matcher(CmdArgs args)
        {
            var forms = Sdm.LoadSigs();
            var matcher = StringMatcher.create(forms.Select(x => x.Format()));
            TableEmit(matcher.MatchRows, ProjectDb.SettingsTable<CharMatchRow>());

            var groups = matcher.GroupRows;
            TableEmit(groups, ProjectDb.SettingsTable<CharGroupMembers>());

            var count = groups.Length;
            for(var i=0; i<count; i++)
            {
                var members = matcher.MemberRows(skip(groups,i));
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