//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CmdAction
    {
        public readonly SettingName<asci32> Name;

        public readonly CmdActionKind Kind;

        public readonly object Host;

        public readonly MethodInfo Method;

        [MethodImpl(Inline)]
        public CmdAction(asci32 name, CmdActionKind kind, MethodInfo method, object host)
        {
            Name = name;
            Kind = kind;
            Host = host;
            Method = method;
        }
    }
}