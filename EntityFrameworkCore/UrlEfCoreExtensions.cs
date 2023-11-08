namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class UrlEfCoreExtensions
{
    public static PropertyBuilder<url> UrlProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, url>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UrlProperty(propertyExpression);

    public static PropertyBuilder<url> UrlProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, url>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<url>())
            .HasMaxLength(UriMaxLength);

    public static MigrationBuilder HasIsValidUrlFunction(this MigrationBuilder migrationBuilder) =>
        migrationBuilder.HasIsValidUrlFunction(IsUrl);

    public static MigrationBuilder HasIsValidUrlFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidUrlFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder HasIsValidUrlFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Sql(
            typeof(Constants).Assembly
                .ReadAssemblyResourceAllText(IsUrl + _sql)
                .Replace("{schema}", schema)
                .Replace("{functionName}", functionName)
        );
        return migrationBuilder;
    }

    public static MigrationBuilder RollBackIsValidUrlFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.RollBackIsValidUrlFunction(IsUrl);

    public static MigrationBuilder RollBackIsValidUrlFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.RollBackIsValidUrlFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder RollBackIsValidUrlFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Sql($"DROP FUNCTION IF EXISTS [{schema}].[{functionName}]");
        return migrationBuilder;
    }

#if NET7_0_OR_GREATER
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder HasUrlCheckConstraint(
        this Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder tableBuilder,
        string columnName,
        string functionName = IsUrl,
        string schema = DboSchema.ShortName
    )
    {
        tableBuilder.HasCheckConstraint(
            ck_ + columnName,
            $"[{schema}].[{functionName}]({columnName}) = 1"
        );
        return tableBuilder;
    }
#endif
}
