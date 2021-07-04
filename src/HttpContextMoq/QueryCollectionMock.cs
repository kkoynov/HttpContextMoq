﻿namespace HttpContextMoq
{
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using Moq;

    public class QueryCollectionMock : IQueryCollection
    {
        public QueryCollectionMock()
        {
            this.Mock = new Mock<IQueryCollection>();
        }

        public Mock<IQueryCollection> Mock { get; }

        public StringValues this[string key] => this.Mock.Object[key];

        public int Count => this.Mock.Object.Count;

        public ICollection<string> Keys => this.Mock.Object.Keys;

        public bool ContainsKey(string key) => this.Mock.Object.ContainsKey(key);

        public IEnumerator<KeyValuePair<string, StringValues>> GetEnumerator() => this.Mock.Object.GetEnumerator();

        public bool TryGetValue(string key, out StringValues value) => this.Mock.Object.TryGetValue(key, out value);

        IEnumerator IEnumerable.GetEnumerator() => this.Mock.Object.GetEnumerator();
    }
}