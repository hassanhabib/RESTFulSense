// ---------------------------------------------------------------------------------- 
// Copyright (c) The Standard Organization, a coalition of the Good-Hearted Engineers 
// ----------------------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;
using RESTFulSense.Brokers.Reflections;
using RESTFulSense.Services.Foundations.FileNames;
using RESTFulSense.Services.Foundations.Properties;
using RESTFulSense.Services.Foundations.StreamContents;
using RESTFulSense.Services.Foundations.StringContents;
using RESTFulSense.Services.Orchestrations.FormContents;
using RESTFulSense.Services.Processings.FileNames;
using RESTFulSense.Services.Processings.Properties;
using RESTFulSense.Services.Processings.StreamContents;
using RESTFulSense.Services.Processings.StringContents;

namespace RESTFulSense.Extensions
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBroker(this IServiceCollection services) =>
            services.AddTransient<IReflectionBroker, ReflectionBroker>();

        public static IServiceCollection AddFoundationServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IPropertyService, PropertyService>()
                .AddTransient<IStringContentService, StringContentService>()
                .AddTransient<IFileNameService, FileNameService>()
                .AddTransient<IStreamContentService, StreamContentService>();
        }

        public static IServiceCollection AddProcessingServices(this IServiceCollection services)
        {
            return services
                .AddTransient<IStringContentProcessingService, StringContentProcessingService>()
                .AddTransient<IStreamContentProcessingService, StreamContentProcessingService>()
                .AddTransient<IFileNameProcessingService, FileNameProcessingService>()
                .AddTransient<IPropertyProcessingService, PropertyProcessingService>();
        }

        public static IServiceCollection AddOrchestrationService(this IServiceCollection services) =>
            services.AddTransient<IFormContentOrchestrationService, FormContentOrchestrationService>();
    }
}
