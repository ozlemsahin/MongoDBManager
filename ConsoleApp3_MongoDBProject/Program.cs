using MongoDB.Driver;
using NPOI.SS.Formula.Functions;
using System;

namespace ConsoleApp3_MongoDBProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //create db and collection
            MongoCRUD database = new MongoCRUD("mydb", "mycoll");
            //create new document
            DocumentPerson person = new DocumentPerson("erbug","saglam");
            //ınsert new document
            database.InsertDocument(person);


        }

        

    }

    //class for create read update delete 
    public class MongoCRUD {

        private IMongoDatabase db;
        public MongoClient client;
        IMongoCollection<DocumentPerson> collections; 

        public MongoCRUD(string database, string collection)
        {
            client = new MongoClient();
            db = client.GetDatabase(database);
            collections = db.GetCollection<DocumentPerson>(collection);
        }

        public void InsertDocument(DocumentPerson document)
        {
            collections.InsertOne(document);
        }
    }

    public class  DocumentPerson {

        public string firstName { get; set; }
        public string lastName { get; set; }
        
        public DocumentPerson(string firstName,  string lastName){
            this.firstName = firstName;
            this.lastName = lastName;
        }

    }
}
