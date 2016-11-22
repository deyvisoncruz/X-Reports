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
    public class menuRole
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [ForeignKey("MenuId")]
        [Display(Name = "Menu")]
        public virtual int MenuId { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        [Display(Name = "Perfil")]
        public virtual int RoleId { get; set; }

        public virtual String MenuGet()
        {
            menuRepository mr = new menuRepository();
            return mr.Get(MenuId).Name;
        }

        public virtual String RoleGet()
        {
            roleRepository r = new roleRepository();
            return r.Get(RoleId).Name;
        }
        
    }

    public class menuRoleMap: ClassMapping<menuRole>
    {
        public menuRoleMap()
        {
            Table("menuRole");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            

            Property(x => x.MenuId, m =>
            {
                m.Column("MenuId");
            });
            Property(x => x.RoleId, m =>
            {
                m.Column("RoleId");
            });

           
        }
    }

    public class menuRoleRepository
    {
        public menuRole Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var menuRole = session.Get<menuRole>(id);

                return menuRole;
            }
        }



        public void Save(menuRole menuRole)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(menuRole);
                transaction.Commit();
            }
        }

        public void Update(menuRole menuRole)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(menuRole);
                transaction.Commit();
            }
        }

        public IList<menuRole> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var menuRole = session.CreateCriteria<menuRole>().List<menuRole>();

                return menuRole;
            }
        }

        public void Delete(menuRole menuRole)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from menuRole u where u.Id = (:id)")
                    .SetParameter("id", menuRole.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

    }
}