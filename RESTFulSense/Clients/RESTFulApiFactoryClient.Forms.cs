// ----------------------------------------------------------------------------------
// Copyright (c) The Standard Organization: A coalition of the Good-Hearted Engineers
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Extensions.DependencyInjection;
using RESTFulSense.Brokers.Attributes;
using RESTFulSense.Brokers.MultipartFormDataContents;
using RESTFulSense.Brokers.Properties;
using RESTFulSense.Brokers.Types;
using RESTFulSense.Brokers.Values;
using RESTFulSense.Services.Coordinations.Forms;
using RESTFulSense.Services.Foundations.Attributes;
using RESTFulSense.Services.Foundations.Forms;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Foundations.Types;
using RESTFulSense.Services.Foundations.Values;
using RESTFulSense.Services.Orchestrations.Forms;
using RESTFulSense.Services.Orchestrations.Properties;
using RESTFulSense.Services.Properties;

namespace RESTFulSense.Clients
{
    public partial class RESTFulApiFactoryClient
    {
        internal static IServiceProvider RegisterFormServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<ITypeBroker, TypeBroker>();
            services.AddTransient<IPropertyBroker, PropertyBroker>();
            services.AddTransient<IAttributeBroker, AttributeBroker>();
            services.AddTransient<IValueBroker, ValueBroker>();
            services.AddTransient<IMultipartFormDataContentBroker, MultipartFormDataContentBroker>();
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IPropertyService, PropertyService>();
            services.AddTransient<IAttributeService, AttributeService>();
            services.AddTransient<IValueService, ValueService>();
            services.AddTransient<IFormService, FormService>();
            services.AddTransient<IPropertyOrchestrationService, PropertyOrchestrationService>();
            services.AddTransient<IFormOrchestrationService, FormOrchestrationService>();
            services.AddTransient<IFormCoordinationService, FormCoordinationService>();

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
