namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class ObjectIdEfCoreConversionExtensions
{
    public static PropertyBuilder<ObjectId> ObjectIdProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, ObjectId>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<ObjectId>())
            .IsUnicode(false);

    public static PropertyBuilder<ObjectId?> ObjectIdProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, ObjectId?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<ObjectId>())
            .HasMaxLength(ObjectId.Length)
            .IsUnicode(false);

    public static PropertyBuilder<ObjectId> ObjectIdProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, ObjectId>> propertyExpression
    )
        where TEntity : class =>
        modelBuilder
            .Entity<TEntity>()
            .ObjectIdProperty(propertyExpression)
            .HasMaxLength(ObjectId.Length)
            .IsUnicode(false);

    public static MigrationBuilder HasIsValidObjectIdFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.HasIsValidObjectIdFunction(ufn_ + "IsValidObjectId");

    public static MigrationBuilder HasIsValidObjectIdFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidObjectIdFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder HasIsValidObjectIdFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Sql(
            typeof(Constants).Assembly
                .GetManifestResourceStream(ufn_ + "IsValidObjectId.sql")
                .ReadToEnd()
        );
        return migrationBuilder;
    }

    public static MigrationBuilder RollBackIsValidObjectIdFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.RollBackIsValidObjectIdFunction(ufn_ + "IsValidObjectId");

    public static MigrationBuilder RollBackIsValidObjectIdFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.RollBackIsValidObjectIdFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder RollBackIsValidObjectIdFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Sql($"DROP FUNCTION IF EXISTS [{schema}].[{functionName}];");
        return migrationBuilder;
    }

#if NET7_0_OR_GREATER
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder HasObjectIdCheckConstraint(
        this Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder tableBuilder,
        string columnName,
        string functionName = "IsValidObjectId",
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
