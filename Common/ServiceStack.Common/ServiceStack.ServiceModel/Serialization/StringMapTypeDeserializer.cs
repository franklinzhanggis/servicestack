using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack.Common.Utils;
using ServiceStack.Logging;
using ServiceStack.Text.Common;
using ServiceStack.Text.Jsv;

namespace ServiceStack.ServiceModel.Serialization
{
	/// <summary>
	/// Serializer cache of delegates required to create a type from a string map (e.g. for REST urls)
	/// </summary>
	internal class StringMapTypeDeserializer
	{
		private static readonly ILog Log = LogManager.GetLogger(typeof(StringMapTypeDeserializer));

		internal class PropertySerializerEntry
		{
			public PropertySerializerEntry(SetPropertyDelegate propertySetFn, ParseStringDelegate propertyParseStringFn)
			{
				PropertySetFn = propertySetFn;
				PropertyParseStringFn = propertyParseStringFn;
			}

			public SetPropertyDelegate PropertySetFn;
			public ParseStringDelegate PropertyParseStringFn;
		}

		private readonly Type type;
		private readonly Dictionary<string, PropertySerializerEntry> propertySetterMap
			= new Dictionary<string, PropertySerializerEntry>();

		public StringMapTypeDeserializer(Type type)
		{
			this.type = type;

			foreach (var propertyInfo in type.GetProperties())
			{
				var propertySetFn = JsvDeserializeType.GetSetPropertyMethod(type, propertyInfo);
				var propertyParseStringFn = JsvReader.GetParseFn(propertyInfo.PropertyType);
				var propertySerializer = new PropertySerializerEntry(propertySetFn, propertyParseStringFn);
				propertySetterMap.Add(propertyInfo.Name, propertySerializer);
			}
		}

		public object CreateFromMap(IDictionary<string, string> keyValuePairs)
		{
			try
			{
				var result = ReflectionUtils.CreateInstance(type);
				foreach (var pair in keyValuePairs)
				{
					var propertyName = pair.Key;
					var propertyTextValue = pair.Value;

					PropertySerializerEntry propertySerializerEntry;
					if (!propertySetterMap.TryGetValue(propertyName, out propertySerializerEntry))
					{
						Log.WarnFormat("Property '{0}' does not exist on type '{1}'", propertyName, type.FullName);
						continue;
					}

					var value = propertySerializerEntry.PropertyParseStringFn(propertyTextValue);
					if (value == null)
					{
						Log.WarnFormat("Could not create instance on '{0}' for property '{1}' with text value '{2}'",
						               result, propertyName, propertyTextValue);
						continue;
					}
					propertySerializerEntry.PropertySetFn(result, value);
				}
				return result;

			}
			catch (Exception ex)
			{
				throw new SerializationException("KeyValueDataContractDeserializer: Error converting to type: " + ex.Message, ex);
			}
		}
	}
}