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
    public class equipaments
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Equipamento")]
        public virtual String Name { get; set; }
    }

    public class equipamentsMap : ClassMapping<equipaments>
    {
        public equipamentsMap()
        {
            Table("equipaments");
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

    public class equipamentsRepository
    {
        public equipaments Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var equipaments = session.Get<equipaments>(id);

                return equipaments;
            }
        }


        public IList<equipaments> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var equipaments = session.CreateCriteria<equipaments>().List<equipaments>();

                return equipaments;
            }
        }

       
    }
}