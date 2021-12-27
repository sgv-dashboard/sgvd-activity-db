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
 
    // Print the databases in our MongoDB cluster:
    println!("Databases:");
    for name in client.list_database_names(None, None).await? {
       println!("- {}", name);
    }

    Ok(client)
}