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
    public class equipament_groups
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Equipamento")]
        public virtual String Name { get; set; }
    }

    public class equipament_groupsMap : ClassMapping<equipament_groups>
    {
        public equipament_groupsMap()
        {
            Table("equipament_groups");
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

    public class equipament_groupsRepository
    {
        public equipament_groups Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var equipament_groups = session.Get<equipament_groups>(id);

                return equipament_groups;
            }
        }


        public IList<equipament_groups> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var equipament_groups = session.CreateCriteria<equipament_groups>().List<equipament_groups>();

                return equipament_groups;
            }
        }


    }
}