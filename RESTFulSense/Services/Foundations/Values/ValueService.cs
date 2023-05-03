// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System.Reflection;
using RESTFulSense.Brokers.Values;

namespace RESTFulSense.Services.Foundations.Values
{
    internal partial class ValueService : IValueService
    {
        private readonly IValueBroker valueBroker;

        public ValueService(IValueBroker valueBroker) =>
            this.valueBroker = valueBroker;

        public object RetrievePropertyValue(object @object, PropertyInfo propertyInfo) =>
        TryCatch(() =>
        {
            return this.valueBroker.GetPropertyValue(@object, propertyInfo);
        });
    }
}
