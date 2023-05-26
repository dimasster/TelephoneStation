using VerificationMicroService.Core;
using VerificationMicroService.Core.Mediatr.VerifyUser;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<VerificationService>();
builder.Services.AddMediatR(
    cfg => cfg.RegisterServicesFromAssemblies(typeof(VerifyUserQuery).Assembly));
builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.SetPreflightMaxAge(TimeSpan.FromDays(1));
    });
});
builder.Services.AddHsts(opt =>
{
    opt.Preload = true;
    opt.IncludeSubDomains = true;
    opt.MaxAge = TimeSpan.FromDays(30);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
}

app.UseCors();

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
