using MineHControlReports.Dao;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MineHControlReports.Models
{
    public class parameter
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]

        [Display(Name = "Parametro")]
        public virtual String Name { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual String Descr { get; set; }

        [Display(Name = "Valor")]
        public virtual String Value { get; set; }


        [Required]
        [Display(Name = "Token")]
        public virtual String Token { get; set; }
    }

    public class parameterMap : ClassMapping<parameter>
    {
        public parameterMap()
        {
            Table("parameter");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);
                
               
            });
            Property(x => x.Descr, m =>
            {
                m.NotNullable(true);


            });
            Property(x => x.Value, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.Token, m =>
            {
                m.NotNullable(true);


            });
        }

    }

    public class parameterRepository
    {
        public parameter Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var parameter = session.Get<parameter>(id);

                return parameter;
            }
        }

        public void Save(parameter parameter)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(parameter);
                transaction.Commit();
            }
        }

        public void Update(parameter parameter)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(parameter);
                transaction.Commit();
            }
        }

        public IList<parameter> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var parameter = session.CreateCriteria<parameter>().List<parameter>();

                return parameter;
            }
        }

        public void Delete(parameter parameter)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from parameter u where u.Id = (:id)")
                    .SetParameter("id", parameter.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }
    }
}