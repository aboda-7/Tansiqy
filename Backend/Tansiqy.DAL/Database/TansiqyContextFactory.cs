using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Tansiqy.DAL.Database;

public class TansiqyContextFactory : IDesignTimeDbContextFactory<TansiqyContext>
{
    public TansiqyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TansiqyContext>();

        optionsBuilder.UseSqlServer("Server=ABODA;Database=TansiqyDB;Trusted_Connection=True;TrustServerCertificate=True;");

        return new TansiqyContext(optionsBuilder.Options);
    }
}
