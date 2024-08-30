using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.CleanArchMvc_WebUI>("cleanArchMvc-WebUI");

builder.Build().Run();
