namespace Dgmjr.Primitives.EntityFrameworkCore;

using static BindingFlags;
using static Expression;

public class RegexValueObjectEfCoreConverter<TValueObject> : ValueConverter<TValueObject?, string>
{
    public RegexValueObjectEfCoreConverter()
        : base(
            vo => vo.ToString(),
            v =>
                IsValid(v) ? From(v) : Empty
        ) { }

    public static TValueObject Empty => (TValueObject)typeof(TValueObject).GetProperty("Empty")!.GetValue(null)!;

    public static TValueObject? From(string s) =>
        (TValueObject?)typeof(TValueObject)
            .GetMethod("From", Static | Public)!
            .Invoke(null, new[] { s });

    public static bool IsValid(string s)
    {
        try
        {
            return typeof(TValueObject)
                .GetMethod("Validate", Static | Public)!
                .Invoke(null, new[] { s })?.Equals(Vogen.Validation.Ok) ?? false;
        }
        catch
        {
            return false;
        }
    }

    public static Expression<Func<string, TValueObject>> CreateTryParseExpression()
    {
        // Parameter for the input string.
        var inputParam = Parameter(typeof(string), "input");

        // MethodInfo for the 'From' method, assuming it's static and public.
        var fromMethod = typeof(TValueObject).GetMethod(
            "From",
            Public | Static,
            null,
            [typeof(string)],
            null
        ) ?? throw new InvalidOperationException(
                $"A static 'From' method accepting a single string argument could not be found on the {nameof(TValueObject)} type."
            );

        // Call the 'From' method.
        var methodCallExpression = Call(null, fromMethod, inputParam);

        // Create the try-catch block, catching any exception and returning null (default for reference types)
        var tryCatchExpression = TryCatch(
            Block(methodCallExpression, methodCallExpression), // The second occurrence ensures the return value is used.
            Catch(
                typeof(Exception),
                Constant(null, typeof(TValueObject)) // Return null (default) if an exception is caught.
            )
        );

        // Compile the try-catch block into a lambda
        var lambda = Lambda<Func<string, TValueObject>>(tryCatchExpression, inputParam);

        return lambda; //.Compile(); // Return the compiled function
    }
}
