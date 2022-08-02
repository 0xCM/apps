//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Contracts
{
    public interface IContainer
    {
        dynamic Document {get;}
    }

    [Free]
    public interface IContainer<D> : IContainer
    {
        new D Document {get;}

        dynamic IContainer.Document 
            => Document;
    }
}