#if !NETSTANDARD2_0_OR_GREATER

public class Validation
{
    public string ErrorMessage { get; }

    public static readonly Validation Ok = new (string.Empty);

    private Validation(string reason) => ErrorMessage = reason;

    public static Validation Invalid(string reason = "")
        => string.IsNullOrEmpty(reason) ? new Validation("[none provided]") : new Validation(reason);
}
#endif
