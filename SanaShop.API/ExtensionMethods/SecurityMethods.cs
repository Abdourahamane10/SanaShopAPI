namespace SanaShop.API.ExtensionMethods
{
    /// <summary>
    /// About security (cors, jwt)  
    /// </summary>
    public static class SecurityMethods
    {
        #region Contants
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";
        #endregion Contants

        #region Méthodes publiques
        /// <summary>
        /// Add cors and jwt configuration
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(configuration);

            var origin = configuration["Cors:Origin"]
                ?? throw new InvalidOperationException("Cors:Origin configuration is missing");

            services.AddCors(option =>
            {
                option.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins(origin)
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
        }
        #endregion Méthodes publiques
    }
}
