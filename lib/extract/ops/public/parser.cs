//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct ApiExtracts
    {
        [Op]
        public static ApiExtractParser parser()
            => new ApiExtractParser(buffer());

        [MethodImpl(Inline), Op]
        public static ApiExtractParser parser(byte[] buffer)
            => new ApiExtractParser(buffer);
    }
}