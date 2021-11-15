//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ToolDeployment
    {
        public ToolId Id {get;}

        public FS.FilePath Path {get;}

        [MethodImpl(Inline)]
        public ToolDeployment(ToolId id, FS.FilePath path)
        {
            Id = id;
            Path = path;
        }

        public string Format()
            => string.Format("{0}:{1}", Id.Format(), Path.ToUri());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator ToolDeployment((ToolId id, FS.FilePath path) src)
            => new ToolDeployment(src.id, src.path);
    }

}