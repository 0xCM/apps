//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ITestDynamic
        : ITestBinaryDynamic,
          ICheckUnaryDynamic,
          ICheckNumericDynamic,
          ICheckFixedDynamic
    {

    }
}