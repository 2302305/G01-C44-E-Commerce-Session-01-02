namespace E_Commerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddApplicationPart(typeof(E_Commerce.Presentation.Controllers.AuthenticationController).Assembly); ;
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddPresistenceServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddInfrustructureServices(builder.Configuration);
            builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {

                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var Errors = ActionContext.ModelState.Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(x => x.Key, x => x.Value.Errors.
                    Select(e => e.ErrorMessage).ToArray());
                    var problem = new ProblemDetails
                    {

                        Title = "Validation Error ",
                        Detail = " One Or More Validation Errors ",
                        Status = StatusCodes.Status400BadRequest,
                        Extensions = { { "error", Errors } }
                    };
                    return new BadRequestObjectResult(problem);
                };

            });
            builder.Services.Configure<JWTOptions>(builder.Configuration.GetSection(JWTOptions.SectionName));
            var app = builder.Build();
            var scope = app.Services.CreateScope();


            var Initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await Initializer.InitializeAsync();
            await Initializer.InitializeAuthDbAsync();
            ////Way1 For Exception Handling 

            //app.Use(async (context, next) =>
            //{

            //    try
            //    {
            //        await next.Invoke(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);//logging
            //        //write Response
            //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //        await context.Response.WriteAsJsonAsync(new
            //        {
            //            StatusCode = StatusCodes.Status500InternalServerError,
            //            Message = ex.Message
            //        });
            //    }

            //});

            ////Way2

            //app.UseMiddleware<GlobalExceptionHandler>();
            //app.UseCustomExceptionHandler();

            app.UseExceptionHandler();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
//RestAPI   
//SOAP API
//GraphQL API
//gRPC API
//Token structure 
//Header=>Type , Algorithm
//Payload =>Claims=>Key value Pair
//Signature=>HEader+PayLoad
