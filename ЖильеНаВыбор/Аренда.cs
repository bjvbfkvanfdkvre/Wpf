//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ЖильеНаВыбор
{
    using System;
    using System.Collections.Generic;
    
    public partial class Аренда
    {
        public int КодАренды { get; set; }
        public int КодПользователя { get; set; }
        public int КодКвартиры { get; set; }
        public Nullable<System.DateTime> ДатаЗаезда { get; set; }
        public Nullable<System.DateTime> ДатаВыезда { get; set; }
        public string Статус { get; set; }
    
        public virtual Квартиры Квартиры { get; set; }
        public virtual Пользователи Пользователи { get; set; }
    }
}
