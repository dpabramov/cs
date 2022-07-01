using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace _22_WebApplication1.Addithional
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class OtherValueAttribute : ValidationAttribute
    {
        public string OtherProperty { get; private set; }

        public OtherValueAttribute(string otherProperty)
            {
            if (otherProperty == null)
            {
                throw new ArgumentNullException("otherProperty");
            }
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Cannot find property {OtherProperty}");
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (Equals(value, otherPropertyValue))
            {
                return new ValidationResult($"{validationContext.MemberName} must not be equal {OtherProperty}");
            }
            return null;
        }
    }
}
