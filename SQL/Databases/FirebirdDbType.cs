// Ignore Spelling: Firebird

/**
 * Copyright 2006-2018 Gustavo Augusto Hennig
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 **/
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleDatabaseReplicator.SQL.Databases
{
    public class FirebirdDbType : BaseDbType
    {

        public override string GetIdentityCommand(string name)
        {
            throw new NotImplementedException();
        }

        public override string SetIdentityCommand(string name, object value)
        {
            throw new NotImplementedException();
        }


        public override string GetSequenceName(string table, string field)
        {
            throw new NotImplementedException();
        }


        public override string AllTablesCommand
        {
            get { throw new NotImplementedException(); }
        }

        public override System.Data.Common.DbConnection BuildConnection(string connectionString)
        {
            return new FirebirdSql.Data.FirebirdClient.FbConnection(connectionString);
        }
    }
}

