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
        public ChangeSetterResult<TDestination> Map<TSource, TDestination>(ref TSource source, ref TDestination destination, List<CustomFieldMapping> fieldForMappings)
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

            var response = new ChangeSetterResult<TDestination>();

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

                    var destinationValue = destination.GetPropValue(fieldForMapping.DestinationField);
                    var sourceValue = source.GetPropValue(fieldForMapping.SourceField);

                    if (!destinationValue.Equals(sourceValue))
                    {
                        destination.SetPropertyValue(fieldForMapping.DestinationField, sourceValue);
                        response.HasChanges = true;
                    } 
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

                    var destinationValue = destination.GetFieldValue(fieldForMapping.DestinationField);
                    var sourceValue = source.GetFieldValue(fieldForMapping.SourceField);

                    if (!destinationValue.Equals(sourceValue))
                    {
                        destination.SetFieldValue(fieldForMapping.DestinationField, sourceValue);
                        response.HasChanges = true;
                    }
                } 
            }

            response.Value = destination;
             
            return response;
        }
    }
}
