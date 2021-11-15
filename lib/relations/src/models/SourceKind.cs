//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;
    using System;

    using static Root;

    public interface ISourceKind
    {
        Label Name {get;}
    }

    public interface ISourcePath
    {
        ReadOnlySpan<Relation> Components {get;}
    }

    public readonly struct FileSource : ISourceKind
    {
        public Label Name => "files";
    }

    public readonly struct RandomSource : ISourceKind
    {
        public Label Name => "random";
    }

    public readonly struct MemorySource : ISourceKind
    {
        public Label Name => "memory";
    }

    public readonly struct RegisterSource : ISourceKind
    {
        public Label Name => "register";
    }

    public readonly struct ToolSource : ISourceKind
    {
        public Label Name => "register";
    }

}