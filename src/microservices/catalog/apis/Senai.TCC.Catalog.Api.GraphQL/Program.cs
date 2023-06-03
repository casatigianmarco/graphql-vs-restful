using GraphQL;
using GraphQL.DataLoader;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Senai.TCC.Catalog.Api.GraphQL.GraphQL;
using Senai.TCC.Catalog.Api.GraphQL.GraphQL.DataLoaders;
using Senai.TCC.Catalog.Application;
using Senai.TCC.Catalog.Persistence.Postgres.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPostgresCatalogDbContext(builder.Configuration);
builder.Services.AddCatalogApplication();

// Add GraphQL
builder.Services.AddSingleton<ISchema, CatalogSchema>(services =>
    new CatalogSchema(new SelfActivatingServiceProvider(services)));
builder.Services.AddGraphQL(graphQlBuilder => graphQlBuilder
    .AddSystemTextJson());
builder.Services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
builder.Services.AddScoped<BrandsDataLoader>();
builder.Services.AddScoped<CategoriesDataLoader>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseGraphQL<ISchema>();

app.UseGraphQLPlayground();

app.Run();