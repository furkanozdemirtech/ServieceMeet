using CreatedMeetRepository.RestGenericInterface;
using CreatedMeetRepository.RestJob;
using CreatedMeetRepository.SqlContext;
using CreaterMeetService.Controllers;
using CreaterMeetService.MailHelper;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped(typeof(GenericController<>));
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MeetDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddHangfire(config =>
{
    config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
          .UseSimpleAssemblyNameTypeSerializer()
          .UseDefaultTypeSerializer()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"), new SqlServerStorageOptions
          {
              CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
              SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
              QueuePollInterval = TimeSpan.Zero,
              UseRecommendedIsolationLevel = true,
              DisableGlobalLocks = true
          });
});

builder.Services.AddHangfireServer();
builder.Services.AddTransient<EmailService>();

builder.Services.AddControllersWithViews();
// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<EmailService>(x => x.SendEmail(), Cron.Daily);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
