namespace Dgmjr.Primitives.EntityFrameworkCore;

/// <summary>
/// The email address ef core extensions.
/// </summary>
public static class EmailAddressEfCoreExtensions
{
    /// <summary>
    /// Configures the email address.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="modelBuilder">The model builder.</param>
    /// <param name="propertyExpression">The property expression.</param>
    public static PropertyBuilder<EmailAddress?> EmailAddressProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, EmailAddress?>> propertyExpression
    )
        where TEntity : class =>
        modelBuilder.Entity<TEntity>().EmailAddressProperty(propertyExpression);

    /// <summary>
    /// Configures the email address.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entityBuilder">The entity builder.</param>
    /// <param name="propertyExpression">The property expression.</param>
    public static PropertyBuilder<EmailAddress?> EmailAddressProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, EmailAddress?>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<EmailAddress>())
            .HasMaxLength(UriMaxLength);

    /// <summary>
    /// Configures the email address.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="modelBuilder">The model builder.</param>
    /// <param name="propertyExpression">The property expression.</param>
    public static PropertyBuilder<EmailAddress> EmailAddressProperty<TEntity>(
        this ModelBuilder modelBuilder,
        Expression<Func<TEntity, EmailAddress>> propertyExpression
    )
        where TEntity : class =>
        modelBuilder.Entity<TEntity>().EmailAddressProperty(propertyExpression);

    /// <summary>
    /// Configures the email address.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="entityBuilder">The entity builder.</param>
    /// <param name="propertyExpression">The property expression.</param>
    public static PropertyBuilder<EmailAddress> EmailAddressProperty<TEntity>(
        this EntityTypeBuilder<TEntity> entityBuilder,
        Expression<Func<TEntity, EmailAddress>> propertyExpression
    )
        where TEntity : class =>
        entityBuilder
            .Property(propertyExpression)
            .HasConversion(new RegexValueObjectEfCoreConverter<EmailAddress>())
            .HasMaxLength(UriMaxLength);

    public static MigrationBuilder HasIsValidEmailAddressFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.HasIsValidEmailAddressFunction(IsValidEmailAddress);

    public static MigrationBuilder HasIsValidEmailAddressFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidEmailAddressFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder HasIsValidEmailAddressFunction(
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
                typeof(Constants).Assembly.ReadAssemblyResourceAllText(IsValidEmailAddress + _sql)
            )
        );
        return migrationBuilder;
    }

    public static MigrationBuilder RollBackIsValidEmailAddressFunction(
        this MigrationBuilder migrationBuilder
    ) => migrationBuilder.RollBackIsValidEmailAddressFunction(IsValidEmailAddress);

    public static MigrationBuilder RollBackIsValidEmailAddressFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.RollBackIsValidEmailAddressFunction(DboSchema.ShortName, functionName);

    public static MigrationBuilder RollBackIsValidEmailAddressFunction(
        this MigrationBuilder migrationBuilder,
        string schema,
        string functionName
    )
    {
        migrationBuilder.Operations.Add(new DropFunctionOperation(schema, functionName));
        return migrationBuilder;
    }

#if NET7_0_OR_GREATER
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder HasEmailAddressCheckConstraint(
        this Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder tableBuilder,
        string columnName = nameof(EmailAddress),
        string functionName = IsValidEmailAddress,
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
