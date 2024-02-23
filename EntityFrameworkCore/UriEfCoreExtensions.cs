using Dgmjr.EntityFrameworkCore.Migrations;

namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class UriEfCoreExtensions
{
    public static PropertyBuilder<uri> UriProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, uri>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UriProperty(propertyExpression);

    public static PropertyBuilder<uri> UriProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, uri>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new UriEfCoreValueConverter())
            .IsUnicode(false)
            .HasMaxLength(UriMaxLength);

    public static MigrationBuilder HasIsValidUriFunction(this MigrationBuilder migrationBuilder) =>
        migrationBuilder.HasIsValidUriFunction(IsUri);

    public static MigrationBuilder HasIsValidUriFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidUriFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder HasIsValidUriFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Operations.Add(
            new CreateFunctionOperation(
                schema,
                functionName,
                ["@value nvarchar(MAX)"],
                "bit",
                typeof(Constants).Assembly.ReadAssemblyResourceAllText(IsUri + _sql)
            )
        );
        return migrationBuilder;
    }

    public static MigrationBuilder RollBackIsValidUriFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.RollBackIsValidUriFunction(IsUri);

    public static MigrationBuilder RollBackIsValidUriFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.RollBackIsValidUriFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder RollBackIsValidUriFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Operations.Add(new DropFunctionOperation(schema, functionName));
        return migrationBuilder;
    }

#if NET7_0_OR_GREATER
    public static TableBuilder HasUriCheckConstraint(
        this TableBuilder tableBuilder,
        string columnName,
        string functionName = IsUri,
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

public class UriEfCoreValueConverter : ValueConverter<uri, string>
{
    public UriEfCoreValueConverter()
        : base(v => v.ToString(), v => uri.From(v)) { }
}
