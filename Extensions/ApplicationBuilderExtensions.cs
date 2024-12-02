namespace MeuBolsoBackend;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseCustomConfiguration(this WebApplication app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", app.Configuration["App:Name"]);
                c.RoutePrefix = string.Empty; // Swagger UI na raiz

                var auth0ClientId = app.Configuration["Auth0:App:ClientId"];
                var auth0Audience = app.Configuration["Auth0:Api:Audience"];
                
                c.OAuthClientId(auth0ClientId);
                c.OAuthAppName($"{app.Configuration["App:Name"]} - Swagger");
                c.OAuthUsePkce(); // Habilita PKCE
                c.OAuthAdditionalQueryStringParams(new Dictionary<string, string>
                {
                    { "audience", auth0Audience ?? "" },
                });
            });
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseMiddleware<AuthenticationMiddleware>();
        app.UseCors("AllowLocalhost4200");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseHttpsRedirection();
        app.MapControllers();

        return app;
    }
}
