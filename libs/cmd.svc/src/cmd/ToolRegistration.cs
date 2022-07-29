//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ToolRegistration
    {
        public Name ToolName;

        public Name ToolEnv;

        public FS.FilePath ExePath;

        [MethodImpl(Inline)]
        public ToolRegistration(Name name, Name env, FS.FilePath exe)
        {
            ToolName = name;
            ToolEnv = env;
            ExePath = exe;
        }
    }
}