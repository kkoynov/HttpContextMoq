﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace HttpContextMoq;

public class RequestCookieCollectionFake : IRequestCookieCollection
{
    private readonly Dictionary<string, string> _dictionary;

    public RequestCookieCollectionFake()
    {
        _dictionary = new(StringComparer.OrdinalIgnoreCase);
    }

    public RequestCookieCollectionFake(IDictionary<string, string> dictionary)
    {
        _dictionary = new(dictionary, StringComparer.OrdinalIgnoreCase);
    }

    public string this[string key]
    {
        get
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (TryGetValue(key, out string value))
            {
                return value;
            }

            return null;
        }
    }

    public int Count => _dictionary.Count;

    public ICollection<string> Keys => _dictionary.Keys;

    public bool ContainsKey(string key) => _dictionary.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _dictionary.GetEnumerator();

    public bool TryGetValue(string key, out string value) => _dictionary.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_dictionary).GetEnumerator();
}
