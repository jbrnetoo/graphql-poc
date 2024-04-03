using GraphQL.Infrastructure.GraphQL;
using GraphQL.Infrastructure.Repository;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddScoped<ProdutosQuery>();
builder.Services.AddScoped<ProdutosSchema>();
builder.Services.AddScoped<ProdutosMutation>();

builder.Services.AddGraphQL()
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = false)
                .AddGraphTypes(typeof(ProdutosSchema).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGraphQL<ProdutosSchema>("/graphql");
app.MapGraphQLPlayground("/ui/graphql", new PlaygroundOptions
{
    GraphQLEndPoint = "/graphql"
});

app.Run();
