
using MineHControlReports.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MineHControlReports.Dao
{
    public static class NHibernateHelper
    {
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;
        private static HbmMapping mapping;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
               
               /* sessionFactory = Fluently.Configure()
                                .Database(MySQLConfiguration.Standard
                                .ConnectionString(@"Server=localhost;Database=mine_crontrol_21;User ID=root;Password=root230852"))
                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<kpisMap>())
                                .BuildSessionFactory();*/

                if (sessionFactory == null)
                    sessionFactory = Configuration.BuildSessionFactory();

                

                return sessionFactory;
                
            }
        }

        public static Configuration Configuration
        {
            get
            {
                if (configuration == null)
                    configuration = CreateConfiguration();

                return configuration;
            }
        }

        public static HbmMapping Mapping
        {
            get
            {
                if (mapping == null)
                    mapping = CreateMapping();

                return mapping;
            }
        }

        private static Configuration CreateConfiguration()
        {
            var configuration = new Configuration();
            configuration.Configure();
            configuration.AddDeserializedMapping(Mapping, null);

            return configuration;
        }

        private static HbmMapping CreateMapping()
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(new List<System.Type> { typeof(kpisMap) });
            mapper.AddMappings(new List<System.Type> { typeof(menuMap) });
            mapper.AddMappings(new List<System.Type> { typeof(menuReportMap) });
            mapper.AddMappings(new List<System.Type> { typeof(parameterMap) });
            mapper.AddMappings(new List<System.Type> { typeof(roleMap) });
            mapper.AddMappings(new List<System.Type> { typeof(menuRoleMap) });
            mapper.AddMappings(new List<System.Type> { typeof(userMap) });
            mapper.AddMappings(new List<System.Type> { typeof(equipamentsMap) });
            mapper.AddMappings(new List<System.Type> { typeof(equipament_groupsMap) });
            mapper.AddMappings(new List<System.Type> { typeof(group_equipament_linksMap) });
            mapper.AddMappings(new List<System.Type> { typeof(goalMap) });
            mapper.AddMappings(new List<System.Type> { typeof(periodMap) });


            return mapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}