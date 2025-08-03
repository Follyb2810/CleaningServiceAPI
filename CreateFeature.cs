using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

class CreateFeature
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("❌ Please provide a feature name");
            return;
        }

        string featureName = args[0];
        string pascal = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(featureName.ToLower());
        string kebab = featureName.ToLower();
        string baseDir = Path.Combine("Modules", pascal); // Use PascalCase folder names

        if (!Directory.Exists(baseDir))
        {
            Directory.CreateDirectory(baseDir);
        }

        var files = new Dictionary<string, string>
        {
            [$"{pascal}/Controllers/{pascal}Controller.cs"] = $@"
using Microsoft.AspNetCore.Mvc;
using CleaningServiceAPI.Modules.{pascal}.Services;

namespace CleaningServiceAPI.Modules.{pascal}.Controllers;

[ApiController]
[Route(""api/{kebab}"")]
public class {pascal}Controller : ControllerBase
{{
    private readonly {pascal}Service _service;
    public {pascal}Controller({pascal}Service service)
    {{
        _service = service;
    }}

    [HttpGet]
    public IActionResult First()
    {{
        var result = _service.First();
        return Ok(result);
    }}
}}",
            [$"{pascal}/DTOs/{pascal}Dto.cs"] = $@"
namespace CleaningServiceAPI.Modules.{pascal}.DTOs;

public class {pascal}Dto
{{
    // Define DTO here
}}",
            [$"{pascal}/Models/{pascal}.cs"] = $@"
namespace CleaningServiceAPI.Modules.{pascal}.Models;

public class {pascal}
{{
    // Define Model here
}}",
            [$"{pascal}/Services/{pascal}Service.cs"] = $@"
namespace CleaningServiceAPI.Modules.{pascal}.Services;

public class {pascal}Service
{{
    public object First()
    {{
        return new {{ message = ""{pascal} service works!"" }};
    }}
}}",
            [$"{pascal}/Repositories/{pascal}Repository.cs"] = $@"
namespace CleaningServiceAPI.Modules.{pascal}.Repositories;

public class {pascal}Repository
{{
    // Data access methods
}}",
            [$"{pascal}/Mappers/{pascal}Mapper.cs"] = $@"
namespace CleaningServiceAPI.Modules.{pascal}.Mappers;

public static class {pascal}Mapper
{{
    public static object ToDto(object entity)
    {{
        return new {{
            // Map fields
        }};
    }}
}}",
            [$"{pascal}/{pascal}Module.cs"] = $@"
using CleaningServiceAPI.Modules.{pascal}.Repositories;
using CleaningServiceAPI.Modules.{pascal}.Services;

namespace CleaningServiceAPI.Modules.{pascal};

public static class {pascal}Module
{{
    public static IServiceCollection Add{pascal}Module(this IServiceCollection services)
    {{
        services.AddScoped<{pascal}Service>();
        services.AddScoped<{pascal}Repository>();
        return services;
    }}
}}"
        };

        foreach (var file in files)
        {
            string filePath = Path.Combine("CleaningServiceAPI", "Modules", file.Key);
            string dir = Path.GetDirectoryName(filePath) ?? "";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(filePath, file.Value.TrimStart());
        }

        Console.WriteLine($"✅ Feature '{featureName}' created in Modules/{pascal}");
    }
}
