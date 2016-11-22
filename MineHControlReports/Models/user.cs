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
using System.Web.Mvc;

namespace MineHControlReports.Models
{
    public class user
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public virtual String Name { get; set; }

        [Key]
        [Required]
        [Display(Name = "Login")]
        public virtual String Login { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Senha")]
        public virtual String Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senhas diferentes, favor redefini-las.")]
        public virtual string ConfirmPassword { get; set; }

        [Required]
        [ForeignKey("RoleId")]
        [Display(Name = "Perfil")]
        public virtual int RoleId { get; set; }

        public virtual String RoleGet()
        {
            roleRepository mr = new roleRepository();
            return mr.Get(RoleId).Name;
        }
    }

    public class userMap : ClassMapping<user>
    {
        public userMap()
        {
            Table("user");
            Id(x => x.Id, m =>
            {
                m.Column("Id");
                m.Generator(Generators.Identity);
            });
            Property(x => x.Name, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.Login, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.Password, m =>
            {
                m.NotNullable(true);


            });

            Property(x => x.ConfirmPassword, m =>
            {
                m.NotNullable(true);


            });


            Property(x => x.RoleId, m =>
            {
                m.Column("RoleId");
            });
        }
    }



    public class userRepository
    {
        public user Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var user = session.Get<user>(id);

                return user;
            }
        }

        public void Save(user user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(user);
                transaction.Commit();
            }
        }

        public void Update(user user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(user);
                transaction.Commit();
            }
        }

        public IList<user> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var user = session.CreateCriteria<user>().List<user>();

                return user;
            }
        }

        public void Delete(user user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.CreateQuery("delete from user u where u.Id = (:id)")
                    .SetParameter("id", user.Id)
                    .ExecuteUpdate();
                transaction.Commit();
            }
        }

    }

}