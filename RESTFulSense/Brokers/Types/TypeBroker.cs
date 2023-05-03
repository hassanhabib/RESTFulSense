// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.Brokers.Types
{
    internal class TypeBroker : ITypeBroker
    {
        public Type GetType(object @object) =>
            @object.GetType();
    }
}
