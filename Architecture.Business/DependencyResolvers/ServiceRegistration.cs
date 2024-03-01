using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Architecture.Business.Abstract;
using Architecture.Business.AutoMapper;
using Architecture.Business.Concrete;
using Architecture.Business.Consumers;
using Architecture.Core.EventBus;

using Architecture.Core.Utilities.MailHelper;
using Architecture.DataAccess.Abstract;
using Architecture.DataAccess.Concrete.EntityFramework;
using Architecture.Entities.Commands;
using AutoMapper;
using Architecture.Core.EventBus;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Architecture.Business.DependencyResolvers
{
    public static class ServiceRegistration
{

    public static void AddBusinesRegistration(this IServiceCollection services)
    { services.AddMemoryCache();

            services.AddScoped<AppDbContext>();

			services.AddScoped<IProductDal, EfProductDal>();
			services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<ISpecificationDal, EfSpecificationDal>();
            services.AddScoped<ISpecificationService, SpecificationManager>();

            services.AddScoped<IWishListDal, EfWishListDal>();
            services.AddScoped<IWishListService, WishListManager>();

            services.AddScoped<ITagDal,EfTagDal>();
            services.AddScoped<ITagService,TagManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<IUserDal, EfUserDal>();
            services.AddScoped<IUserService, UserManager>();

            services.AddScoped<IMailSender, MailSender>();



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddMassTransit(config =>
            {
                config.AddConsumer<SendEmailConsumer>();

                config.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host("amqps://qqgrfgqw:sTvsCku3bUTWWpfpGINxDc9EN0TotHSE@cow.rmq2.cloudamqp.com/qqgrfgqw");
                    cfg.Message<SendEmailCommand>(x => x.SetEntityName("SendEmailCommand"));

                    cfg.ReceiveEndpoint("send-email-command", c =>
                    {
                        c.ConfigureConsumer<SendEmailConsumer>(ctx);
                    });
                });
            });






}
}
}