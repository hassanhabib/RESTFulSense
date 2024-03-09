// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.WebAssenbly.Tests.Acceptance.Models
{
    public class TEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreateDate { get; set; }
    }
}