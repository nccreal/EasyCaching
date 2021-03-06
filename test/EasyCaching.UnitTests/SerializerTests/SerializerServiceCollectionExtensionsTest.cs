namespace EasyCaching.UnitTests
{
    using EasyCaching.Core;
    using EasyCaching.Core.Serialization;
    using EasyCaching.Serialization.Json;
    using EasyCaching.Serialization.MessagePack;
    using EasyCaching.Serialization.Protobuf;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using Xunit;

    public class SerializerServiceCollectionExtensionsTest
    {
        [Fact]
        public void AddDefaultMessagePackSerializer_Should_Get_DefaultMessagePackSerializer()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddEasyCaching(x => x.WithMessagePack());

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var serializer = serviceProvider.GetService<IEasyCachingSerializer>();

            Assert.IsType<DefaultMessagePackSerializer>(serializer);
        }

        [Fact]
        public void AddDefaultJsonSerializer_Should_Get_DefaultJsonSerializer()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddEasyCaching(x => x.WithJson());

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var serializer = serviceProvider.GetService<IEasyCachingSerializer>();

            Assert.IsType<DefaultJsonSerializer>(serializer);
        }

        [Fact]
        public void AddDefaultProtobufSerializer_Should_Get_DefaultProtobufSerializer()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddEasyCaching(x => x.WithProtobuf());

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var serializer = serviceProvider.GetService<IEasyCachingSerializer>();

            Assert.IsType<DefaultProtobufSerializer>(serializer);
        }
    }
}