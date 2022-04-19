//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class RngAttribute : Attribute
    {
        public RngAttribute(string name)
        {
            Name = name;
        }

        public string Name {get;}
    }

    [Free]
    public interface IRng
    {
        Label Name => RP.Empty;
    }

    [Free]
    public interface IRng<T> : IRng, ISource<T>
        where T : unmanaged
    {

    }

    [Free]
    public interface IRngAdapter : IRng
    {
        IRng Source {get;}

        Label IRng.Name
            => Source.Name;
    }
}