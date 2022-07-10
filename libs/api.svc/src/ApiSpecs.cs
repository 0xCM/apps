//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiTypes;

    sealed class ApiSpecs : AppCmdService<ApiSpecs>, IApiSpecs
    {
        ApiMd ApiMd => Wf.ApiMetadata();

        public ReadOnlySeq<ApiDataType> DataTypes()
            => data("DataTypes", () => types(ApiMd.Components));

        public ReadOnlySeq<ApiTypeInfo> DataTypeInfo()
            => data("DataTypeInfo", () => describe(DataTypes()));

        [CmdOp("api/emit/types")]
        void EmitDataTypes()
        {
            TableEmit(DataTypeInfo(), AppDb.ApiTargets().Table<ApiTypeInfo>());
        }
    }
}