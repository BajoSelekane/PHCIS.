var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.PHCIS_App_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.PHCIS_App_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
