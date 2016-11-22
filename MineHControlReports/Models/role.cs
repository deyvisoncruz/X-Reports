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
    public class role
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Perfil")]
        public virtual String Name { get; set; }


    }

    public class roleMap : ClassMapping<role>
    {
        public roleMap()
        {
            Table("role");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);
                
               
            });
            
        }
    }
    public class roleRepository
    {
        public role Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var role = session.Get<role>(id);

                return role;
            }
        }

        public void Save(role role)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(role);
                transaction.Commit();
            }
        }

        public void Update(role role)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(role);
                transaction.Commit();
            }
        }

        public IList<role> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var role = session.CreateCriteria<role>().List<role>();
               
                return role;
            }
        }

        public void Delete(role role)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from role u where u.Id = (:id)")
                    .SetParameter("id", role.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }
    }

}