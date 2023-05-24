using GraphQL.Server.Ui.Voyager;
using GraphQLDirector.Data;
using GraphQLDirector.GraphQL;
using GraphQLDirector.GraphQL.DataDirector;
using GraphQLDirector.GraphQL.DataVideo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPooledDbContextFactory<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"))
);

Type[] types = {
    typeof(VideoType),
    typeof(DirectorType)
};

builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddTypes(types)
    .AddProjections()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => {
    endpoints.MapGraphQL();
});

app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/graphql-ui");

app.MapControllers();

app.Run();
