using ASP.NET_MVC_Core;
using System.Net.Mail;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();


var emailGateway = new EmailGateway("smtp.example.com", 587, "username", "password");
var messageService = new MessageService(emailGateway);
var emailMessage = new EmailMessage
{
    Recipient = "recipient@example.com",
    Subject = "Test Email",
    Content = "This is a test email."
};

var job = new MessageSendingJob(messageService, emailMessage);
QuartzConfig.ConfigureScheduler();
