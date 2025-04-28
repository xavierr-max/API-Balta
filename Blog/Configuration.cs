namespace Blog
{
    public static class Configuration
    {
        // Token - JWT                              //Essa linha gera um guid em string única
        public static string JwtKey { get; set; } = Guid.NewGuid().ToString();
    }
}

