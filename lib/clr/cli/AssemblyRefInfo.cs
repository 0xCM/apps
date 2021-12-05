//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Reflection;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Captures a dependency relationship between two assemblies
    /// </summary>
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct AssemblyRefInfo : IComparableRecord<AssemblyRefInfo>
    {
        public const string TableId = "clr.assembly-refs";

        public AssemblyName Source;

        public AssemblyName Target;

        public BinaryCode Token;

        public int CompareTo(AssemblyRefInfo src)
        {
            var left = string.Format("{0}.{1}", Source.SimpleName(), Target.SimpleName());
            var right = string.Format("{0}.{1}", src.Source.SimpleName(), src.Target.SimpleName());
            return left.CompareTo(right);
        }
    }
}