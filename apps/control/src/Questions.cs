//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Queries
{
    using static Atoms;

    public readonly struct Module
    {


    }

    public readonly struct Processes
    {
        public static string Running => $"What {processes} are {executing} on {machine}?";

        public static string Relationships => $"What are the {relationships} among the {executing} {processes}?";
    }

    public readonly struct Process
    {
        public static string Path => $"What is the {path} to a {process} with {id} {pid}";

        public static string ModuleNames => $"What are the {names} of the {modules} {loaded} into the {address} {space} of the process {pid}";

        public static string ModulePaths => $"What are the {paths} to the {modules} {loaded} into the {address} {space} of the process {pid}";
    }

    public readonly struct Processor
    {
        public static string Name => $"What is the {name} of the {processor} on {machine}?";

        public static string CoreCount => $"How many {cores} does the {processor} on {machine} have?";
    }
}