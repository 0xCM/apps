//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class MsProjects
    {
        public readonly struct Sdk
        {
            public readonly string Name;

            [MethodImpl(Inline)]
            public Sdk(Identifier name)
            {
                Name = name;
            }
        }
    }
}