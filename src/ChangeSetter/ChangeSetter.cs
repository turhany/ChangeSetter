using ChangeSetter.Exceptions;
using ChangeSetter.Extensions;
using ChangeSetter.Models;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace ChangeSetter
{
    public class ChangeSetter
    {
        public TDestination Map<TSource, TDestination>(ref TSource source, ref TDestination destination, List<CustomFieldMapping> fieldForMappings)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (destination == null)
            {
                throw new ArgumentNullException(nameof(destination));
            }

            if (fieldForMappings != null && !fieldForMappings.Any())
            {
                throw new ArgumentNullException(nameof(fieldForMappings));
            }

            foreach (var fieldForMapping in fieldForMappings)
            {
                if (fieldForMapping.MemberType == MemberType.Property)
                {
                    if (!destination.HasProperty(fieldForMapping.DestinationField))
                    {
                        throw new MappingFieldsNotExistException();
                    }

                    if (!source.HasProperty(fieldForMapping.SourceField))
                    {
                        throw new MappingFieldsNotExistException();
                    }

                    destination.SetPropertyValue(
                        fieldForMapping.DestinationField,
                        source.GetPropertyValue<object>(fieldForMapping.SourceField));
                }
                else if (fieldForMapping.MemberType == MemberType.Field)
                {
                    if (!destination.HasField(fieldForMapping.DestinationField))
                    {
                        throw new MappingFieldsNotExistException();
                    }

                    if (!source.HasField(fieldForMapping.SourceField))
                    {
                        throw new MappingFieldsNotExistException();
                    }

                    destination.SetFieldValue(
                        fieldForMapping.DestinationField,
                        source.GetFieldValue<object>(fieldForMapping.SourceField));
                } 
            }
             
            return destination;
        }
    }
}
