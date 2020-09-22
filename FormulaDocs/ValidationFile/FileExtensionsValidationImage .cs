﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace FormulaDocs.ValidationFile
{
    public class FileExtensionsValidationImage : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                HttpPostedFileWrapper file = (HttpPostedFileWrapper)value;
                string extention = Path.GetExtension(file.FileName);
                string jpg1 = ".jpg", jpg2 = ".JPG", jpg3 = ".jpeg", jpg4 = ".JPEG";
                string png1 = ".png", png2 = ".PNG";
                string bmp1 = ".bmp", bmp2 = ".BMP";

                if (string.Equals(extention, jpg1) == true || string.Equals(extention, jpg2) == true || string.Equals(extention, jpg3) == true || string.Equals(extention, jpg4) == true ||
                    string.Equals(extention, png1) == true || string.Equals(extention, png2) == true ||
                    string.Equals(extention, bmp1) == true || string.Equals(extention, bmp2) == true)
                {
                    return ValidationResult.Success;

                }

                return new ValidationResult("กรุณาใส่รูปภาพ(JPG,PNG,BMP)");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}