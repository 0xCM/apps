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
        [CmdOp("asm/gen/sigs/matcher")]
        Outcome Matcher(CmdArgs args)
        {
            var forms = Sdm.LoadSigs();
            var matcher = StringMatcher.create(forms.Select(x => x.Format()));
            AppSvc.TableEmit(matcher.MatchRows, ProjectDb.SettingsTable<CharMatchRow>());

            var groups = matcher.GroupRows;
            AppSvc.TableEmit(groups, ProjectDb.SettingsTable<CharGroupMembers>());

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