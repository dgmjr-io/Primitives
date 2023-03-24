/*
 * DI.cs
 *
 *   Created: 2022-12-14-02:03:20
 *   Modified: 2022-12-14-02:03:20
 *
 *   Author: David G. Mooore, Jr. <david@dgmjr.io>
 *
 *   Copyright © 2022 David G. Mooore, Jr., All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.Extensions.DependencyInjection;

#if NETSTANDARD2_0_OR_GREATER
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

#if NET6_0_OR_GREATER
using Microsoft.AspNetCore.Builder;
#endif

public static class ObjectIdDIExtensions
{

    //public static readonly Action<SwaggerGenOptions> ConfigureSwaggerGen = options
    //    => options
        //{
        //    try
        //    {
        //        options.MapType<ObjectId>(() => new OpenApiSchema
        //            {
        //                Type = "string",
        //                Pattern = ObjectId.RegexString,
        //                Format = nameof(ObjectId),
        //                Description = "A ObjectId is a 24-character hexadecimal string that uniquely identifies a SendPulse entity.",
        //                Example = new OpenApiString("abcdef0123456789abcdef01")
        //            });
        //    }
        //    catch (System.ArgumentException)
        //    {
        //        // ignore
        //    }
        //};

#if NET6_0_OR_GREATER
    public static WebApplicationBuilder DescribeObjectId(this WebApplicationBuilder builder)
    {
        builder.Describe<ObjectId>(); //.ConfigureSwaggerGen(ConfigureSwaggerGen);
        return builder;
    }
#endif

    public static IServiceCollection DescribeObjectId(this IServiceCollection services)
    {
        services.Describe<ObjectId>(); //.ConfigureSwaggerGen(ConfigureSwaggerGen);
        return services;
    }

}
#endif
