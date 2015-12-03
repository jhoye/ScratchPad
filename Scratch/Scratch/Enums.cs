using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Scratch
{
    public static class Enums
    {
        #region enumerated types

        public enum Andons
        {
            None,
            Green,
            Yellow,
            Red
        }

        public enum FieldTypes
        {
            [Description("Hidden")]
            Hidden = 0,
            [Description("Check Box")]
            CheckBox,
            [Description("Yes/No Drop-Down")]
            YesNoDropDown,
            [Description("Text Box")]
            TextBox,
            [Description("Text Area")]
            TextArea,
            [Description("Rich Text Area")]
            RichTextEditor,
            [Description("Date")]
            Date,
            [Description("Time")]
            Time,
            [Description("Date and Time")]
            DateTime,
            [Description("Drop-Down")]
            DropDown,
            [Description("Radio Button List")]
            RadioButtonList,
            [Description("Check Box List")]
            CheckBoxList,
            [Description("Integer")]
            Integer,
            [Description("Decimal")]
            Decimal,
            [Description("Floating Point Number")]
            FloatingPointNumber
        }

        #endregion

        /// <summary>
        /// Determines whether an integer value is defined in an enumerated type
        /// </summary>
        /// <typeparam name="T">enumerated type</typeparam>
        /// <param name="value">test value</param>
        /// <returns>true if in range</returns>
        public static bool IsInRange<T>(int value) where T : struct, IConvertible
        {
            var type = typeof(T);

            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            return Enum.GetValues(type).Cast<object>().Any(enumValue => (int)enumValue == value);
        }

        /// <summary>
        /// Gets the description for a specified value in an enumerated type's 
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>Description if set</returns>
        public static string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Parses a string as an enumerated type's value
        /// </summary>
        /// <typeparam name="T">enumerated type</typeparam>
        /// <param name="value">value</param>
        /// <returns>enumerated type's value</returns>
        public static T ParseEnum<T>(string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Casts number to an enumerated type's value
        /// </summary>
        /// <typeparam name="T">enumerated type</typeparam>
        /// <param name="value">value</param>
        /// <returns></returns>
        public static T CastEnum<T>(int value) where T : struct, IConvertible
        {
            if (!IsInRange<T>(value))
            {
                throw new ArgumentOutOfRangeException();
            }

            return (T)(object)value;
        }
    }
}