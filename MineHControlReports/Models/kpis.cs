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
    public class kpis
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Kpis")]
        public virtual String Name { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public virtual String Descr { get; set; }

        [Display(Name = "Unidade")]
        public virtual  String Unity { get; set; }


        [Required]
        [Display(Name = "Token")]
        public virtual String Token { get; set; }

        public kpis()
        {
           
        }

    }

    public class kpisMap : ClassMapping<kpis>
    {
        public kpisMap()
        {
            Table("kpis");
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
            Property(x => x.Unity, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.Token, m =>
            {
                m.NotNullable(true);


            });
        }
    }
    public class kpisRepository
    {
        public kpis Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var kpi = session.Get<kpis>(id);

                return kpi;
            }
        }

        public void Save(kpis kpi)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(kpi);
                transaction.Commit();
            }
        }

        public void Update(kpis kpi)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(kpi);
                transaction.Commit();
            }
        }

        public IList<kpis> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var users = session.CreateCriteria<kpis>().List<kpis>();
               
                return users;
            }
        }

        public void Delete(kpis kpi)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from kpis u where u.Id = (:id)")
                    .SetParameter("id", kpi.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }
    }
}