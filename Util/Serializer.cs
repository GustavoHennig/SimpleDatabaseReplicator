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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;


namespace SimpleDatabaseReplicator
{
    public class Serializer
    {


        public void Write(object obj, string FileName)
        {

            //Opens a file and serializes the object into it in binary format.
            Stream stream = File.Open(FileName, FileMode.Create);
            //BinaryFormatter formatter = new BinaryFormatter();
            XmlSerializer formatter = new XmlSerializer(obj.GetType());



            //BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Close();

        }


        public object Read(string FileName, Type type)
        {

            //BinaryFormatter formatter = new BinaryFormatter();
            //Opens file "data.xml" and deserializes the object from it.
            Stream stream = File.Open(FileName, FileMode.Open);

            XmlSerializer formatter = new XmlSerializer(type);
            //formatter = new BinaryFormatter();

            object obj = formatter.Deserialize(stream);
            stream.Close();
            return obj;


        }
    }
}
