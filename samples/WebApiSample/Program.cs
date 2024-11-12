using FlowNet;
using WebApiSample.Processes;
using WebApiSample.Processes.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Flow Example
builder.Services.AddFlow("Example", options =>
{
    options.CreateBuilder(builder =>
    {
        builder
            .AddNode<SaleContext>("Initial", "Init checkout").WithProcess<InitProcess>()
            .AddNext<SaleContext>("Discount", "Apply discounts").WithProcess<DiscountProcess>();
    });
});

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