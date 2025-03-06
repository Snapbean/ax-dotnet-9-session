using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var db = builder
    .AddPostgres("postgres")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("db");

var api = builder
    .AddProject<AspireDemo_Api>("api")
    .WithReference(db)
    .WaitFor(db);

builder
    .AddProject<AspireDemo_Web>("web")
    .WithReference(api)
    .WaitFor(api);

builder.Build().Run();