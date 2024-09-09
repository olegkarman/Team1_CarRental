﻿using System.Data;
using Dapper;


namespace CarRental.Data.Dapper
{
    public class GuidToStringTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        // METHODS

        public override void SetValue(IDbDataParameter parameter, Guid id)
        {
            parameter.Value = id.ToString().ToUpper();
        }

        public override Guid Parse(object guidObject)
        {
            return new Guid(guidObject.ToString());
        }
    }
}
