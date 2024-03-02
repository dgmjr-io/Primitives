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


    /// <summary>
    /// Adds a custom function to the migration builder for validating email addresses.
    /// </summary>
    /// <param name="migrationBuilder">The migration builder.</param>
    /// <param name="functionName">The name of the custom function.</param>
    /// <returns>The migration builder.</returns>
    public static MigrationBuilder HasIsValidEmailAddressFunction(
        this MigrationBuilder migrationBuilder,
        string functionName
    ) => migrationBuilder.HasIsValidEmailAddressFunction(DboSchema.ShortName, functionName);

    /// <summary>
    /// Adds a custom function to the migration builder for validating email addresses.
    /// </summary>
    /// <param name="migrationBuilder">The migration builder.</param>
    /// <param name="schema">The schema of the custom function.</param>
    /// <param name="functionName">The name of the custom function.</param>
    /// <returns>The migration builder.</returns>
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
                ["@value nvarchar(MAX)"],
                "bit",
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
    /// <summary>Adds a check constraint to the table that ensures the specified column contains a valid email address.</summary>
    /// <param name="tableBuilder">The table builder.</param>
    /// <param name="columnName">The name of the column to apply the check constraint on. Defaults to 'EmailAddress'.</param>
    /// <param name="functionName">The name of the function that validates the email address. Defaults to 'IsValidEmailAddress'.</param>
    /// <param name="schema">The schema name. Defaults to 'dbo'.</param>
    /// <returns>The table builder.</returns>
    public static Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder HasEmailAddressCheckConstraint(
        this Microsoft.EntityFrameworkCore.Metadata.Builders.TableBuilder tableBuilder,
        string columnName = nameof(EmailAddress),
        string functionName = IsValidEmailAddress,
        string schema = DboSchema.ShortName
    )
    {
        tableBuilder.HasCheckConstraint(
            ck_ + columnName,
            $"[{columnName}] = '' OR [{columnName}] IS NULL OR [{schema}].[{functionName}]([{columnName}]) = 1"
        );
        return tableBuilder;
    }
#endif
}
