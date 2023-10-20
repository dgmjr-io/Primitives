// namespace Vogen;

// /// <summary>
// /// Represents a validation result.
// /// </summary>
// public class Validation
// {
//     /// <summary>
//     /// Gets the error message if validation failed.
//     /// </summary>
//     public string ErrorMessage { get; }

//     /// <summary>
//     /// Contains data related to validation.
//     /// </summary>
//     public Dictionary<object, object>? Data { get; private set; }

//     /// <summary>
//     /// Represents a successful validation.
//     /// </summary>
//     public static readonly Validation Ok = new(string.Empty);

//     /// <summary>
//     /// Initializes a new instance of the <see cref="Validation"/> class with the given error message.
//     /// </summary>
//     /// <param name="reason">The reason for failed validation.</param>
//     private Validation(string reason) => ErrorMessage = reason;

//     /// <summary>
//     /// Returns an invalid <see cref="Validation"/> with the given error message.
//     /// </summary>
//     /// <param name="reason">The reason for failed validation.</param>
//     /// <returns>An invalid <see cref="Validation"/> with the given error message.</returns>
//     public static Validation Invalid(string reason = "")
//         => IsNullOrEmpty(reason) ? new Validation("[none provided]") : new Validation(reason);

//     /// <summary>
//     /// Adds the specified data to the validation result.
//     /// </summary>
//     /// <param name="key">The data key.</param>
//     /// <param name="value">The data value.</param>
//     /// <returns>This <see cref="Validation"/> instance.</returns>
//     public Validation WithData(object key, object value)
//     {
//         Data ??= new Dictionary<object, object>();
//         Data[key] = value;
//         return this;
//     }
// }
