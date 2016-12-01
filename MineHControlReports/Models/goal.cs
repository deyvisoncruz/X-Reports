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
    public class goal
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }


        [ForeignKey("KpiId")]
        [Display(Name = "Kpi")]
        public virtual int KpiId { get; set; }

        [ForeignKey("PeriodId")]
        [Display(Name = "Período")]
        public virtual int PeriodId { get; set; }


        [DataType(DataType.Date)] 
        [Display(Name = "Data Inicial")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime StartDate { get; set; }

       
        [Required]
        [Display(Name = "Tipo")]
        public virtual int TypeEntity { get; set; }


        [Display(Name = "Entidade")]
        public virtual int EntityId { get; set; }

        public virtual String KpiGet()
        {
            kpisRepository r = new kpisRepository();
            return r.Get(KpiId).Name;
        }


       

    }



    public class goalMap : ClassMapping<goal>
    {
        public goalMap()
        {
            Table("goal");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            
            Property(x => x.KpiId, m =>
            {
                m.Column("KpiId");
            });

            Property(x => x.PeriodId, m =>
            {
                m.Column("PeriodId");
            });

            Property(x => x.StartDate, m =>
            {
                m.NotNullable(true);


            });


           


            Property(x => x.TypeEntity, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.EntityId, m =>
            {
                m.NotNullable(true);


            });
        }
    }

    public class goalRepository
    {
        public goal Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var goal = session.Get<goal>(id);

                return goal;
            }
        }

        public void Save(goal goal)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(goal);
                transaction.Commit();
            }
        }

        public void Update(goal goal)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(goal);
                transaction.Commit();
            }
        }

        public IList<goal> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var goal = session.CreateCriteria<goal>().List<goal>();

                return goal;
            }
        }

        public void Delete(goal goal)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from goal u where u.Id = (:id)")
                    .SetParameter("id", goal.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

    }
}