using System.Reflection.Emit;
using System.Runtime.CompilerServices;

namespace Dgmjr.Primitives.Tests;

public partial class iriTests : PrimitivesTests<iri, iriTests> {
  public iriTests(ITestOutputHelper output) : base(output) {}

  [StringSyntax(StringSyntaxAttribute.Regex)]
  private const string RegexString = @"^(?<Scheme>
        [a-z][a-z0-9+\-.]*
        )
        :
        (?<DoubleSlashes>\/\/)?
        (?<Authority>
            (?:
                (?<UserInfo>
                    (?:
                        %[0-9a-f]{2}|[-._~!$&'()*+,;=:]|[a-z0-9]
                    )*
                )@
            )?
            (?<Host>
                (?:
                    \[(?:
                        (?:[0-9a-f]{1,4}:){6}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|::(?:[0-9a-f]{1,4}:){5}(?:[0-9a-f]{1,4}:[0-9a-f]{1,4}|(?<=:):(?=:))|(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?(?:[0-9a-f]{1,4}:)?[0-9a-f]{1,4}:(?:[0-9a-f]{1,4}:){0,2}[0-9a-f]{1,4}|(?:[0-9a-f]{1,4}:){1,7}:|:(?:[0-9a-f]{1,4}:){1,7}
                    )
                    (?![0-9a-f])
                )
                |[a-z0-9]+
                (?:[-.][a-z0-9]+)*
            )
            (?:
                \:
                (?<Port>[0-9]+)
            )?
        )?
        (?<Path>(?:\/(?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/]|(?:[a-z0-9]|%[0-9a-f]{2})*)*)*)?
        (?:
            \?
            (?<Query>
                (?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*
            )?
        )?
        (?:
            #
            (?<Fragment>
                (?:%[0-9a-f]{2}|[-._~!$&'()*+,;=:@\/?]|(?:[a-z0-9]|%[0-9a-f]{2})*)*
            )?
        )?$";

  [GeneratedRegex(RegexString,
                  Compiled | Singleline | IgnoreCase | IgnorePatternWhitespace)]
  private static partial Regex Regex();

  protected override string[][] InvalidValuesStrings =>
      new[] { new[] { "fcku!!!!!!" } };

  protected override string[][] ValidValuesStrings => new[] {
    new[] { uri.ExampleStringValue },
    new[] { xri.ExampleStringValue },
    new[] { url.ExampleStringValue },
    new[] { urn.ExampleStringValue },
    new[] { iri.ExampleStringValue },
    new[] { "urn:uuid:1ffaa033-f06c-495c-a9f5-0f252dd740d8" },
    new[] { "urn:uuid:1ffaa033f06c495ca9f50f252dd740d8" },
    new[] { "https://dgmjr.io" },
    new[] { "ftp://dgmjr.io" },
    new[] { "telnet://dgmjr.io" },
    new[] { "tg://user/?id=10245674" },
    new[] { "dgmjr:foo" },
    new[] { "https://dgmjr.🤯" },
  };
}
