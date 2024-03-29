﻿// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace RESTFulSense.Brokers.Attributes
{
    internal interface IAttributeBroker
    {
        TAttribute GetPropertyCustomAttribute<TAttribute>(
            PropertyInfo propertyInfo,
            bool inspectAncestors)
            where TAttribute : Attribute;
    }
}
