//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct ClrRender
    {
        // [Op]
        // public static string format(in ClrTypeSigInfo src)
        // {
        //     const string P0 = "{0}{1}[]";
        //     const string P1 = "{0}{1}*";
        //     const string P2 = "{0}{1}";
        //     var pattern = P2;
        //     if(src.IsArray)
        //         pattern = P0;
        //     else if(src.IsPointer)
        //         pattern = P1;
        //     return string.Format(pattern, src.Modifier, src.DisplayName);
        // }

        // [Op]
        // public static string format(in ClrParamInfo src)
        //     => string.Format("{0} {1}", format(src.Type), src.Name);

        // [Op]
        // public static string format(in ClrMethodArtifact src)
        // {
        //     var dst = TextTools.buffer();
        //     dst.Append(format(src.ReturnType));
        //     dst.Append(Chars.Space);
        //     dst.Append(src.MethodName);
        //     dst.Append(Chars.LParen);
        //     var parameters = src.Args.View;
        //     var count = parameters.Length;
        //     for(var i=0; i<count; i++)
        //     {
        //         dst.Append(format(skip(parameters,i)));
        //         if(i != count - 1)
        //         {
        //             dst.Append(Chars.Comma);
        //             dst.Append(Chars.Space);
        //         }
        //     }
        //     dst.Append(Chars.RParen);
        //     return dst.Emit();
        // }
    }
}