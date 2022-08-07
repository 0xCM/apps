//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using N = ToolNames;

    partial class Tools
    {
        public sealed class MkLink : Tool<MkLink>
        {
            public MkLink()
                : base(N.mklink)
            {

            }

            public string Format()
                => Name.Format();

            public override string ToString()
                => Format();
        }        

        [Cmd(N.mklink)]
        public struct MkLinkCmd : IToolCmd<MkLink,MkLinkCmd>
        {            
            public FS.FileUri Source;

            public FS.FileUri Target;
            
            public Flag Flags;

            [MethodImpl(Inline)]
            public MkLinkCmd(Flag flags, FS.FileUri src, FS.FileUri dst)
            {
                Flags = flags;
                Source = src;
                Target = dst;
            }

            [SymSource(tools)]
            public enum Flag : byte
            {
                None,

                [Symbol("D","Creates a directory symbolic link")]
                Directory,

                [Symbol("H","Creates a directory symbolic link")]
                Hard,

                [Symbol("J", "Creates a Directory Junction")]
                Junction,
            }          
        }
    }
}