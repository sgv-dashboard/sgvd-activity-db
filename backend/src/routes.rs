//use rocket::tokio::time::{sleep, Duration};


#[get("/activities")]
pub async fn get_activities() -> &'static str {
    "Activity list"
    //TODO: Return activity list
}

#[post("/activities")]
pub async fn post_activities() -> &'static str {
    "Add activities"
    // TODO: Add activity
}

/*
#[get("/delay/<seconds>")]
pub async fn delay(seconds: u64) -> String {
    sleep(Duration::from_secs(seconds)).await;
    format!("Waited for {} seconds", seconds)
}


#[get("/hello/<name>")]
pub fn hello(name: &str) -> String {
    format!("Hello, {}!", name)
}
*/