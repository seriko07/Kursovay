//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovay
{
    using System;
    using System.Collections.Generic;
    
    public partial class Grade
    {
        public int ID { get; set; }
        public Nullable<int> assessment_3 { get; set; }
        public Nullable<int> assessment_4 { get; set; }
        public Nullable<int> assessment_5 { get; set; }
        public Nullable<int> ID_Test { get; set; }
    
        public virtual Test Test { get; set; }
    }
}