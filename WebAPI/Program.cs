using Application;
using Infrastructure;
using WebAPI;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddWebAPI()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    //API Controller kullanmak yerine simple bu þekilde eklenebilir.
    //app.Map("/error", (HttpContext httpContext) =>
    //{
    //    Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

    //    return Results.Problem();
    //});

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}