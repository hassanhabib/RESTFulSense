// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.Tests.Acceptance.Models
{
    public class TEntity
    {
        public Guid TEntityId { get; set; }
        public string TEntityName { get; set; }
        public DateTimeOffset TEntityCreateDate { get; set; }
    }
}