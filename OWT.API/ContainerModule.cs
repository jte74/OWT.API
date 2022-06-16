using Autofac;
using OWT.Data.Manager;
using OWT.Domain.Business;
using OWT.Domain.Interfaces;

namespace OWT.API
{
    public class ContainerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ContactManager>().As<IContactManager>();
            builder.RegisterType<ContactBusiness>().As<IContactBusiness>();
            builder.RegisterType<SkillBusiness>().As<ISkillBusiness>();
            builder.RegisterType<SkillManager>().As<ISkillManager>();
            builder.RegisterType<AuthBusiness>().As<IAuthBusiness>();
        }
    }
}
