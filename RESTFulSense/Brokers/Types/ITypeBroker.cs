// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;

namespace RESTFulSense.Brokers.Types
{
    internal interface ITypeBroker
    {
        Type GetType(object @object);
    }
}
