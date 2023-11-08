namespace Dgmjr.Primitives.EntityFrameworkCore;

public static class PhoneNumberEfCoreExtensions
{
    public static PropertyBuilder<PhoneNumber?> PhoneNumberProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, PhoneNumber?>> propertyExpression
    )
        where TEntity : class =>
        modelBuilder.Entity<TEntity>().PhoneNumberProperty(propertyExpression);

    public static PropertyBuilder<PhoneNumber?> PhoneNumberProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, PhoneNumber?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<PhoneNumber>())
            .IsUnicode(false)
            .HasMaxLength(PhoneNumber.MaxLength);

    public static PropertyBuilder<PhoneNumber> PhoneNumberProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, PhoneNumber>> propertyExpression
    )
        where TEntity : class =>
        modelBuilder.Entity<TEntity>().PhoneNumberProperty(propertyExpression);

    public static PropertyBuilder<PhoneNumber> PhoneNumberProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, PhoneNumber>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<PhoneNumber>())
            .IsUnicode(false)
            .HasMaxLength(PhoneNumber.MaxLength);

    public static MigrationBuilder HasIsValidPhoneNumberFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.HasIsValidPhoneNumberFunction(IsValidPhoneNumber);

    public static MigrationBuilder HasIsValidPhoneNumberFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidPhoneNumberFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder HasIsValidPhoneNumberFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Operations.Add(
            new CreateFunctionOperation(
                schema,
                functionName,
                "@value nvarchar(MAX)",
                typeof(Constants).Assembly.ReadAssemblyResourceAllText(IsValidPhoneNumber + _sql)
            )
        );
        return migrationBuilder;
    }

    public static MigrationBuilder RollBackIsValidPhoneNumberFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.RollBackIsValidPhoneNumberFunction(IsValidPhoneNumber);

    public static MigrationBuilder RollBackIsValidPhoneNumberFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.RollBackIsValidPhoneNumberFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder RollBackIsValidPhoneNumberFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Sql($"DROP FUNCTION IF EXISTS [{schema}].[{functionName}]");
        return migrationBuilder;
    }

#if NET7_0_OR_GREATER
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder HasPhoneNumberCheckConstraint(
        this Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder tableBuilder,
        string columnName,
        string functionName = IsValidPhoneNumber,
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
