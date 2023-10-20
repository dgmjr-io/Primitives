namespace Dgmjr.Primitives.Abstractions;

using System;

public interface IHaveAuri {
  uri Uri { get; }
}

public interface IHaveAWritableuri : IHaveAuri {
  new uri Uri { get;
  set;
}
}
