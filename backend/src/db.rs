use mongodb::bson::{self, doc, Bson};
use mongodb::options::ClientOptions;

use std::env;
use std::error::Error;

pub async fn get_db_client() -> Result<mongodb::Client, Box<dyn Error>> {
   // Load the MongoDB connection string from an environment variable:
   let client_uri =
      env::var("MONGODB_URI").expect("No MONGODB_URI environment var found");

   // A Client is needed to connect to MongoDB:
   let options = ClientOptions::parse(&client_uri).await?;
   let client = mongodb::Client::with_options(options)?;

   Ok(client)
}

pub async fn list_collections() -> Result<(), Box<dyn Error>>{
   let client = get_db_client().await?;

   // Ping the server to see if you can connect to the cluster
   client
      .database("admin")
      .run_command(doc! {"ping": 1}, None)
      .await?;
   println!("Connected successfully.");

   // Get the activities db
   let db = client.database("activities");

   // List the names of the collections in that database.
   println!("Database collections:");
   for collection_name in db.list_collection_names(None).await? {
      println!("\t{}", collection_name);
   }

   OK(())
}

pub async fn add_activity() -> Result<(), Box<dyn Error>> {
   let db = get_db_client().await?.database("activities");

   let activities = db.collection("activities");
   let new_doc = doc! {
      "title": "Test evenement",
      "group": "everyone",
      "date": "2021-02-24",
      "time": "20u34",
      "description": "Dit is een test evenement",
   };
   let insert_result = activities.insert_one(new_doc.clone(), None).await?;
   println!("New document ID: {}", insert_result.inserted_id);
   Ok(())
}

/*

struct Database {
   db_client: Option<mongodb::Client>,
}
impl Database {
   fn take_db_client(&mut self) -> mongodb::Client {
      let p = replace(&mut self.db_client, None);
      p.unwrap()
   }
}
pub static mut DATABASE: Database = Database {
   db_client: Some(mongodb::Client),
};
*/