﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using RESTFulSense.Brokers.Types;

namespace RESTFulSense.Services.Foundations.Types
{
    internal partial class TypeService : ITypeService
    {
        private readonly ITypeBroker typeBroker;

        public TypeService(ITypeBroker typeBroker) =>
            this.typeBroker = typeBroker;

        public Type RetrieveType(object @object) =>
        TryCatch(() =>
        {
            ValidateObjectIsNotNullOnRetrieve(@object);
            Type type = this.typeBroker.GetType(@object);

            return type;
        });
    }
}
