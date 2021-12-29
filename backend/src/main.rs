#[macro_use]
extern crate rocket;

#[macro_use]
extern crate mongodb;

#[macro_use]
extern crate tokio;

mod routes;
mod db;

use std::error::Error;

#[tokio::main]
async fn main() -> Result<(), Box<dyn Error>> {
   let _result = db::list_collections();
   rocket::build()
   .mount(
        "/",
        routes![
            routes::get_activities,
            routes::post_activities
        ],
    ).launch().await?;
    Ok(())
}

