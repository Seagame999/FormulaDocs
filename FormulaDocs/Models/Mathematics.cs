//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using FormulaDocs.ValidationFile;

namespace FormulaDocs.Models
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    

    public partial class Mathematics
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string Description4 { get; set; }
        public string Description5 { get; set; }
        public string Image1 { get; set; }
        [FileExtensionsValidationImage]
        public HttpPostedFileBase image1http { get; set; }
        public string Image2 { get; set; }
        [FileExtensionsValidationImage]
        public HttpPostedFileBase image2http { get; set; }
        public string Image3 { get; set; }
        [FileExtensionsValidationImage]
        public HttpPostedFileBase image3http { get; set; }
        public string Image4 { get; set; }
        [FileExtensionsValidationImage]
        public HttpPostedFileBase image4http { get; set; }
        public string Image5 { get; set; }
        [FileExtensionsValidationImage]
        public HttpPostedFileBase image5http { get; set; }
        public string Category { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> DataIsActive { get; set; }
    }
}
