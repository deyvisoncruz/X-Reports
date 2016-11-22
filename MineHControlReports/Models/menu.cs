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
    public class menu
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Menu")]
        public virtual String Name { get; set; }

        [Required]
        [Display(Name = "Link")]
        public virtual String Link { get; set; }

        [Required]
        [Display(Name = "Ordem de Exibição")]
        public virtual String OrderBy { get; set; }


        

        //public ICollection<menuReport> menuReportCollection { get; set; }
    }

    public class menuMap : ClassMapping<menu>
    {
        public menuMap()
        {
            Table("menu");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);


            });
            Property(x => x.Link, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.OrderBy, m =>
            {
                m.NotNullable(true);


            });
        }
    }

    public class menuRepository
    {
        public menu Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var menu = session.Get<menu>(id);

                return menu;
            }
        }

        public void Save(menu menu)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(menu);
                transaction.Commit();
            }
        }

        public void Update(menu menu)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(menu);
                transaction.Commit();
            }
        }

        public IList<menu> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var menu = session.CreateCriteria<menu>().List<menu>();

                return menu;
            }
        }

        public void Delete(menu menu)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from menu u where u.Id = (:id)")
                    .SetParameter("id", menu.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

    }

}