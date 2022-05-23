//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Caller = System.Runtime.CompilerServices.CallerMemberNameAttribute;
    using File = System.Runtime.CompilerServices.CallerFilePathAttribute;
    using Line = System.Runtime.CompilerServices.CallerLineNumberAttribute;

    public interface ICheckNull : IClaimValidator
    {
        void notnull<T>(T src, string msg = null, [Caller] string caller = null, [File] string file = null, [Line] int? line = null)
            where T : class
        {
            if(src is null)
                throw new ArgumentNullException(AppMsg.called($"Argument was null", LogLevel.Error, caller,file,line).ToString());
        }
    }
}