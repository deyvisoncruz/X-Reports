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
    public class group_equipament_links
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        [Required]
        [Display(Name = "Tipo de Equipamento")]
        public virtual String Name { get; set; }
    }

    public class group_equipament_linksMap : ClassMapping<group_equipament_links>
    {
        public group_equipament_linksMap()
        {
            Table("group_equipament_links");
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

    public class group_equipament_linksRepository
    {
        public group_equipament_links Get(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var group_equipament_links = session.Get<group_equipament_links>(id);

                return group_equipament_links;
            }
        }


        public IList<group_equipament_links> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                var group_equipament_links = session.CreateCriteria<group_equipament_links>().List<group_equipament_links>();

                return group_equipament_links;
            }
        }


    }
}