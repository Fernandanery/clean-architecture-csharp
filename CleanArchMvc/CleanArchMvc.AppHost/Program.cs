using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArchMvc_WebUI>("webui");

builder.AddProject<Projects.CleanArchMvc_WebApi>("webapi");

builder.Build().Run();
