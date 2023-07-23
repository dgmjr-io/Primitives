#region Assembly System.Private.CoreLib, Version=8.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// /usr/local/share/dotnet/shared/Microsoft.NETCore.App/8.0.0-preview.5.23280.8/System.Private.CoreLib.dll
// Decompiled with ICSharpCode.Decompiler 7.2.1.6856
#endregion

#if !NET6_0_OR_GREATER
using System.Collections;

using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace System.Resources;

internal sealed class RuntimeResourceSet : ResourceSet, IEnumerable
{
    private Dictionary<string, ResourceLocator> _resCache;

    private _ResourceReader _defaultReader;

    private Dictionary<string, ResourceLocator> _caseInsensitiveTable;

    internal RuntimeResourceSet(string fileName)
        : this(new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
    {
    }

    internal RuntimeResourceSet(Stream stream, bool permitDeserialization = false)
        : base()
    {
        _resCache = new Dictionary<string, ResourceLocator>(FastResourceComparer.Default);
        _defaultReader = new _ResourceReader(stream, _resCache, permitDeserialization);
    }

    protected override void Dispose(bool disposing)
    {
        if (_defaultReader != null)
        {
            if (disposing)
            {
                _defaultReader?.Close();
            }
            _defaultReader = null!;
            _resCache = null!;
            _caseInsensitiveTable = null!;
            base.Dispose(disposing);
        }
    }

    public override IDictionaryEnumerator GetEnumerator()
    {
        return GetEnumeratorHelper();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumeratorHelper();
    }

    private IDictionaryEnumerator GetEnumeratorHelper()
    {
        _ResourceReader? defaultReader = _defaultReader;
        if (defaultReader == null)
        {
            throw new ObjectDisposedException(null, SR.ObjectDisposed_ResourceSet);
        }
        return defaultReader.GetEnumerator();
    }

    public override string? GetString(string key)
    {
        object? @object = GetObject(key, ignoreCase: false, isString: true);
        return (string?)@object;
    }

    public override string? GetString(string key, bool ignoreCase)
    {
        object? @object = GetObject(key, ignoreCase, isString: true);
        return (string?)@object;
    }

    public override object? GetObject(string key)
    {
        return GetObject(key, ignoreCase: false, isString: false);
    }

    public override object? GetObject(string key, bool ignoreCase)
    {
        return GetObject(key, ignoreCase, isString: false);
    }

    private object? GetObject(string key, bool ignoreCase, bool isString)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        _ResourceReader? defaultReader = _defaultReader;
        Dictionary<string, ResourceLocator> resCache = _resCache!;
        if (defaultReader == null || resCache == null)
        {
            throw new ObjectDisposedException(null, SR.ObjectDisposed_ResourceSet);
        }
        ResourceLocator value;
        lock (resCache)
        {
            int dataPosition;
            if (resCache.TryGetValue(key, out value))
            {
                object? value2 = value.Value;
                if (value2 != null)
                {
                    return value2;
                }
                dataPosition = value.DataPosition;
                return isString ? defaultReader.LoadString(dataPosition) : defaultReader.LoadObject(dataPosition);
            }
            dataPosition = defaultReader.FindPosForResource(key);
            if (dataPosition >= 0)
            {
                object? value2 = ReadValue(defaultReader, dataPosition, isString, out value);
                resCache[key] = value;
                return value2;
            }
        }
        if (!ignoreCase)
        {
            return null;
        }
        bool flag = false;
        Dictionary<string, ResourceLocator> dictionary = _caseInsensitiveTable;
        if (dictionary == null)
        {
            dictionary = new Dictionary<string, ResourceLocator>(StringComparer.OrdinalIgnoreCase);
            flag = true;
        }
        lock (dictionary)
        {
            if (flag)
            {
                _ResourceReader.ResourceEnumerator enumeratorInternal = defaultReader.GetEnumeratorInternal();
                while (enumeratorInternal.MoveNext())
                {
                    string key2 = (string)enumeratorInternal.Key;
                    ResourceLocator value3 = new ResourceLocator(enumeratorInternal.DataPosition, null)!;
                    dictionary.Add(key2, value3);
                }
                _caseInsensitiveTable = dictionary;
            }
            if (!dictionary.TryGetValue(key, out value))
            {
                return null;
            }
            if (value.Value != null)
            {
                return value.Value;
            }
            object? value2 = ReadValue(defaultReader, value.DataPosition, isString, out value);
            if (value.Value != null)
            {
                dictionary[key] = value;
                return value2;
            }
            return value2;
        }
    }

    private static object? ReadValue(_ResourceReader reader, int dataPos, bool isString, out ResourceLocator locator)
    {
        object? obj;
        ResourceTypeCode typeCode;
        if (isString)
        {
            obj = reader.LoadString(dataPos);
            typeCode = ResourceTypeCode.String;
        }
        else
        {
            obj = reader.LoadObject(dataPos, out typeCode);
        }
        locator = new ResourceLocator(dataPos, ResourceLocator.CanCache(typeCode) ? obj : null);
        return obj;
    }
}
#endif
