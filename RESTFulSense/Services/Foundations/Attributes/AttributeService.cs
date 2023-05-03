// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;
using RESTFulSense.Brokers.Attributes;

namespace RESTFulSense.Services.Foundations.Attributes
{
    internal partial class AttributeService : IAttributeService
    {
        private readonly IAttributeBroker attributeBroker;

        public AttributeService(IAttributeBroker attributeBroker) =>
            this.attributeBroker = attributeBroker;

        public TAttribute RetrieveAttribute<TAttribute>(PropertyInfo propertyInfo)
            where TAttribute : Attribute =>
        TryCatch(() =>
        {
            Validate(propertyInfo);

            TAttribute attribute = this.attributeBroker.GetPropertyCustomAttribute<TAttribute>(
                propertyInfo,
                inspectAncestors: true);

            return attribute;
        });
    }
}
