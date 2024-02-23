namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class UrnEfCoreExtensions
{
    public static PropertyBuilder<urn> UrnProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, urn>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UrnProperty(propertyExpression);

    public static PropertyBuilder<urn?> UrnProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, urn?>> propertyExpression
    )
        where TEntity : class => modelBuilder.Entity<TEntity>().UrnProperty(propertyExpression);

    public static PropertyBuilder<urn> UrnProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, urn>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<urn>());

    public static PropertyBuilder<urn?> UrnProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, urn?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<urn>());

    public static MigrationBuilder HasIsValidUrnFunction(this MigrationBuilder migrationBuilder) =>
        migrationBuilder.HasIsValidUrnFunction(IsUrn);

    public static MigrationBuilder HasIsValidUrnFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidUrnFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder HasIsValidUrnFunction(
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
                typeof(Constants).Assembly.ReadAssemblyResourceAllText(IsUrn + _sql)
            )
        );
        return migrationBuilder;
    }

    public static MigrationBuilder RollBackIsValidUrnFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.RollBackIsValidUrnFunction(IsUrn);

    public static MigrationBuilder RollBackIsValidUrnFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.RollBackIsValidUrnFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder RollBackIsValidUrnFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Operations.Add(new DropFunctionOperation(schema, functionName));
        return migrationBuilder;
    }

#if NET7_0_OR_GREATER
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder HasUrnCheckConstraint(
        this Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder tableBuilder,
        string columnName,
        string functionName = IsUrn,
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
