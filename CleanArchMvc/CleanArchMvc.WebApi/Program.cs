using CleanArchMvc.Infra.IoC;
using CleanArchMvc.WebUI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureApi(builder.Configuration);
builder.Services.AddInfrastructureJwt(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// .Net Aspire
builder.AddServiceDefaults();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
