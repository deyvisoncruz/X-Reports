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
    public class period
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Período")]
        public virtual String Name { get; set; }

        [Required]
        [Display(Name = "Token")]
        public virtual String token { get; set; }


    }

    public class periodMap : ClassMapping<period>
    {
        public periodMap()
        {
            Table("period");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);


            });
            Property(x => x.token, m =>
            {
                m.NotNullable(true);


            });
        }
    }
    public class periodRepository
    {
        public period Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var period = session.Get<period>(id);

                return period;
            }
        }

        public void Save(period period)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(period);
                transaction.Commit();
            }
        }

        public void Update(period period)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(period);
                transaction.Commit();
            }
        }

        public IList<period> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var period = session.CreateCriteria<period>().List<period>();

                return period;
            }
        }

        public void Delete(period period)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from period u where u.Id = (:id)")
                    .SetParameter("id", period.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }
    }

}