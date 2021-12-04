//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class EtlStepAttribute : Attribute
    {

    }

    [EtlStep]
    public abstract class EtlStep<H,S,T> : AppService<H>
        where H : EtlStep<H,S,T>, new()
    {
        public abstract void Run();

    }

    public abstract class ToolStep<H,S,T> : EtlStep<H,S,T>
        where H : ToolStep<H,S,T>, new()
    {
        public abstract ToolId Tool {get;}

        public abstract FileArchive SourceLocation {get;}

        public abstract FileArchive TargetLocation {get;}
    }

}
