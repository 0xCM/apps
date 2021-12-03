//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static minicore;

    [ApiHost]
    public readonly struct ApiUri
    {
        /// <summary>
        /// Extracts an 8-bit immediate value from an identity if it contains an immediate suffix; otherwise, returns none
        /// </summary>
        /// <param name="src">The source identity</param>
        [MethodImpl(Inline), Op]
        public static Option<byte> imm8(OpIdentity src)
        {
            if(src.HasImm && byte.TryParse(src.IdentityText.RightOfLast(IDI.Imm), out var immval))
                return immval;
            else
                return Option.none<byte>();
        }

        [Op]
        public static OpUri define(ApiUriScheme scheme, ApiHostUri host, string group, OpIdentity opid)
            => new OpUri(host, opid, BuildUriText(scheme, host, group, opid));

        [Op]
        public static OpUri hex(ApiHostUri host, string group, OpIdentity opid)
            => new OpUri(host, opid, BuildUriText(ApiUriScheme.Hex, host, group, opid));

        [MethodImpl(Inline), Op]
        public static OpUri located(ApiHostUri host, string group, OpIdentity opid)
            => new OpUri(host, opid, BuildUriText(ApiUriScheme.Located, host, group, opid));

        [Op]
        public static string QueryText(ApiUriScheme scheme, PartId part, string host, string group)
            => $"{scheme.Format()}{IDI.EndOfScheme}{part.Format()}{IDI.UriPathSep}{host}{IDI.UriQuery}{group}";

        [Op]
        public static string FullUriText(ApiUriScheme scheme, PartId part, string host, string group, OpIdentity opid)
            => $"{scheme.Format()}{IDI.EndOfScheme}{part.Format()}{IDI.UriPathSep}{host}{IDI.UriQuery}{group}{IDI.UriFragment}{opid.IdentityText}";

        public static ApiUriScheme scheme(string src)
            => Enum.TryParse(typeof(ApiUriScheme), src, true, out var result) ? (ApiUriScheme)result : ApiUriScheme.None;

        public static ParseResult<ApiHostUri> host(string src)
        {
            var failure = ParseResult.unparsed<ApiHostUri>(src);
            if(blank(src))
                return failure;

            var parts = src.SplitClean(IDI.UriPathSep);
            var count = parts.Length;
            if(count != 2)
                return failure.WithReason(string.Concat("Component count ", count," != ", 2));

            Enum.TryParse(parts[0], true, out PartId owner);
            if(owner == 0)
                return failure.WithReason("Invalid part");

            var host = parts[1];
            if(blank(host))
                return failure.WithReason("Host unspecified");

            return ParseResult.parsed(src, new ApiHostUri(owner, host));
        }

        public static Outcome host(string src, out ApiHostUri dst)
        {
            var result = Outcome.Success;
            dst = ApiHostUri.Empty;
            if(blank(src))
                return (false, "Empty input");

            var parts = src.SplitClean(IDI.UriPathSep);
            var count = parts.Length;
            if(count != 2)
                return (false,string.Concat("Component count ", count," != ", 2));

            Enum.TryParse(skip(parts,0), true, out PartId part);
            if(part == 0)
                return (false, string.Format("Invalid part '{0}'", skip(parts,0)));

            var host = skip(parts,1);
            if(blank(host))
                return (false, "Host unspecified");

            dst = new ApiHostUri(part,host);

            return result;
        }

        [Op]
        public static OpIdentity opid(string src)
        {
            try
            {
                if(empty(src))
                    return OpIdentity.Empty;

                var name = src.TakeBefore(IDI.PartSep);
                var suffixed = src.Contains(IDI.SuffixSep);
                var suffix = suffixed ? src.TakeAfter(IDI.SuffixSep) : EmptyString;
                var _generic = src.TakeAfter(IDI.PartSep);
                var generic =  nonempty(_generic) ? _generic[0] == IDI.Generic : false;
                var imm = suffix.Contains(IDI.Imm);
                var components = src.SplitClean(IDI.PartSep);
                return new OpIdentity(src, name, suffix, generic, imm, components);
            }
            catch(Exception)
            {
                throw new Exception(string.Format("Unable to created identity for {0}", src));
            }
        }

        public static ParseResult<OpUri> parse(string src)
        {
            var parts = src.SplitClean(IDI.EndOfScheme);
            var msg = string.Empty;
            if(parts.Length != 2)
                return ParseResult.unparsed<OpUri>(src, $"Splitting on {IDI.EndOfScheme} produced {parts.Length} pieces");

            var uriScheme = scheme(parts[0]);
            var rest = parts[1];
            var pathText = rest.TakeBefore(IDI.UriQuery);
            var path = host(pathText);
            if(path.Failed)
                return ParseResult.unparsed<OpUri>(src, $"{path.Message}");

            var id = opid(rest.TakeAfter(IDI.UriFragment));
            var group = rest.Between(IDI.UriQuery,IDI.UriFragment);
            var uri = define(uriScheme, path.Value, group, id);
            return ParseResult.parsed(src, uri);
        }

        [Op]
        public static Outcome parse(string src, out OpUri dst)
        {
            var result = parse(src);
            if(result)
            {
                dst = result.Value;
                return true;
            }
            else
            {
                dst = OpUri.Empty;
                return false;
            }
        }
        /// <summary>
        /// Defines an 8-bit immediate suffix predicated on an immediate value
        /// </summary>
        /// <param name="imm8">The source immediate</param>
        public static string Imm8Suffix(byte imm8)
            => $"{IDI.SuffixSep}{IDI.Imm}{imm8}";

        [Op]
        public static string PathText(string scheme, PartId catalog, string host)
            => $"{scheme}{IDI.EndOfScheme}{catalog.Format()}{IDI.UriPathSep}{host}";

        [Op]
        public static string GroupUriText(ApiUriScheme scheme, ApiHostUri host, string group)
            => QueryText(scheme, host.Part, host.HostName, group);

        /// <summary>
        /// Produces an identifier of the form {owner}/{host} where owner is the formatted identifier of the declaring assembly and host is the name of the type
        /// </summary>
        /// <param name="host">The source type</param>
        [Op]
        public static string HostUri(Type host)
            => $"{PartName.from(host)}{IDI.UriPathSep}{host.Name}";

        /// <summary>
        /// Builds the *canonical* operation uri
        /// </summary>
        /// <param name="scheme"></param>
        /// <param name="host"></param>
        /// <param name="group"></param>
        /// <param name="opid"></param>
        [Op]
        static string BuildUriText(ApiUriScheme scheme, ApiHostUri host, string group, OpIdentity opid)
            => (opid.IsEmpty
                ? QueryText(scheme, host.Part, host.HostName, group)
                : FullUriText(scheme, host.Part, host.HostName, group, opid)).Trim();
    }
}