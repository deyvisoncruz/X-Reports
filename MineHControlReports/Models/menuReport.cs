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
    public class menuReport
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name ="Relatório")]
        public virtual String Name { get; set; }

        [Required]
        [ForeignKey("MenuRefId")]
        [Display(Name = "Menu")]
        public virtual int MenuId { get; set; }

        [Required]
        [Display(Name = "Link")]
        public virtual String Link { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public virtual int TypeReport { get; set; }

        [Required]
        [Display(Name = "Ordem de Exibição")]
        public virtual String OrderBy { get; set; }

        public virtual String MenuGet()
        {
            menuRepository mr = new menuRepository();
            return mr.Get(MenuId).Name;
        }


        //public ICollection<menuReportReport> menuReportReportCollection { get; set; }
    }

    public class menuReportMap : ClassMapping<menuReport>
    {
        public menuReportMap()
        {
            Table("menuReport");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.MenuId, m =>
            {             
                m.Column("MenuId");
            });

            Property(x => x.Link, m =>
            {
                m.NotNullable(true);


            });
            Property(x => x.TypeReport, m =>
            {
                m.NotNullable(true);


            });
            Property(x => x.OrderBy, m =>
            {
                m.NotNullable(true);


            });
        }
    }

    public class menuReportRepository
    {
        public menuReport Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var menuReport = session.Get<menuReport>(id);

                return menuReport;
            }
        }

        public void Save(menuReport menuReport)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(menuReport);
                transaction.Commit();
            }
        }

        public void Update(menuReport menuReport)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(menuReport);
                transaction.Commit();
            }
        }

        public IList<menuReport> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var menuReport = session.CreateCriteria<menuReport>().List<menuReport>();

                return menuReport;
            }
        }

        public void Delete(menuReport menuReport)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from menuReport u where u.Id = (:id)")
                    .SetParameter("id", menuReport.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

    }

}