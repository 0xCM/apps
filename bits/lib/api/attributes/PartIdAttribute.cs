//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;

[AttributeUsage(AttributeTargets.Assembly)]
public class PartIdAttribute : Attribute
{    
    public PartIdAttribute(object id)
    {
        Id = (PartId)id;
    }

    public PartId Id {get;}
}