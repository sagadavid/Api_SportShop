using Api_HPlusSport.Models;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    //comment it, we need warnings it in put method
    //.ConfigureApiBehaviorOptions(options=>
    //options.SuppressModelStateInvalidFilter=true)
    ;
//versioning
builder.Services.AddApiVersioning(options => 
{
    //1-versioning with url
    options.ReportApiVersions = true;//enables http response to get version
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified= true;

    //2-versioning with http header:define naming style/usage
    //options.ApiVersionReader = new HeaderApiVersionReader("X-API-Version");//commmented for the sake of version 3
    options.ApiVersionReader = new QueryStringApiVersionReader("qst-api-version");//query string version in header versioning

    //3-versioning with query string
    //go up and comment apiversionreader up above !!! 

});

//added to fix swagger glitch on versioning
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ShopContext>
    (options =>options
    .EnableSensitiveDataLogging()//for seeding errors
    .UseInMemoryDatabase("Shop")
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
