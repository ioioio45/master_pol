//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace master_pol_enn
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partners_import
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partners_import()
        {
            this.Partner_products_import = new HashSet<Partner_products_import>();
        }
    
        public int id_partners { get; set; }
        public string Тип_партнера { get; set; }
        public string Наименование_партнера { get; set; }
        public string Директор { get; set; }
        public string Электронная_почта_партнера { get; set; }
        public string Телефон_партнера { get; set; }
        public string Юридический_адрес_партнера { get; set; }
        public Nullable<double> ИНН { get; set; }
        public Nullable<double> Рейтинг { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partner_products_import> Partner_products_import { get; set; }
    }
}
