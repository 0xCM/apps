//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CsPatterns
    {
        public readonly struct Literals
        {
            public const string Open = "{";

            public const string Close = "}";

            public const string Term = ";";

            public const string NamespaceDeclPattern = @namespace + Space + "{0}";

            public const string UsingStatic = @using + Space + @static;

            public const string UsingNamespace = @using + Space + "{0}" + Term;

            public const string UsingType = UsingStatic + Space + "{0}" + Term;

            public const string InlineAttribute = "[MethodImpl(Inline)]";

            public const string InlineOpAttribute = "[MethodImpl(Inline), Op]";

            public const string ApiCompleteAttribute = "[ApiComplete]";

            public const string PublicClass = @public + Space + @class;

            public const string ReadOnlyStruct = @readonly + Space + @struct;

            public const string UsingCompilerServices = "using System.Runtime.CompilerServices;";

            internal const string OneLineFunc = "{0} {1}({2}) => {3}" + Term;

            internal const string StaticOneLineFunc = @static + Space + OneLineFunc;

            internal const string PublicStaticOneLineFunc = @public + Space + StaticOneLineFunc;

            internal const string PublicOneLineFunc = @public + Space + OneLineFunc;

            public const string EnumDeclPattern = "public enum {0} : {1}";
        }
    }
}