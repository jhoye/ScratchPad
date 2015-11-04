using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scratch.Test
{
    [TestClass]
    public class EnumsTests
    {
        #region setup / teardown

        private enum TestEnum
        {
            [System.ComponentModel.Description("Uno")]
            One = 1,
            Two = 2
        }

        private struct BogusEnumType : IConvertible
        {
            public TypeCode GetTypeCode()
            {
                throw new NotImplementedException();
            }

            public bool ToBoolean(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public char ToChar(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public sbyte ToSByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public byte ToByte(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public short ToInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ushort ToUInt16(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public int ToInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public uint ToUInt32(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public long ToInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public ulong ToUInt64(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public float ToSingle(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public double ToDouble(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public decimal ToDecimal(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public DateTime ToDateTime(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public string ToString(IFormatProvider provider)
            {
                throw new NotImplementedException();
            }

            public object ToType(Type conversionType, IFormatProvider provider)
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        [TestMethod]
        public void IsInRange_returns_false_when_value_is_out_of_range()
        {
            // arrange / act / assert
            Assert.IsFalse(
                Enums.IsInRange<TestEnum>(0) && 
                Enums.IsInRange<TestEnum>(3));
        }

        [TestMethod]
        public void IsInRange_returns_true_when_value_is_in_range()
        {
            // arrange / act / assert
            Assert.IsTrue(
                Enums.IsInRange<TestEnum>(1) &&
                Enums.IsInRange<TestEnum>(2));
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void IsInRange_throws_exception_when_type_is_not_enumeration()
        {
            // arrange / act / assert
            Enums.IsInRange<BogusEnumType>(0);
        }

        [TestMethod]
        public void GetDescription_returns_description_when_set()
        {
            // arrange
            const string expected = "Uno";

            // act
            var actual = Enums.GetDescription(TestEnum.One);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetDescription_returns_symbol_name_when_set()
        {
            // arrange
            const string expected = "Two";

            // act
            var actual = Enums.GetDescription(TestEnum.Two);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseEnum_returns_value_when_it_is_valid()
        {
            // arrange
            var expected = TestEnum.One;

            // act 
            var actual = Enums.ParseEnum<TestEnum>("One");

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseEnum_throws_exception_when_it_is_not_valid()
        {
            // arrange / act / assert
            Enums.ParseEnum<TestEnum>("Zero");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseEnum_throws_exception_when_type_is_not_enumeration()
        {
            // arrange / act / assert
            Enums.ParseEnum<BogusEnumType>("0");
        }

        [TestMethod]
        public void CastEnum_returns_value_when_it_is_valid()
        {
            // arrange
            const TestEnum expected = TestEnum.One;

            // act
            var actual = Enums.CastEnum<TestEnum>(1);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CastEnum_throws_exception_when_value_is_out_of_range()
        {
            // arrange / act / assert
            Enums.CastEnum<TestEnum>(0);
        }
    }
}
