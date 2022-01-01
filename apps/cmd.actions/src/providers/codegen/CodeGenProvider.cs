//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Root;
    using static core;

    public partial class CodeGenProvider : AppCmdProvider<CodeGenProvider>
    {
        Generators Generators => Service(Wf.Generators);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        [CmdOp(".matcher")]
        Outcome Matcher(CmdArgs args)
        {
            var opcodes = Sdm.LoadImportedOpCodes();
            var matcher = StringMatcher.build(opcodes.Select(x => x.OpCode.Format()));
            var dst = ProjectDb.Settings() + Tables.filename<CharMatchRow>();
            TableEmit(matcher.MatchRows, CharMatchRow.RenderWidths, dst);

            var groups = matcher.GroupRows;

            dst = ProjectDb.Settings() + Tables.filename<CharGroupMembers>();
            TableEmit(groups, CharGroupMembers.RenderWidths, dst);

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