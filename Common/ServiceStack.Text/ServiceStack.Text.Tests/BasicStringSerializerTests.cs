﻿using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Northwind.Common.ComplexModel;
using NUnit.Framework;
using ServiceStack.Common.Extensions;
using ServiceStack.Common.Tests.Models;
using System.Collections.Generic;
using ServiceStack.Text.Common;

namespace ServiceStack.Text.Tests
{
	[TestFixture]
	public class BasicStringSerializerTests
	{
		readonly char[] allCharsUsed = new[] {
			JsWriter.QuoteChar, JsWriter.ItemSeperator,
			JsWriter.MapStartChar, JsWriter.MapKeySeperator, JsWriter.MapEndChar,
			JsWriter.ListEndChar, JsWriter.ListEndChar,
		};

		readonly string fieldWithInvalidChars = string.Format("all {0} {1} {2} {3} {4} {5} {6} invalid chars",
			JsWriter.QuoteChar, JsWriter.ItemSeperator,
			JsWriter.MapStartChar, JsWriter.MapKeySeperator, JsWriter.MapEndChar,
			JsWriter.ListEndChar, JsWriter.ListEndChar);

		readonly int[] intValues = new[] { 1, 2, 3, 4, 5 };
		readonly double[] doubleValues = new[] { 1.0d, 2.0d, 3.0d, 4.0d, 5.0d };
		readonly string[] stringValues = new[] { "One", "Two", "Three", "Four", "Five" };
		readonly string[] stringValuesWithIllegalChar = new[] { "One", ",", "Three", "Four", "Five" };

		public enum TestEnum
		{
			EnumValue1,
			EnumValue2,
		}

		public class TestClass
		{
			[Required]
			public string Member1 { get; set; }

			public string Member2 { get; set; }

			[Required]
			public string Member3 { get; set; }

			[StringLength(1)]
			public string Member4 { get; set; }
		}

		[Test]
		public void Can_convert_comma_delimited_string_to_List_String()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(List<string>)), Is.True);

			var stringValueList = "[" + string.Join(",", stringValues) + "]";

			var convertedJsvValues = TypeSerializer.DeserializeFromString<List<string>>(stringValueList);
			Assert.That(convertedJsvValues, Is.EquivalentTo(stringValues));

			var convertedJsonValues = JsonSerializer.DeserializeFromString<List<string>>(stringValueList);
			Assert.That(convertedJsonValues, Is.EquivalentTo(stringValues));
		}

		[Test]
		public void Null_or_Empty_string_returns_null()
		{
			var convertedJsvValues = TypeSerializer.DeserializeFromString<List<string>>(null);
			Assert.That(convertedJsvValues, Is.EqualTo(null));

			convertedJsvValues = TypeSerializer.DeserializeFromString<List<string>>(string.Empty);
			Assert.That(convertedJsvValues, Is.EqualTo(null));
		}

		[Test]
		public void Empty_list_string_returns_empty_List()
		{
			var convertedStringValues = TypeSerializer.DeserializeFromString<List<string>>("[]");
			Assert.That(convertedStringValues, Is.EqualTo(new List<string>()));
		}

		[Test]
		public void Null_or_Empty_string_returns_null_Map()
		{
			var convertedStringValues = TypeSerializer.DeserializeFromString<Dictionary<string, string>>(null);
			Assert.That(convertedStringValues, Is.EqualTo(null));

			convertedStringValues = TypeSerializer.DeserializeFromString<Dictionary<string, string>>(string.Empty);
			Assert.That(convertedStringValues, Is.EqualTo(null));
		}

		[Test]
		public void Empty_map_string_returns_empty_List()
		{
			var convertedStringValues = TypeSerializer.DeserializeFromString<Dictionary<string, string>>("{}");
			Assert.That(convertedStringValues, Is.EqualTo(new Dictionary<string, string>()));
		}

		[Test]
		public void Can_convert_string_collection()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(string[])), Is.True);

			var stringValue = TypeSerializer.SerializeToString(stringValues);
			var expectedString = "[" + string.Join(",", stringValues.ToArray()) + "]";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_enum()
		{
			var enumValue = TestEnum.EnumValue1;
			var stringValue = TypeSerializer.SerializeToString(enumValue);
			var expectedString = TestEnum.EnumValue1.ToString();
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_nullable_enum()
		{
			TestEnum? enumValue = TestEnum.EnumValue1;
			var stringValue = TypeSerializer.SerializeToString(enumValue);
			var expectedString = TestEnum.EnumValue1.ToString();
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_to_nullable_enum()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(TestEnum?)), Is.True);

			TestEnum? enumValue = TestEnum.EnumValue1;
			var actualValue = TypeSerializer.DeserializeFromString<TestEnum?>(enumValue.ToString());
			Assert.That(actualValue, Is.EqualTo(enumValue));
		}

		[Test]
		public void Can_convert_to_nullable_enum_with_null_value()
		{
			var enumValue = TypeSerializer.DeserializeFromString<TestEnum?>(null);
			Assert.That(enumValue, Is.Null);
		}

		[Test]
		public void Can_convert_nullable_enum_with_null_value()
		{
			TestEnum? enumValue = null;
			var stringValue = TypeSerializer.SerializeToString(enumValue);
			Assert.That(stringValue, Is.Null);
		}

		[Test]
		public void Can_convert_Guid()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(Guid)), Is.True);

			var guidValue = Guid.NewGuid();
			var stringValue = TypeSerializer.SerializeToString(guidValue);
			var expectedString = guidValue.ToString("N");
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_datetime()
		{
			var dateValue = new DateTime(1979, 5, 9);
			var stringValue = TypeSerializer.SerializeToString(dateValue);
			var expectedString = "1979-05-09";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_to_datetime()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(DateTime)), Is.True);

			var dateValue = new DateTime(1979, 5, 9);
			var actualValue = TypeSerializer.DeserializeFromString<DateTime>("1979-05-09");
			Assert.That(actualValue, Is.EqualTo(dateValue));
		}

		[Test]
		public void Can_convert_nullable_datetime()
		{
			DateTime? dateValue = new DateTime(1979, 5, 9);
			var stringValue = TypeSerializer.SerializeToString(dateValue);
			var expectedString = "1979-05-09";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_to_nullable_datetime()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(DateTime?)), Is.True);

			DateTime? dateValue = new DateTime(1979, 5, 9);
			var actualValue = TypeSerializer.DeserializeFromString<DateTime?>("1979-05-09");
			Assert.That(actualValue, Is.EqualTo(dateValue));
		}

		[Test]
		public void Can_convert_string_List()
		{
			var stringValue = TypeSerializer.SerializeToString(stringValues.ToList());
			var expectedString = "[" + string.Join(",", stringValues.ToArray()) + "]";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_string_array()
		{
			var stringValue = TypeSerializer.SerializeToString(stringValues.ToArray());
			var expectedString = "[" + string.Join(",", stringValues.ToArray()) + "]";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_string_List_as_object()
		{
			var stringValue = TypeSerializer.SerializeToString((object)stringValues.ToList());
			var expectedString = "[" + string.Join(",", stringValues.ToArray()) + "]";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_empty_List()
		{
			var stringValue = TypeSerializer.SerializeToString(new List<string>());
			var expectedString = "[]";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_empty_List_as_object()
		{
			var stringValue = TypeSerializer.SerializeToString((object)new List<string>());
			var expectedString = "[]";
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_string_dictionary()
		{
			var stringDictionary = new Dictionary<string, string> 
				{
					{ "One", "1st" }, { "Two", "2nd" }, { "Three", "3rd" }
				};
			var expectedString = "{One:1st,Two:2nd,Three:3rd}";
			var stringValue = TypeSerializer.SerializeToString(stringDictionary);
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_parse_string_dictionary()
		{
			var stringDictionary = new Dictionary<string, string> 
				{
					{ "One", "1st" }, { "Two", "2nd" }, { "Three", "3rd" }
				};
			const string mapValues = "{One:1st,Two:2nd,Three:3rd}";
			var parsedDictionary = TypeSerializer.DeserializeFromString(mapValues, stringDictionary.GetType());
			Assert.That(parsedDictionary, Is.EquivalentTo(stringDictionary));
		}

		[Test]
		public void Can_convert_string_dictionary_as_object()
		{
			var stringDictionary = new Dictionary<string, string> {
			                                                      	{ "One", "1st" }, { "Two", "2nd" }, { "Three", "3rd" }
			                                                      };
			var expectedString = "{One:1st,Two:2nd,Three:3rd}";
			var stringValue = TypeSerializer.SerializeToString((object)stringDictionary);
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_string_dictionary_with_special_chars_as_object()
		{
			var stringDictionary = new Dictionary<string, string> 
				{
					{ "One", "\"1st" }, { "Two", "2:nd" }, { "Three", "3r,d" }, { "Four", "four%" }
				};
			var expectedString = "{One:\"\"\"1st\",Two:\"2:nd\",Three:\"3r,d\",Four:four%}";
			var stringValue = TypeSerializer.SerializeToString(stringDictionary);
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_parse_string_dictionary_with_special_chars_as_object()
		{
			var stringDictionary = new Dictionary<string, string> 
				{
					{ "One", "\"1st" }, { "Two", "2:nd" }, { "Three", "3r,d" }
				};
			const string mapValues = "{One:\"\"\"1st\",Two:2:nd,Three:\"3r,d\"}";
			var parsedDictionary = TypeSerializer.DeserializeFromString(mapValues, stringDictionary.GetType());
			Assert.That(parsedDictionary, Is.EquivalentTo(stringDictionary));
		}

		[Test]
		public void Can_convert_string_list_with_special_chars_as_object()
		{
			var stringList = new List<string> 
				{
					"\"1st", "2:nd", "3r,d", "four%"
				};
			var expectedString = "[\"\"\"1st\",\"2:nd\",\"3r,d\",four%]";
			var stringValue = TypeSerializer.SerializeToString(stringList);
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_parse_string_list_with_special_chars_as_object()
		{
			var stringList = new List<string> 
				{
					"\"1st", "2:nd", "3r,d", "four%"
				};
			const string listValues = "[\"\"\"1st\",2:nd,\"3r,d\",four%]";
			var parsedList = TypeSerializer.DeserializeFromString(listValues, stringList.GetType());
			Assert.That(parsedList, Is.EquivalentTo(stringList));
		}

		[Test]
		public void Can_convert_Byte_array()
		{
			var byteArrayValue = new byte[] { 0, 65, 97, 255, };
			var stringValue = TypeSerializer.SerializeToString(byteArrayValue);
			var expectedString = Convert.ToBase64String(byteArrayValue);
			Assert.That(stringValue, Is.EqualTo(expectedString));
		}

		[Test]
		public void Can_convert_to_Byte_array()
		{
			Assert.That(TypeSerializer.CanCreateFromString(typeof(byte[])), Is.True);

			var byteArrayValue = new byte[] { 0, 65, 97, 255, };
			var byteArrayString = TypeSerializer.SerializeToString(byteArrayValue);
			var actualValue = TypeSerializer.DeserializeFromString<byte[]>(byteArrayString);
			Assert.That(actualValue, Is.EqualTo(byteArrayValue));
		}

		[Test]
		public void Can_convert_string_to_List()
		{
			var fromHashSet = stringValues;
			var toHashSet = Serialize(fromHashSet);

			Assert.That(toHashSet.EquivalentTo(fromHashSet), Is.True);
		}

		[Test]
		public void Can_convert_string_to_string_HashSet()
		{
			var fromHashSet = new HashSet<string>(stringValues);
			var toHashSet = Serialize(fromHashSet);

			Assert.That(toHashSet.EquivalentTo(fromHashSet), Is.True);
		}

		[Test]
		public void Can_convert_string_to_int_HashSet()
		{
			var fromHashSet = new HashSet<int>(intValues);
			var toHashSet = Serialize(fromHashSet);

			Assert.That(toHashSet.EquivalentTo(fromHashSet), Is.True);
		}

		[Test]
		public void Can_convert_string_to_double_HashSet()
		{
			var fromHashSet = new HashSet<double>(doubleValues);
			var toHashSet = Serialize(fromHashSet);

			Assert.That(toHashSet.EquivalentTo(fromHashSet), Is.True);
		}

		public T Serialize<T>(T model)
		{
			var strModel = TypeSerializer.SerializeToString(model);
			Console.WriteLine("Len: " + strModel.Length + ", " + strModel);
			var toModel = TypeSerializer.DeserializeFromString<T>(strModel);
			return toModel;
		}

		[Test]
		public void Can_convert_ModelWithFieldsOfDifferentTypes()
		{
			var model = ModelWithFieldsOfDifferentTypes.Create(1);
			var toModel = Serialize(model);

			ModelWithFieldsOfDifferentTypes.AssertIsEqual(toModel, model);
		}

		[Test]
		public void Can_convert_ModelWithFieldsOfNullableTypes()
		{
			var model = ModelWithFieldsOfNullableTypes.Create(1);
			var toModel = Serialize(model);

			ModelWithFieldsOfNullableTypes.AssertIsEqual(toModel, model);
		}

		[Test]
		public void Can_convert_ModelWithFieldsOfNullableTypes_of_nullables()
		{
			var model = new ModelWithFieldsOfNullableTypes();
			var toModel = Serialize(model);

			ModelWithFieldsOfNullableTypes.AssertIsEqual(toModel, model);
		}

		[Ignore("Causing infinite recursion in TypeToString")]
		[Test]
		public void Can_convert_ModelWithComplexTypes()
		{
			var model = ModelWithComplexTypes.Create(1);
			var toModel = Serialize(model);

			ModelWithComplexTypes.AssertIsEqual(toModel, model);
		}

		[Test]
		public void Can_convert_model_with_TypeChar()
		{
			var model = new ModelWithIdAndName { Id = 1, Name = "in } valid" };
			var toModel = Serialize(model);

			ModelWithIdAndName.AssertIsEqual(toModel, model);
		}

		[Test]
		public void Can_convert_model_with_ListChar()
		{
			var model = new ModelWithIdAndName { Id = 1, Name = "in [ valid" };
			var toModel = Serialize(model);
			ModelWithIdAndName.AssertIsEqual(toModel, model);

			var model2 = new ModelWithIdAndName { Id = 1, Name = "in valid]" };
			var toModel2 = Serialize(model2);
			ModelWithIdAndName.AssertIsEqual(toModel2, model2);
		}

		[Test]
		public void Can_convert_ModelWithMapAndList_with_ListChar()
		{
			var model = new ModelWithMapAndList<ModelWithIdAndName>
			{
				Id = 1,
				Name = "in [ valid",
				List = new List<ModelWithIdAndName> {
					new ModelWithIdAndName{Id = 1, Name = "field [in valid] has stuff"},
					new ModelWithIdAndName{Id = 1, Name = "field [in valid] has stuff"},
				},
			};
			var toModel = Serialize(model);
			//ModelWithMapAndList.AssertIsEqual(toModel, model);
		}

		[Test]
		public void Can_convert_ArrayDtoWithOrders()
		{
			var model = DtoFactory.ArrayDtoWithOrders;
			var toModel = Serialize(model);

			Assert.That(model.Equals(toModel), Is.True);
		}

		[Test]
		public void Can_convert_Field_Map_or_List_with_invalid_chars()
		{
			var instance = new ModelWithMapAndList<string>
			{
				Id = 1,
				Name = fieldWithInvalidChars,
				List = new List<string> { fieldWithInvalidChars, fieldWithInvalidChars },
				Map = new Dictionary<string, string> { { fieldWithInvalidChars, fieldWithInvalidChars } },
			};

			Serialize(instance);
		}

		[Test]
		public void Can_convert_Field_Map_or_List_with_single_invalid_char()
		{
			foreach (var invalidChar in allCharsUsed)
			{
				var singleInvalidChar = string.Format("a {0} b", invalidChar);

				var instance = new ModelWithMapAndList<string>
				{
					Id = 1,
					Name = singleInvalidChar,
					List = new List<string> { singleInvalidChar, singleInvalidChar },
					Map = new Dictionary<string, string> { { singleInvalidChar, singleInvalidChar } },
				};

				Serialize(instance);
			}
		}

		[Test]
		public void Can_convert_CustomerDto()
		{
			var model = DtoFactory.CustomerDto;
			var toModel = Serialize(model);

			Assert.That(model.Equals(toModel), Is.True);
		}

		[Test]
		public void Can_convert_CustomerOrderListDto()
		{
			var model = DtoFactory.CustomerOrderListDto;
			var toModel = Serialize(model);

			Assert.That(model.Equals(toModel), Is.True);
		}

	}
}