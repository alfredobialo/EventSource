namespace UserManager.api;

public class AppFeatures
{
    public static WebApplication Use(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
    
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors("angularClientPolicy");

        app.MapControllers();

        return app;
    }
}
